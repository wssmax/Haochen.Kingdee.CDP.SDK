using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haochen.Kingdee.CDP.Base;

/// <summary>
/// 支持多选的实体请求对象
/// </summary>
public abstract class MultiRequest
{
    /// <summary>
    /// 创建者组织内码（非必录）
    /// </summary>
    public int CreateOrgId { get; set; }

    /// <summary>
    /// 单据编码集合，数组类型，格式：[No1,No2,...]（使用编码时必录）
    /// </summary>
    public List<string> Numbers { get; set; } = [];

    /// <summary>
    /// 单据内码集合，字符串类型，格式："Id1,Id2,..."（使用内码时必录）
    /// </summary>
    public string Ids { get; set; }

    /// <summary>
    /// 是否启用网控，布尔类型，默认false（非必录）
    /// </summary>
    public bool NetworkCtrl { get; set; }
}
