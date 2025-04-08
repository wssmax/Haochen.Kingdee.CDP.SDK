using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Haochen.Kingdee.CDP.Base;

/// <summary>
/// 主ID与明细ID集合
/// </summary>
public class IdWithEntryId
{
    public string Id { get; set; }

    public string EntryIds => string.Join(",", RowIds);

    [JsonIgnore]
    public List<int> RowIds { get; set; } = [];
}
