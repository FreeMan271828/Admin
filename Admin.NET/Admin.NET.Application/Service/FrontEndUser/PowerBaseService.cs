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
    private readonly SqlSugarRepository<PowerBase> _powerBaseDb;
    private readonly SqlSugarRepository<UserPower> _userPowerDb;

    public PowerBaseService(SqlSugarRepository<PowerBase> db1,SqlSugarRepository<UserPower>db2)
    {
        _powerBaseDb = db1;
        _userPowerDb = db2;
    }
    
    // 增加权限
    [HttpPost("addPower")]
    public async Task<bool> AddPowerAsync([FromQuery]PowerBase power)
    {
        // 确保不添加重复的权限名称
        var existingPower = await _powerBaseDb.GetFirstAsync(p => p.Name == power.Name);
        if (existingPower != null)
        {
            throw new Exception("权限名称已存在。");
        }

        // 插入新权限
        return await _powerBaseDb.InsertAsync(power);
    }
    
    // 修改权限名称
    [HttpPost("changePower")]
    public async Task<bool> UpdatePowerNameAsync([FromQuery]PowerBase powerBase)
    {
        return await _powerBaseDb.UpdateAsync(powerBase);
    }

    //删除权限信息
    [HttpPost("delPowerById")]
    public async Task<bool> DeletePowerBase([FromQuery]int id)
    {
        // 先删除所有与该权限ID关联的UserPower记录
        var userPowers = await _powerBaseDb.GetListAsync(up => up.Id == id);
        foreach (var userPower in userPowers)
        {
            return await _powerBaseDb.DeleteAsync(userPower);
        }
        //删除权限表中的字段
        return await _powerBaseDb.DeleteByIdAsync(id);
    }
    
    //获取全部权限
    [HttpGet("getAllPowers")]
    public async Task<List<PowerBase>> GetAllPowers()
    {
        return await _powerBaseDb.GetListAsync();
    }
    
    //分页查询全部权限
    [HttpGet("getAllPowersInPage")]
    public async Task<SqlSugarPagedList<PowerBase>> GetAllPowersInPage([FromQuery]int pageIndex, [FromQuery]int pageSize)
    {
        return await _powerBaseDb.AsQueryable().ToPagedListAsync<PowerBase>(pageIndex, pageSize);
    }

    //根据Id或者Name获取权限信息
    [HttpGet("getPowerByParam")]
    public async Task<List<PowerBase>> GetPower([FromQuery]long ? id,[FromQuery]string ? name)
    {
        //姓名为空，使用id进行查询
        if (name.IsNullOrEmpty())
        {
            List<PowerBase> powerBases = new List<PowerBase>();
            powerBases.Add(await _powerBaseDb.GetByIdAsync(id));
            return powerBases;    
        }
        //id为空，使用name进行模糊查询
        else if (id.IsNullOrEmpty())
        {
            // 使用模糊匹配查询姓名，假设用户表的姓名字段名为"Name"
            return  _powerBaseDb.AsQueryable()
                .Where(it => it.Name.Contains(name))
                .ToList();
        }
        //id和name都不为空
        else
        {
            return _powerBaseDb.AsQueryable()
                .Where(it => it.Name.Contains(name) && it.Id == id)
                .ToList();
        }
    }
}
