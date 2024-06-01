// 大名科技（天津）有限公司版权所有  电话：18020030720  QQ：515096995
// 
// 此源代码遵循位于源代码树根目录中的 LICENSE 文件的许可证
namespace Admin.NET.Application;

public class PowerBaseDao
{
    private readonly SqlSugarRepository<PowerBase> _powerBaseDb;
    
    public PowerBaseDao(SqlSugarRepository<PowerBase> db)
    {
        _powerBaseDb= db;
    }
    
    //增加权限
    public async Task<bool> AddPowerBase(PowerBase powerBase)
    {
        return await _powerBaseDb.InsertAsync(powerBase);
    }
    
    //删除权限
    public async Task<bool> DelPowerBase(PowerBase powerBase)
    {
        return await _powerBaseDb.DeleteAsync(powerBase);
    }
    
    //修改权限
    public async Task<bool> UpdatePowerBase(PowerBase powerBase)
    {
        return await _powerBaseDb.UpdateAsync(powerBase);
    }
    
    //查
    //获取全部权限
    public async Task<List<PowerBase>> GetPowers()
    {
        return await _powerBaseDb.GetListAsync();
    }
    
    //分页查询权限
    public async Task<SqlSugarPagedList<PowerBase>> GetPowersInPage(int pageIndex,int pageSize)
    {
        return await _powerBaseDb.AsQueryable().ToPagedListAsync(pageIndex, pageSize);
    }
    
    //根据条件获取权限
    public List<PowerBase> GetPowerByParam(long ? id,string ? name)
    {
        //姓名为空，使用id进行查询
        if (name.IsNullOrEmpty())
        {
            List<PowerBase> powerBases = new List<PowerBase>();
            powerBases.Add(_powerBaseDb.GetByIdAsync(id).Result);
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