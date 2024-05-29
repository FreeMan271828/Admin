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
 * 前端用户表
 */
[SugarTable(null, "前端用户表")]
[SysTable]
public class FrontEndUser
{
    //前端用户id，主键，自增
    [SugarColumn(ColumnName = "Id", ColumnDescription = "主键", IsPrimaryKey = true, IsIdentity = true)]
    public int Id { get; set; }
     
    //前端用户姓名,不为空，最长255
    [SugarColumn(ColumnName = "userName", ColumnDescription ="前端用户姓名")]
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    //前端用户密码，不为空
    [SugarColumn(ColumnName = "userPassword", ColumnDescription ="前端用户密码")]
    [Required]
    public string UserPassword {  get; set; }

    //前端用户备注，可以为空
    [SugarColumn(ColumnName ="remark",ColumnDescription ="前端用户备注",IsNullable =true)]
    public string Remark { get; set; }
    
    //前端用户状态
    [SugarColumn(ColumnName = "status",ColumnDescription = "0表示弃用，1表示弃用",IsNullable = false)]
    public int Status { get; set; }
}
