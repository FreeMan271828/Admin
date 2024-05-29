using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 李兴文基础输入参数
    /// </summary>
    public class SysFileBaseInput
    {
        /// <summary>
        /// 提供者
        /// </summary>
        public virtual string? Provider { get; set; }
        
        /// <summary>
        /// 仓储名称
        /// </summary>
        public virtual string? BucketName { get; set; }
        
        /// <summary>
        /// 文件名称
        /// </summary>
        public virtual string? FileName { get; set; }
        
        /// <summary>
        /// 文件后缀
        /// </summary>
        public virtual string? Suffix { get; set; }
        
        /// <summary>
        /// 存储路径
        /// </summary>
        public virtual string? FilePath { get; set; }
        
        /// <summary>
        /// 文件大小KB
        /// </summary>
        public virtual string? SizeKb { get; set; }
        
        /// <summary>
        /// 文件大小信息
        /// </summary>
        public virtual string? SizeInfo { get; set; }
        
        /// <summary>
        /// 外链地址
        /// </summary>
        public virtual string? Url { get; set; }
        
        /// <summary>
        /// 文件MD5
        /// </summary>
        public virtual string? FileMd5 { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime? CreateTime { get; set; }
        
        /// <summary>
        /// 更新时间
        /// </summary>
        public virtual DateTime? UpdateTime { get; set; }
        
        /// <summary>
        /// 创建者Id
        /// </summary>
        public virtual long? CreateUserId { get; set; }
        
        /// <summary>
        /// 创建者姓名
        /// </summary>
        public virtual string? CreateUserName { get; set; }
        
        /// <summary>
        /// 修改者Id
        /// </summary>
        public virtual long? UpdateUserId { get; set; }
        
        /// <summary>
        /// 修改者姓名
        /// </summary>
        public virtual string? UpdateUserName { get; set; }
        
        /// <summary>
        /// 软删除
        /// </summary>
        public virtual bool IsDelete { get; set; }
        
    }

    /// <summary>
    /// 李兴文分页查询输入参数
    /// </summary>
    public class SysFileInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 提供者
        /// </summary>
        public string? Provider { get; set; }
        
        /// <summary>
        /// 仓储名称
        /// </summary>
        public string? BucketName { get; set; }
        
        /// <summary>
        /// 文件名称
        /// </summary>
        public string? FileName { get; set; }
        
        /// <summary>
        /// 文件后缀
        /// </summary>
        public string? Suffix { get; set; }
        
        /// <summary>
        /// 存储路径
        /// </summary>
        public string? FilePath { get; set; }
        
        /// <summary>
        /// 文件大小KB
        /// </summary>
        public string? SizeKb { get; set; }
        
        /// <summary>
        /// 文件大小信息
        /// </summary>
        public string? SizeInfo { get; set; }
        
        /// <summary>
        /// 外链地址
        /// </summary>
        public string? Url { get; set; }
        
        /// <summary>
        /// 文件MD5
        /// </summary>
        public string? FileMd5 { get; set; }
        
    }

    /// <summary>
    /// 李兴文增加输入参数
    /// </summary>
    public class AddSysFileInput : SysFileBaseInput
    {
        /// <summary>
        /// 软删除
        /// </summary>
        [Required(ErrorMessage = "软删除不能为空")]
        public override bool IsDelete { get; set; }
        
    }

    /// <summary>
    /// 李兴文删除输入参数
    /// </summary>
    public class DeleteSysFileInput : BaseIdInput
    {
    }

    /// <summary>
    /// 李兴文更新输入参数
    /// </summary>
    public class UpdateSysFileInput : SysFileBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 李兴文主键查询输入参数
    /// </summary>
    public class QueryByIdSysFileInput : DeleteSysFileInput
    {

    }
