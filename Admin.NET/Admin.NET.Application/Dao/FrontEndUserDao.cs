// 大名科技（天津）有限公司版权所有  电话：18020030720  QQ：515096995
// 
// 此源代码遵循位于源代码树根目录中的 LICENSE 文件的许可证
namespace Admin.NET.Application;

public class FrontEndUserDao
{
    private readonly SqlSugarRepository<FrontEndUser> _frontEndUserDb;
    
    public FrontEndUserDao(SqlSugarRepository<FrontEndUser> db)
    {
        _frontEndUserDb = db;
    }
    
    //增
    // 增加前端用户
    public async Task<bool> AddFrontEndUser(FrontEndUser user)
    {
        // 在添加之前可以添加额外的逻辑，比如密码加密等
        // EncryptPassword是密码加密方法
        //user.UserPassword = EncryptPassword(user.UserPassword);
        return await _frontEndUserDb.InsertAsync(user);
    }
    
    //删
    public async Task<bool> DelFrontEndUser(FrontEndUser user)
    {
        return await _frontEndUserDb.DeleteAsync(user);
    }
    
    //改
    // 修改前端用户
    public async Task<bool> UpdateFrontEndUser(FrontEndUser user)
    {
        return await _frontEndUserDb.UpdateAsync(user);
    }
    
    //查
    //获取所有用户
    public async Task<List<FrontEndUser>> GetUsers()
    {
        return await _frontEndUserDb.GetListAsync();
    }
    
    // 分页查询所有用户
    public async Task<SqlSugarPagedList<FrontEndUser>> GetUsersInPage(int pageIndex, int pageSize)
    {
        return await _frontEndUserDb.AsQueryable().ToPagedListAsync<FrontEndUser>(pageIndex, pageSize);
    }
    
    // 根据条件获取前端用户信息
    public List<FrontEndUser> GetUsersByParam(int ? id,string ? name)
    {
        //姓名为空，使用id进行查询
        if (name.IsNullOrEmpty())
        {
            List<FrontEndUser> frontEndUsers = new List<FrontEndUser>();
            frontEndUsers.Add( _frontEndUserDb.GetByIdAsync(id).Result);
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
}