// 大名科技（天津）有限公司版权所有  电话：18020030720  QQ：515096995
//
// 此源代码遵循位于源代码树根目录中的 LICENSE 文件的许可证

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Application;
public class PowerBaseService : IDynamicApiController, ITransient
{
    private readonly PowerBaseDao _powerBaseDao;
    private readonly UserPowerDao _userPowerDao;

    public PowerBaseService(SqlSugarRepository<PowerBase> db1,SqlSugarRepository<UserPower>db2)
    {
        _powerBaseDao = new PowerBaseDao(db1);
        _userPowerDao = new UserPowerDao(db2);
    }
    
    // 增加权限
    [HttpPost("addPower")]
    public async Task<bool> AddPowerAsync([FromQuery]PowerBase power)
    {
        var existingPower =await _powerBaseDao.GetPowers();
        if (power.Name.IsNullOrEmpty())
        {
            throw new Exception("权限名称确实");
        }
        // 确保不添加重复的权限名称，采用分治法
        // 插入新权限
        return await _powerBaseDao.AddPowerBase(power);
    }
    
    //删除权限信息
    [HttpPost("delPowerById")]
    public async Task<bool> DeletePowerBase([FromQuery]int id)
    {
        PowerBase powerBase =new PowerBase();
        powerBase.Id = id;
        return await _powerBaseDao.DelPowerBase(powerBase)&& await 
            _userPowerDao.DelUserPower(powerBase);
    }
    
    // 修改权限
    [HttpPost("changePower")]
    public async Task<bool> UpdatePowerNameAsync([FromQuery]PowerBase powerBase)
    {
        return await _powerBaseDao.UpdatePowerBase(powerBase);
    }
    
    //获取全部权限
    [HttpGet("getAllPowers")]
    public async Task<List<PowerBase>> GetAllPowers()
    {
        return await _powerBaseDao.GetPowers();
    }
    
    //分页查询全部权限
    [HttpGet("getAllPowersInPage")]
    public async Task<SqlSugarPagedList<PowerBase>> GetAllPowersInPage([FromQuery] int pageIndex, [FromQuery] int pageSize)
    {
        return await _powerBaseDao.GetPowersInPage(pageIndex, pageSize);
    }
}
