using Admin.NET.Core.Service;
using Admin.NET.Application.Const;
//using Admin.NET.Application.Entity;
using Microsoft.AspNetCore.Http;
namespace Admin.NET.Application;
/// <summary>
/// 李兴文服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.GroupName, Order = 100)]
public class SysFileService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<SysFile> _rep;
    public SysFileService(SqlSugarRepository<SysFile> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询李兴文
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<SysFileOutput>> Page(SysFileInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.Provider.Contains(input.SearchKey.Trim())
                || u.BucketName.Contains(input.SearchKey.Trim())
                || u.FileName.Contains(input.SearchKey.Trim())
                || u.Suffix.Contains(input.SearchKey.Trim())
                || u.FilePath.Contains(input.SearchKey.Trim())
                || u.SizeKb.Contains(input.SearchKey.Trim())
                || u.SizeInfo.Contains(input.SearchKey.Trim())
                || u.Url.Contains(input.SearchKey.Trim())
                || u.FileMd5.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.Provider), u => u.Provider.Contains(input.Provider.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.BucketName), u => u.BucketName.Contains(input.BucketName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.FileName), u => u.FileName.Contains(input.FileName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Suffix), u => u.Suffix.Contains(input.Suffix.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.FilePath), u => u.FilePath.Contains(input.FilePath.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.SizeKb), u => u.SizeKb.Contains(input.SizeKb.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.SizeInfo), u => u.SizeInfo.Contains(input.SizeInfo.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Url), u => u.Url.Contains(input.Url.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.FileMd5), u => u.FileMd5.Contains(input.FileMd5.Trim()))
            .Select<SysFileOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加李兴文
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddSysFileInput input)
    {
        var entity = input.Adapt<SysFile>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除李兴文
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteSysFileInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新李兴文
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateSysFileInput input)
    {
        var entity = input.Adapt<SysFile>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取李兴文
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<SysFile> Detail([FromQuery] QueryByIdSysFileInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取李兴文列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<SysFileOutput>> List([FromQuery] SysFileInput input)
    {
        return await _rep.AsQueryable().Select<SysFileOutput>().ToListAsync();
    }





}

