using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Haochen.Kingdee.CDP.Base;

/// <summary>
/// 通用业务基类
/// </summary>
public class BaseEntity
{
    /// <summary>
    /// ID,在api中用不到,在建与数据库关系时需要
    /// </summary>
    [JsonIgnore]
    public string FID { get; set; }

    /// <summary>
    /// 业务编码
    /// </summary>
    public virtual string FNumber { get; set; }

    /// <summary>
    /// 业务名称
    /// </summary>
    public virtual string FName { get; set; }
}
