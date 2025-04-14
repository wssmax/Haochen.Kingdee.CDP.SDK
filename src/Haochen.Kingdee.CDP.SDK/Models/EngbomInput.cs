using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haochen.Kingdee.CDP.Base;

namespace Haochen.Kingdee.CDP.Models;

/// <summary>
/// 物料清单输入请求
/// </summary>
public class EngbomInput : KingDeeInput<EngbomModel> { }

/// <summary>
/// 物料清单主记录
/// 模型值包含必要的字段,其他如联副产品可以自行扩展
/// </summary>
public partial class EngbomModel
{
    /// <summary>
    /// 实体主键
    /// </summary>
    public int FID { get; set; }

    /// <summary>
    /// 父项物料编码
    /// </summary>
    public BaseEntity FMaterialID { get; set; }

    /// <summary>
    /// 子项明细
    /// </summary>
    public List<EngbomEntry> FTreeEntity { get; set; }
}

/// <summary>
/// 物料清单明细项
/// </summary>
public partial class EngbomEntry
{
    /// <summary>
    /// 实体主键
    /// </summary>
    public int FEntryID { get; set; }

    /// <summary>
    /// 项次
    /// </summary>
    public int FReplaceGroup { get; set; }

    /// <summary>
    /// 子项物料编码
    /// </summary>
    public BaseEntity FMaterialIDchild { get; set; }

    /// <summary>
    /// 用量:分子
    /// </summary>
    public double FNumerator { get; set; }

    /// <summary>
    /// 用量:分母
    /// </summary>
    public double FDenominator { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string FMEMO { get; set; }

    /// <summary>
    /// 生效日期
    /// </summary>
    public DateTime? FEffectDate { get; set; }
}
