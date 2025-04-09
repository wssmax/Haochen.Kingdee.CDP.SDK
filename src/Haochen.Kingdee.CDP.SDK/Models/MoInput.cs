using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haochen.Kingdee.CDP.Base;

namespace Haochen.Kingdee.CDP.Models;

/// <summary>
/// 生产订单输入类
/// </summary>
public class MoInput : KingDeeInput<MoModel> { }

/// <summary>
/// 生产订单主表
/// </summary>
public partial class MoModel
{
    /// <summary>
    /// 实体主键
    /// </summary>
    public int FID { get; set; }

    /// <summary>
    /// 单据编号
    /// </summary>
    public string FBillNo { get; set; }

    /// <summary>
    /// 单据类型
    /// </summary>
    public BaseEntity FBillType { get; set; }

    /// <summary>
    /// 生产组织
    /// </summary>
    public BaseEntity FPrdOrgID { get; set; }

    /// <summary>
    /// 计划组
    /// </summary>
    public BaseEntity FWorkGroupID { get; set; }

    /// <summary>
    /// 计划员
    /// </summary>
    public BaseEntity FPlannerID { get; set; }

    /// <summary>
    /// 单据日期
    /// </summary>
    public DateTime? FDate { get; set; }

    /// <summary>
    /// 明细列表
    /// </summary>
    public List<MoEntry> FTreeEntity { get; set; } = [];

    /// <summary>
    /// 备注
    /// </summary>
    public string FDescription { get; set; } = "api创建";
}

/// <summary>
/// 生产订单明细
/// </summary>
public partial class MoEntry
{
    /// <summary>
    /// 实体主键
    /// </summary>
    public int FEntryID { get; set; }

    /// <summary>
    /// 物料编码
    /// </summary>
    public BaseEntity FMaterialID { get; set; }

    /// <summary>
    /// 数量
    /// </summary>
    public double FQty { get; set; }

    /// <summary>
    /// 计划开工时间
    /// </summary>
    public DateTime FPlanStartDate { get; set; }

    /// <summary>
    /// 计划完工时间
    /// </summary>
    public DateTime FPlanFinishDate { get; set; }

    /// <summary>
    /// 批号
    /// </summary>
    public BaseEntity FLot { get; set; }

    /// <summary>
    /// BOM版本
    /// </summary>
    public BaseEntity FBomID { get; set; }

    /// <summary>
    /// 生产车间
    /// </summary>
    public BaseEntity FWorkShopID { get; set; }
}
