namespace Admin.NET.Application;

    /// <summary>
    /// 李兴文输出参数
    /// </summary>
    public class SysFileDto
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public long Id { get; set; }
        
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
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
        
        /// <summary>
        /// 创建者Id
        /// </summary>
        public long? CreateUserId { get; set; }
        
        /// <summary>
        /// 创建者姓名
        /// </summary>
        public string? CreateUserName { get; set; }
        
        /// <summary>
        /// 修改者Id
        /// </summary>
        public long? UpdateUserId { get; set; }
        
        /// <summary>
        /// 修改者姓名
        /// </summary>
        public string? UpdateUserName { get; set; }
        
        /// <summary>
        /// 软删除
        /// </summary>
        public bool IsDelete { get; set; }
        
    }
