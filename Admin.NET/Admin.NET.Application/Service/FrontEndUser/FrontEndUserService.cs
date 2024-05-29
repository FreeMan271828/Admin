// 大名科技（天津）有限公司版权所有  电话：18020030720  QQ：515096995
//
// 此源代码遵循位于源代码树根目录中的 LICENSE 文件的许可证

using Furion.RemoteRequest;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using SKIT.FlurlHttpClient.Wechat.Api.Models;

namespace Admin.NET.Application;
public class FrontEndUserService :IDynamicApiController, ITransient
{
    private readonly string _defaultPwd = "123456";

    private readonly SqlSugarRepository<FrontEndUser> _frontEndUserDb;
    private readonly SqlSugarRepository<UserPower> _userPowerDb;
    
    public FrontEndUserService(SqlSugarRepository<FrontEndUser> db1, SqlSugarRepository<UserPower> db2)
    {
        _frontEndUserDb = db1;
        _userPowerDb = db2;
    }
    //获取所有用户
    [DisplayName("获取所有用户")]
    [HttpGet("getAllUsers")]
    public async Task<List<FrontEndUser>> GetAllUsers()
    {
        return await _frontEndUserDb.GetListAsync();
    }
    
    // 分页查询所有用户
    [DisplayName("分页查询全部用户")]
    [HttpGet("getAllUsersInPage")]
    public async Task<SqlSugarPagedList<FrontEndUser>> GetAllUsersInPage([FromQuery]int pageIndex, 
        [FromQuery]int pageSize)
    {
        return await _frontEndUserDb.AsQueryable().ToPagedListAsync<FrontEndUser>(pageIndex, pageSize);
    }

    // 增加前端用户
    [DisplayName("增加前端用户")]
    [HttpPost("addUser")]
    public async Task<bool> AddFrontEndUser([FromQuery]FrontEndUser user)
    {
        // 在添加之前可以添加额外的逻辑，比如密码加密等
        // EncryptPassword是密码加密方法
        //user.UserPassword = EncryptPassword(user.UserPassword);
        return await _frontEndUserDb.InsertAsync(user);
    }

    // 删除前端用户
    [DisplayName("通过Id删除前端用户")]
    [HttpPost("delUserById")]
    public async Task<bool> DeleteFrontEndUser([FromQuery]long id)
    {
        // 先删除所有与该用户ID关联的UserPower记录
        var userPowers = await _userPowerDb.GetListAsync(up => up.UserId == id);
        foreach (var userPower in userPowers)
        {
            await _userPowerDb.DeleteAsync(userPower);
        }
        //删除前端用户表中的字段
        return await _frontEndUserDb.DeleteByIdAsync(id);
    }

    // 修改前端用户
    [HttpPost("changeUserInfo")]
    public async Task<bool> UpdateFrontEndUser([FromQuery]FrontEndUser user)
    {
        return await _frontEndUserDb.UpdateAsync(user);
    }

    // 根据条件获取前端用户信息
    [DisplayName("根据id或者姓名获取前端用户信息")]
    [HttpGet("getUserByParam")]
    public async Task<List<FrontEndUser>> GetFrontEndUser([FromQuery]long ? id,[FromQuery]string ? name)
    {
        //姓名为空，使用id进行查询
        if (name.IsNullOrEmpty())
        {
            List<FrontEndUser> frontEndUsers = new List<FrontEndUser>();
            frontEndUsers.Add(await _frontEndUserDb.GetByIdAsync(id));
            return frontEndUsers;    
        }
        //id为空，使用name进行模糊查询
        else if (id.IsNullOrEmpty())
        {
            // 使用模糊匹配查询姓名，假设用户表的姓名字段名为"Name"
            return  _frontEndUserDb.AsQueryable()
                .Where(it => it.Name.Contains(name))
                .ToList();
        }
        //id和name都不为空
        else
        {
            return _frontEndUserDb.AsQueryable()
                .Where(it => it.Name.Contains(name) && it.Id == id)
                .ToList();
        }
    }
    
    // 修改密码
    [HttpPost("changePassword")]
    [DisplayName("修改密码")]
    public async Task<bool> ChangePassword([FromQuery]long userId, [FromQuery]string oldPassword, [FromQuery]string newPassword)
    {
        var user = await _frontEndUserDb.GetByIdAsync(userId) ?? throw new Exception("用户不存在");

        // 这里需要实现密码验证逻辑，确保oldPassword是正确的
        if (user.UserPassword != oldPassword)
        {
            throw new Exception("旧密码不正确");
        }

        user.UserPassword = EncryptPassword(newPassword);
        return await _frontEndUserDb.UpdateAsync(user);
    }

    // 重置密码
    [DisplayName("根据用户Id重置密码")]
    [HttpPost("resetPassword")]
    public async Task<bool> ResetPassword([FromQuery]long userId)
    {
        var user = await _frontEndUserDb.GetByIdAsync(userId) ?? throw new Exception("用户不存在");
        user.UserPassword = EncryptPassword(_defaultPwd);
        return await _frontEndUserDb.UpdateAsync(user);
    }
    
    // 修改状态
    [DisplayName("根据用户Id修改状态")]
    [HttpPost("changeUserStatus")]
    public async Task<bool> ChangeUserStatus([FromQuery]long userId)
    {
        // 1. 获取用户列表
        Task<List<FrontEndUser>> usersTask = GetFrontEndUser(userId, "");

        // 2. 等待获取用户列表完成
        List<FrontEndUser> users = await usersTask;

        if (users.IsNullOrEmpty())
        {
            throw new Exception("userId不正确，未匹配到用户");
        }

        if (users[0].Status == 0)
        {
            users[0].Status = 1;
            await UpdateFrontEndUser(users[0]);
            return true;
        }
        else
        {
            users[0].Status = 0;
            await UpdateFrontEndUser(users[0]);
            return true;
        }
    }

    // 密码加密方法
    private string EncryptPassword(string password)
    {
        //添加加密算法
        return password; 
    }
}
