using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haochen.Kingdee.CDP.Base;

/// <summary>
/// 审核 单据实体
/// </summary>
public class AuditRequest : MultiRequest
{
    /// <summary>
    /// 交互标志集合，字符串类型，分号分隔，格式："flag1;flag2;..."
    /// （非必录） 例如（允许负库存标识：STK_InvCheckResult）
    /// </summary>
    public string InterationFlags { get; set; }

    /// <summary>
    /// 使用者组织内码（非必录）
    /// </summary>
    public int UseOrgId { get; set; }

    /// <summary>
    /// 是否检验单据关联运行中的工作流实例，布尔类型，默认true（非必录）
    /// </summary>
    public bool IsVerifyProcInst { get; set; } = true;

    /// <summary>
    /// 是否允许忽略交互，布尔类型，默认true（非必录）
    /// </summary>
    public bool IgnoreInterationFlag { get; set; } = true;

    /// <summary>
    /// 是否应用单据参数设置分批处理，默认false
    /// </summary>
    public bool UseBatControlTimes { get; set; }
}
