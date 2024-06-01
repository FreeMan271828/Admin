// 大名科技（天津）有限公司版权所有  电话：18020030720  QQ：515096995
//
// 此源代码遵循位于源代码树根目录中的 LICENSE 文件的许可证

using Furion.RemoteRequest;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using SKIT.FlurlHttpClient.Wechat.Api.Models;

namespace Admin.NET.Application;
public class FrontEndUserService :IDynamicApiController, ITransient
{
 //   private readonly string _defaultPwd = "123456";

    private readonly FrontEndUserDao _frontEndUserDao;
    private readonly UserPowerDao _userPowerDao;
    
    public FrontEndUserService(SqlSugarRepository<FrontEndUser> db1, SqlSugarRepository<UserPower> db2)
    {
        _frontEndUserDao = new FrontEndUserDao(db1);
        _userPowerDao = new UserPowerDao(db2);
    }
    
    // 增加前端用户
    [DisplayName("增加前端用户")]
    [HttpPost("addUser")]
    public async Task<bool> AddFrontEndUser([FromQuery]string name,[FromQuery]string userPasswword,
                                                [FromQuery]int ? status,[FromQuery]string ? remark)
    {
        // 在添加之前可以添加额外的逻辑，比如密码加密等
        // EncryptPassword是密码加密方法
        //user.UserPassword = EncryptPassword(user.UserPassword);
        FrontEndUser user = new FrontEndUser(){
            Name = name,UserPassword = userPasswword,Remark = remark
        };
        user.Status = status.IsNullOrEmpty() ? 1 : 0;
        return await _frontEndUserDao.AddFrontEndUser(user);
    }
    
    // 删除前端用户
    [DisplayName("删除前端用户")]
    [HttpPost("delUserById")]
    public async Task<bool> DelUser([FromQuery]int id)
    {
        FrontEndUser frontEndUser = new FrontEndUser();
        frontEndUser.Id = id;
        //在UserPower表中删除对应的Id的关系
        //在FrontEndUser表中删除对应的实体数据
        return await _frontEndUserDao.DelFrontEndUser(frontEndUser)&&
           await _userPowerDao.DelUserPower(frontEndUser);
    }
    
    // 修改状态
    [DisplayName("根据用户Id修改状态")]
    [HttpPost("changeUserStatus")]
    public async Task<bool> ChangeUserStatus([FromQuery]int userId)
    {
        // 1. 获取用户列表
        List<FrontEndUser> usersTask = _frontEndUserDao.GetUsersByParam(userId, "");

        // 2. 等待获取用户列表完成
        List<FrontEndUser> users = usersTask;

        if (users.IsNullOrEmpty())
        {
            throw new Exception("userId不正确，未匹配到用户");
        }
        if (users[0].Status == 0)
        {
            users[0].Status = 1;
            await _frontEndUserDao.UpdateFrontEndUser(users[0]);
            return true;
        }
        else
        {
            users[0].Status = 0;
            await _frontEndUserDao.UpdateFrontEndUser(users[0]);
            return true;
        }
    }
    
    // 修改密码
    [HttpPost("changePassword")]
    [DisplayName("修改密码")]
    public async Task<bool> ChangePassword([FromQuery]int userId, [FromQuery]string oldPassword, [FromQuery]string newPassword)
    {
        FrontEndUser user = _frontEndUserDao.GetUsersByParam(userId,"").First();
        // 这里需要实现密码验证逻辑，确保oldPassword是正确的
        if (user.UserPassword != oldPassword)
        {
            throw new Exception("旧密码不正确");
        }
        //user.UserPassword = EncryptPassword(newPassword);
        user.UserPassword = newPassword;
        return await _frontEndUserDao.UpdateFrontEndUser(user);
    }

    // 重置密码
    [DisplayName("根据用户Id重置密码")]
    [HttpPost("resetPassword")]
    public async Task<bool> ResetPassword([FromQuery]int userId)
    {
        FrontEndUser user =_frontEndUserDao.GetUsersByParam(userId, "").First();
        // user.UserPassword = EncryptPassword(_defaultPwd);
        return await _frontEndUserDao.UpdateFrontEndUser(user);
    }
    
    //分页查询全部用户
    [DisplayName("分页查询全部用户")]
    [HttpGet("getAllUsersInPage")]
    public async Task<SqlSugarPagedList<FrontEndUser>> GetUsersInPage([FromQuery] int pageIndex, [FromQuery] int pageSize)
    {
        return await _frontEndUserDao.GetUsersInPage(pageIndex, pageSize);
    }
    
    //分页查询全部用户
    [DisplayName("根据数据查询全部用户")]
    [HttpGet("getUsersByParam")]
    public async Task<List<FrontEndUser>> GetUsersByParams([FromQuery]int ? id,[FromQuery]string ? name)
    {
        return  _frontEndUserDao.GetUsersByParam(id, name);
    }
    // 密码加密方法
    private string EncryptPassword(string password)
    {
        //添加加密算法
        return password; 
    }
}
