// 大名科技（天津）有限公司版权所有  电话：18020030720  QQ：515096995
// 
// 此源代码遵循位于源代码树根目录中的 LICENSE 文件的许可证
using COSXML.Model.Tag;
using Furion.Localization;
namespace Admin.NET.Application;

public class UserPowerDao
{
    private readonly SqlSugarRepository<UserPower> _userPowerDb;

    public UserPowerDao(SqlSugarRepository<UserPower> db)
    {
        this._userPowerDb = db;
    }
    
    //增加用户权限
    public async Task<bool> AddUserPower(FrontEndUser user, PowerBase powerBase)
    {
       return await _userPowerDb.InsertAsync(
           new UserPower{UserId = user.Id,PowerId = powerBase.Id}
           );
    }
    public async Task<bool> AddUserPower(UserPower userPower)
    {
        return await _userPowerDb.InsertAsync(userPower);
    }
    
    //删除用户权限
    public async Task<bool> DelUserPower(FrontEndUser user, PowerBase powerBase)
    {
        return await _userPowerDb.DeleteAsync(
            new UserPower{
                UserId = user.Id, PowerId = powerBase.Id
            }
        );
    }
    public async Task<bool> DelUserPower(UserPower userPower)
    {
        return await _userPowerDb.DeleteAsync(userPower);
    }
    
    //根据用户信息删除在此表中的关系
    public async Task<bool> DelUserPower(FrontEndUser user)
    {
        int count = 0;
        var userPowers = await _userPowerDb.GetListAsync(
            up => up.UserId .Equals(user.Id)
            );
        foreach (var userPower in userPowers)
        {
            if (await _userPowerDb.DeleteAsync(userPower))
            {
                count++;
            };
        }
        // 如果删除的记录数大于0，则认为删除成功
        return count > 0;
    }
    
    //根据权限信息删除在此表中的关系
    public async Task<bool> DelUserPower(PowerBase powerBase)
    {
        int count = 0;
        var userPowers = await _userPowerDb.GetListAsync(
            up => up.PowerId .Equals(powerBase.Id)
        );
        foreach (var userPower in userPowers)
        {
            if (await _userPowerDb.DeleteAsync(userPower))
            {
                count++;
            };
        }
        // 如果删除的记录数大于0，则认为删除成功
        return count > 0;
    }
    
    //修改用户权限
    public async Task<bool> UpdateUserPower(FrontEndUser user, PowerBase powerBase)
    {
        return await _userPowerDb.UpdateAsync(new UserPower{
            UserId = user.Id, PowerId = powerBase.Id
        });                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
    }
    
    //查询用所有户权限
    public async Task<List<UserPower>> GetUserPowers()
    {
        return await _userPowerDb.GetListAsync();
    }
    
    //分页查询所有的用户权限
    public async Task<SqlSugarPagedList<UserPower>> GetUserPowersInPage(int pageIndex,int pageSize)
    {
        return await _userPowerDb.AsQueryable().ToPagedListAsync(pageIndex, pageSize);
    }
    
    //查询某一个用户拥有的用户权限
    public List<UserPower> GetUserPowersFromUser(FrontEndUser user)
    {
        return _userPowerDb.GetList(it =>
            it.UserId.Equals(user.Id)
        );
    }
}