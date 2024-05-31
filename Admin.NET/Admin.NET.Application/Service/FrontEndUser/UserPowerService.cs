// 大名科技（天津）有限公司版权所有  电话：18020030720  QQ：515096995
//
// 此源代码遵循位于源代码树根目录中的 LICENSE 文件的许可证

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Furion.Logging;

namespace Admin.NET.Application;

public class UserWithPower
{
    public FrontEndUser User { get; set; }
    public List<PowerBase> Powers { get; set; }
}

public class UserPowerService :  IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<FrontEndUser> _FrontEndUserDb;
    private readonly SqlSugarRepository<PowerBase> _PowerBaseDb;
    private readonly SqlSugarRepository<UserPower> _UserPowerDb;

    public UserPowerService(SqlSugarRepository<FrontEndUser> db1,
        SqlSugarRepository<PowerBase> db2,SqlSugarRepository<UserPower> db3)
    {
        _FrontEndUserDb = db1;
        _PowerBaseDb = db2; 
        _UserPowerDb = db3;
    }

    //为用户添加权限
    [HttpPost("addUserPower")]
    public async Task<bool> AddUserPower([FromQuery]int userId,[FromQuery]int powerId)
    {
        if (_FrontEndUserDb.GetByIdAsync(userId) != null)
        {
            if (_PowerBaseDb.GetByIdAsync(powerId) == null)
            {
                throw new Exception("没有此ID对应的权限");
            }
            return await _UserPowerDb.InsertAsync(new UserPower { UserId = userId, PowerId = powerId });
        }
        throw new Exception("没有此ID对应的前端用户");
    }

    //删除用户权限
    [HttpGet("delUserPower")]
    public async Task<bool> DeleteUserPower([FromQuery]int userId,[FromQuery]int powerId)
    {
        if (_FrontEndUserDb.GetByIdAsync(userId) != null)
        {
            if (_PowerBaseDb.GetByIdAsync(powerId) == null)
            {
                throw new Exception("没有此ID对应的权限");
            }
            return await _UserPowerDb.DeleteByIdsAsync(new dynamic[] { userId, powerId });
        }
        throw new Exception("没有此ID对应的前端用户");
    }
    
    //根据用户Id获取Power
    //待维护
    [HttpGet("getPowerByUserId")]
    public async Task<List<UserPower>> GetPowerByUserId([FromQuery]int id)
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   {
        return  _UserPowerDb.AsQueryable()
            .Where(it => it.UserId.Equals(id))
            .ToList();
    }
        
    //获取全部的用户权限
    [HttpGet("getAllUserPower")]
    public async Task<List<UserPower>> GetAllUserPower()
    {
        return await _UserPowerDb.GetListAsync();
    }
    
    //发送用户全部信息
    [HttpGet("getAllInfo")]
    public async Task<List<UserWithPower>> getAllInfo()
    {
        List<UserWithPower> userWithPowers = new List<UserWithPower>();
        List<FrontEndUser> users = _FrontEndUserDb.GetListAsync().Result;
        foreach (FrontEndUser frontEndUser in users)
        {
            UserWithPower userWithPower = new UserWithPower();
            userWithPower.User = frontEndUser;
            //先在UserPower表中获取frontEndUser对应的powerId(List)
            List<UserPower> userPowers = GetPowerByUserId(frontEndUser.Id)
                .Result;
            List<int> powerIds = new List<int>();
            foreach (UserPower userPower in userPowers)
            {
                powerIds.Add(userPower.PowerId);
            }
            //在PowerBase表中获得powerId对应的power
            List<PowerBase> powerBases = new List<PowerBase>();
            foreach (int powerId in powerIds)
            {
                powerBases.Add(_PowerBaseDb.GetByIdAsync(powerId).Result);
            }
            userWithPower.Powers = powerBases;
            userWithPowers.Add(userWithPower);
        }
        return userWithPowers;
    }
    
    //发送用户全部信息,进行分页查询
    [HttpGet("getAllInfoInPage")]
    public async Task<List<UserWithPower>> getAllInfoInPage([FromQuery] int pageIndex, [FromQuery] int pageSize)
    {
        // 获取所有用户数据
        var users = _FrontEndUserDb.GetListAsync().Result;

        // 使用 X.PagedList 库进行分页
        var pagedUsers = users.ToPagedList(pageIndex, pageSize).Items.ToList();
        List<UserWithPower> userWithPowers = new List<UserWithPower>();
        foreach (FrontEndUser frontEndUser in pagedUsers)
        {                                                                                         
            UserWithPower userWithPower = new UserWithPower();
            userWithPower.User = frontEndUser;
            //先在UserPower表中获取frontEndUser对应的powerId(List)
            List<UserPower> userPowers = GetPowerByUserId(frontEndUser.Id)
                .Result;
            List<int> powerIds = new List<int>();
            foreach (UserPower userPower in userPowers)
            {
                powerIds.Add(userPower.PowerId);
            }
            //在PowerBase表中获得powerId对应的power
            List<PowerBase> powerBases = new List<PowerBase>();
            foreach (int powerId in powerIds)
            {
                powerBases.Add(_PowerBaseDb.GetByIdAsync(powerId).Result);
            }
            userWithPower.Powers = powerBases;
            userWithPowers.Add(userWithPower);
        }
        return userWithPowers;
    }
}
