using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haochen.Kingdee.CDP.Base;

/// <summary>
/// 单记录查询对象
/// </summary>
public class SingleRequest
{
    /// <summary>
    /// 创建者组织内码（非必录）
    /// </summary>
    public int CreateOrgId { get; set; }

    /// <summary>
    /// 单据编码（使用编码时必录）
    /// </summary>
    public string Number { get; set; }

    /// <summary>
    /// 单据内码（使用内码时必录）
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// 单据体是否按序号排序，默认false
    /// </summary>
    public bool IsSortBySeq { get; set; }
}
