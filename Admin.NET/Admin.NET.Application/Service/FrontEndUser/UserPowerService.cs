// 大名科技（天津）有限公司版权所有  电话：18020030720  QQ：515096995
//
// 此源代码遵循位于源代码树根目录中的 LICENSE 文件的许可证

using System;
using System.Collections.Concurrent;
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
    private readonly FrontEndUserDao _frontEndUserDao;
    private readonly PowerBaseDao _powerBaseDao;
    private readonly UserPowerDao _userPowerDao;
    
    public UserPowerService(SqlSugarRepository<FrontEndUser> db1,
        SqlSugarRepository<PowerBase> db2,SqlSugarRepository<UserPower> db3)
    {
        _frontEndUserDao = new FrontEndUserDao(db1);
        _powerBaseDao = new PowerBaseDao(db2);
        _userPowerDao = new UserPowerDao(db3);
    }

    [HttpPost("addUserPower")]
    public async Task<bool> AddUserPower([FromQuery]int userId, [FromQuery]int powerId)
    {
        // 检查用户是否存在
        var user =  _frontEndUserDao.GetUsersByParam(userId, "");
        if (user == null)
        {
            throw new Exception("没有此ID对应的前端用户");
        }

        // 检查权限是否存在
        var power = _powerBaseDao.GetPowerByParam(powerId, "");
        if (power == null)
        {
            throw new Exception("没有此ID对应的权限");
        }

        // 添加用户权限
        return await _userPowerDao.AddUserPower(new UserPower { UserId = userId, PowerId = powerId });
    }

    //删除用户权限
    [HttpGet("delUserPower")]
    public async Task<bool> DeleteUserPower([FromQuery]int userId,[FromQuery]int powerId)
    {
        // 检查用户是否存在
        var user =  _frontEndUserDao.GetUsersByParam(userId, "");
        if (user == null)
        {
            throw new Exception("没有此ID对应的前端用户");
        }

        // 检查权限是否存在
        var power = _powerBaseDao.GetPowerByParam(powerId, "");
        if (power == null)
        {
            throw new Exception("没有此ID对应的权限");
        }
        return await _userPowerDao.DelUserPower(new UserPower{
            UserId = userId, PowerId = powerId
        });
    }
    
    //根据某一个用户拥有的用户权限
    [HttpGet("getPowerByUserId")]
    public async Task<ConcurrentQueue<PowerBase>> GetPowerByUserId([FromQuery]int id)
    {
        if (_frontEndUserDao.GetUsersByParam(id, "").IsNullOrEmpty())
        {
            throw new Exception("当前用户不存在");
        }
        List<UserPower> userPowers = _userPowerDao.GetUserPowersFromUser(
            new FrontEndUser{Id = id});
        ConcurrentQueue<PowerBase> powerBases = new ConcurrentQueue<PowerBase>();
        foreach (UserPower userPower in userPowers)
        {
            powerBases.Enqueue(_powerBaseDao.GetPowerByParam(userPower.PowerId, "").First());
        }
        return powerBases;
    }
    
    //发送用户全部信息
    [HttpGet("getAllInfo")]
    public async Task<ConcurrentQueue<UserWithPower>> getAllInfo()
    {
        ConcurrentQueue<UserWithPower> userWithPowers = new ConcurrentQueue<UserWithPower>();
        List<FrontEndUser> users = await _frontEndUserDao.GetUsers();
        foreach (FrontEndUser frontEndUser in users)
        {
            
            ConcurrentQueue<PowerBase> powerBases = await GetPowerByUserId(frontEndUser.Id);
             userWithPowers.Enqueue(new UserWithPower{User = frontEndUser,Powers = powerBases.ToList()});
        }
        return userWithPowers;
    }
    
    //发送用户全部信息,进行分页查询
    [HttpGet("getAllInfoInPage")]
    public async Task<List<UserWithPower>> getAllInfoInPage([FromQuery] int pageIndex, [FromQuery] int pageSize)
    {
        // 获取所有用户数据
        List<FrontEndUser> users = await _frontEndUserDao.GetUsers();
        // 使用 X.PagedList 库进行分页
        SqlSugarPagedList<FrontEndUser> pagedUsers = users.ToPagedList(pageIndex, pageSize);
        List<UserWithPower> userWithPowers = new List<UserWithPower>();
        foreach (FrontEndUser frontEndUser in pagedUsers.Items)
        {
            ConcurrentQueue<PowerBase> powerBases = GetPowerByUserId(frontEndUser.Id).Result;
            userWithPowers.Add(new UserWithPower{User = frontEndUser,Powers = powerBases.ToList()});
        }
        return userWithPowers;
    }
}
