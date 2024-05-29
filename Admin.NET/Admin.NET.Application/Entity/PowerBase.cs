// 大名科技（天津）有限公司版权所有  电话：18020030720  QQ：515096995
//
// 此源代码遵循位于源代码树根目录中的 LICENSE 文件的许可证

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Core;
/**
 * 权限基础表
 */
[SugarTable(null, "权限基础表")]
[SysTable]
public class PowerBase
{
    //权限id，主键，自增
    [SugarColumn(ColumnName = "Id", ColumnDescription = "主键", IsPrimaryKey = true, IsIdentity = true)]
    public int Id { get; set; }

    //权限名称，不为空
    [SugarColumn(ColumnName = "name", ColumnDescription = "权限名称")]
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }
    
    //权限状态
    [SugarColumn(ColumnName = "status",ColumnDescription = "0表示弃用，1表示弃用",IsNullable = false)]
    public int Status { get; set; }
}
