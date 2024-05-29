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
 *用户权限表
 */
[SugarTable(null, "用户权限表")]
[SysTable]
public class UserPower
{
    [SugarColumn(ColumnName ="userId",ColumnDescription ="用户Id",IsPrimaryKey =true)]
    [Required]
    public int UserId { get; set; }

    [SugarColumn(ColumnName ="powerId",ColumnDescription ="权限Id",IsPrimaryKey =true)]
    [Required]
    public int PowerId {  get; set; }
    
    //用户权限状态，当用户状态和权限状态全为1时才可以设为1，否则为0
    [SugarColumn(ColumnName = "status",ColumnDescription = "0表示弃用，1表示弃用",IsNullable = false)]
    public int Status { get; set; }

    //导航属性
    [Navigate(NavigateType.OneToOne,"Id")]//指定外键关系
    public FrontEndUser FrontEndUser{ get; set; }

    [Navigate(NavigateType.OneToOne, "Id")]//指定外键关系
    public PowerBase PowerBase { get; set; }
}
