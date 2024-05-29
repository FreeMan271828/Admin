namespace Admin.NET.Application;

    /// <summary>
    /// 代码生成字段配置表输出参数
    /// </summary>
    public class SysCodeGenConfigDto
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// 主表Id
        /// </summary>
        public long CodeGenId { get; set; }
        
        /// <summary>
        /// 字段名称
        /// </summary>
        public string ColumnName { get; set; }
        
        /// <summary>
        /// 属性名称
        /// </summary>
        public string PropertyName { get; set; }
        
        /// <summary>
        /// 字段数据长度
        /// </summary>
        public long ColumnLength { get; set; }
        
        /// <summary>
        /// 字段描述
        /// </summary>
        public string? ColumnComment { get; set; }
        
        /// <summary>
        /// NET数据类型
        /// </summary>
        public string? NetType { get; set; }
        
        /// <summary>
        /// 作用类型
        /// </summary>
        public string? EffectType { get; set; }
        
        /// <summary>
        /// 外键实体名称
        /// </summary>
        public string? FkEntityName { get; set; }
        
        /// <summary>
        /// 外键表名称
        /// </summary>
        public string? FkTableName { get; set; }
        
        /// <summary>
        /// 外键显示字段
        /// </summary>
        public string? FkColumnName { get; set; }
        
        /// <summary>
        /// 外键显示字段.NET类型
        /// </summary>
        public string? FkColumnNetType { get; set; }
        
        /// <summary>
        /// 字典编码
        /// </summary>
        public string? DictTypeCode { get; set; }
        
        /// <summary>
        /// 列表是否缩进
        /// </summary>
        public string? WhetherRetract { get; set; }
        
        /// <summary>
        /// 是否必填
        /// </summary>
        public string? WhetherRequired { get; set; }
        
        /// <summary>
        /// 是否可排序
        /// </summary>
        public string? WhetherSortable { get; set; }
        
        /// <summary>
        /// 是否是查询条件
        /// </summary>
        public string? QueryWhether { get; set; }
        
        /// <summary>
        /// 查询方式
        /// </summary>
        public string? QueryType { get; set; }
        
        /// <summary>
        /// 列表显示
        /// </summary>
        public string? WhetherTable { get; set; }
        
        /// <summary>
        /// 增改
        /// </summary>
        public string? WhetherAddUpdate { get; set; }
        
        /// <summary>
        /// 主键
        /// </summary>
        public string? ColumnKey { get; set; }
        
        /// <summary>
        /// 数据库中类型
        /// </summary>
        public string? DataType { get; set; }
        
        /// <summary>
        /// 是否通用字段
        /// </summary>
        public string? WhetherCommon { get; set; }
        
        /// <summary>
        /// 显示文本字段
        /// </summary>
        public string? DisplayColumn { get; set; }
        
        /// <summary>
        /// 选中值字段
        /// </summary>
        public string? ValueColumn { get; set; }
        
        /// <summary>
        /// 父级字段
        /// </summary>
        public string? PidColumn { get; set; }
        
        /// <summary>
        /// 排序
        /// </summary>
        public long OrderNo { get; set; }
        
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
