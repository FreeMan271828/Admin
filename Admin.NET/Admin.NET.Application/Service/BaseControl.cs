// 大名科技（天津）有限公司版权所有  电话：18020030720  QQ：515096995
// 
// 此源代码遵循位于源代码树根目录中的 LICENSE 文件的许可证
namespace Admin.NET.Application;

public class BaseControl:IDynamicApiController, ITransient
{

    private readonly ISqlSugarClient _db;

    public BaseControl(ISqlSugarClient _db)
    {
        this._db = _db;
    }
    
    //分页查询泛型方法
    public async Task<SqlSugarPagedList<T>> queryInPage<T>(int pageIndex, int pageSize) where T :class
    {
        return await _db.Queryable<T>().ToPagedListAsync<T>(pageIndex,pageSize);
    }
}