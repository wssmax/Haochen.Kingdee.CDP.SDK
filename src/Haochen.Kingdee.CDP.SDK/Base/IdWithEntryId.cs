using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Haochen.Kingdee.CDP.Base;

/// <summary>
/// 主ID与明细ID集合
/// </summary>
public class IDWithEntryIDs
{
    public string Id { get; set; }

    public string EntryIds => string.Join(",", RowIds);

    [JsonIgnore]
    public List<int> RowIds { get; set; } = [];
}

/// <summary>
/// FID与FEntryID成对出现
/// </summary>
public class FIDwithEntryID
{
    /// <summary>
    /// 主表ID
    /// </summary>
    public int FID { get; set; }

    /// <summary>
    /// 明细Id
    /// </summary>
    public int FEntryID { get; set; }
}
