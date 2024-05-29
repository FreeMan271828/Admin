using Admin.NET.Core.Service;
using Admin.NET.Application.Const;
//using Admin.NET.Application.Entity;
using Microsoft.AspNetCore.Http;
namespace Admin.NET.Application;
/// <summary>
/// 代码生成字段配置表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.GroupName, Order = 100)]
public class SysCodeGenConfigService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<SysCodeGenConfig> _rep;
    public SysCodeGenConfigService(SqlSugarRepository<SysCodeGenConfig> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询代码生成字段配置表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<SysCodeGenConfigOutput>> Page(SysCodeGenConfigInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.ColumnName.Contains(input.SearchKey.Trim())
                || u.PropertyName.Contains(input.SearchKey.Trim())
                || u.ColumnComment.Contains(input.SearchKey.Trim())
                || u.NetType.Contains(input.SearchKey.Trim())
                || u.EffectType.Contains(input.SearchKey.Trim())
                || u.FkEntityName.Contains(input.SearchKey.Trim())
                || u.FkTableName.Contains(input.SearchKey.Trim())
                || u.FkColumnName.Contains(input.SearchKey.Trim())
                || u.FkColumnNetType.Contains(input.SearchKey.Trim())
                || u.DictTypeCode.Contains(input.SearchKey.Trim())
                || u.WhetherRetract.Contains(input.SearchKey.Trim())
                || u.WhetherRequired.Contains(input.SearchKey.Trim())
                || u.WhetherSortable.Contains(input.SearchKey.Trim())
                || u.QueryWhether.Contains(input.SearchKey.Trim())
                || u.QueryType.Contains(input.SearchKey.Trim())
                || u.WhetherTable.Contains(input.SearchKey.Trim())
                || u.WhetherAddUpdate.Contains(input.SearchKey.Trim())
                || u.ColumnKey.Contains(input.SearchKey.Trim())
                || u.DataType.Contains(input.SearchKey.Trim())
                || u.WhetherCommon.Contains(input.SearchKey.Trim())
                || u.DisplayColumn.Contains(input.SearchKey.Trim())
                || u.ValueColumn.Contains(input.SearchKey.Trim())
                || u.PidColumn.Contains(input.SearchKey.Trim())
            )
            .WhereIF(input.CodeGenId>0, u => u.CodeGenId == input.CodeGenId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.ColumnName), u => u.ColumnName.Contains(input.ColumnName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.PropertyName), u => u.PropertyName.Contains(input.PropertyName.Trim()))
            .WhereIF(input.ColumnLength>0, u => u.ColumnLength == input.ColumnLength)
            .WhereIF(!string.IsNullOrWhiteSpace(input.ColumnComment), u => u.ColumnComment.Contains(input.ColumnComment.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.NetType), u => u.NetType.Contains(input.NetType.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.EffectType), u => u.EffectType.Contains(input.EffectType.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.FkEntityName), u => u.FkEntityName.Contains(input.FkEntityName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.FkTableName), u => u.FkTableName.Contains(input.FkTableName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.FkColumnName), u => u.FkColumnName.Contains(input.FkColumnName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.FkColumnNetType), u => u.FkColumnNetType.Contains(input.FkColumnNetType.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.DictTypeCode), u => u.DictTypeCode.Contains(input.DictTypeCode.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.WhetherRetract), u => u.WhetherRetract.Contains(input.WhetherRetract.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.WhetherRequired), u => u.WhetherRequired.Contains(input.WhetherRequired.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.WhetherSortable), u => u.WhetherSortable.Contains(input.WhetherSortable.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.QueryWhether), u => u.QueryWhether.Contains(input.QueryWhether.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.QueryType), u => u.QueryType.Contains(input.QueryType.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.WhetherTable), u => u.WhetherTable.Contains(input.WhetherTable.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.WhetherAddUpdate), u => u.WhetherAddUpdate.Contains(input.WhetherAddUpdate.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.ColumnKey), u => u.ColumnKey.Contains(input.ColumnKey.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.DataType), u => u.DataType.Contains(input.DataType.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.WhetherCommon), u => u.WhetherCommon.Contains(input.WhetherCommon.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.DisplayColumn), u => u.DisplayColumn.Contains(input.DisplayColumn.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.ValueColumn), u => u.ValueColumn.Contains(input.ValueColumn.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.PidColumn), u => u.PidColumn.Contains(input.PidColumn.Trim()))
            .WhereIF(input.OrderNo>0, u => u.OrderNo == input.OrderNo)
            .Select<SysCodeGenConfigOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加代码生成字段配置表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddSysCodeGenConfigInput input)
    {
        var entity = input.Adapt<SysCodeGenConfig>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除代码生成字段配置表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteSysCodeGenConfigInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新代码生成字段配置表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateSysCodeGenConfigInput input)
    {
        var entity = input.Adapt<SysCodeGenConfig>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取代码生成字段配置表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<SysCodeGenConfig> Detail([FromQuery] QueryByIdSysCodeGenConfigInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取代码生成字段配置表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<SysCodeGenConfigOutput>> List([FromQuery] SysCodeGenConfigInput input)
    {
        return await _rep.AsQueryable().Select<SysCodeGenConfigOutput>().ToListAsync();
    }





}

