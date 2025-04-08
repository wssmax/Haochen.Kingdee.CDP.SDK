using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haochen.Kingdee.CDP.Base;

/// <summary>
/// 提交 实体对象
/// </summary>
public class SubmitRequest : MultiRequest
{
    /// <summary>
    /// 工作流发起员工岗位内码，整型（非必录） 注（员工身兼多岗时不传参默认取第一个岗位）
    /// </summary>
    public int SelectedPostId { get; set; }

    /// <summary>
    /// 使用者组织内码（非必录）
    /// </summary>
    public int UseOrgId { get; set; }

    /// <summary>
    /// 是否允许忽略交互，布尔类型，默认true（非必录）
    /// </summary>
    public bool IgnoreInterationFlag { get; set; } = true;
}
