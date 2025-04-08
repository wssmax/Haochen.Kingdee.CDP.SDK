using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haochen.Kingdee.CDP.Base;

/// <summary>
/// 行操作请求参数
/// </summary>
public class RowOperateRequest : MultiRequest
{
    /// <summary>
    /// 单据内码与分录内码对应关系的集合，字符串类型，
    /// 格式：[{"Id":"Id1","EntryIds":"EntryId1,EntryId2,..."}]
    /// (使用分录状态转换时必录)
    /// </summary>
    public List<IdWithEntryId> PkEntryIds { get; set; } = [];

    /// <summary>
    /// 使用组织ID
    /// </summary>
    public int UseOrgId { get; set; }

    /// <summary>
    /// 忽略交互标志
    /// </summary>
    public bool IgnoreInterationFlag { get; set; } = true;
}
