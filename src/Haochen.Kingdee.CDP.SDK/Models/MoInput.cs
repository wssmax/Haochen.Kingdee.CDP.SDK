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
public class MoModel
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
    /// 单据类型 (必填项)
    /// </summary>
    public BaseEntity FBillType { get; set; }

    /// <summary>
    /// 生产组织 (必填项)
    /// </summary>
    public BaseEntity FPrdOrgID { get; set; }

    /// <summary>
    /// 计划组
    /// </summary>
    public BaseEntity FWorkGroupId { get; set; }

    /// <summary>
    /// 计划员
    /// </summary>
    public BaseEntity FPlannerID { get; set; }

    /// <summary>
    /// 单据日期 (必填项)
    /// </summary>
    public DateTime? FDate { get; set; }

    /// <summary>
    /// 计划版本号
    /// </summary>
    public string Fjhversion { get; set; }

    /// <summary>
    /// 跟踪管理模式
    /// </summary>
    public string Ftrackmgrmode { get; set; }

    /// <summary>
    /// 来自跳层
    /// </summary>
    public int Fisfromskip { get; set; }

    /// <summary>
    /// 明细列表
    /// </summary>
    public List<MoEntry> FTreeEntity { get; set; } = [];

    /// <summary>
    /// 备注
    /// </summary>
    public string FDescription { get; set; }
}

/// <summary>
/// 生产订单明细
/// </summary>
public class MoEntry
{
    /// <summary>
    /// 实体主键
    /// </summary>
    public int FEntryId { get; set; }

    /// <summary>
    /// 物料编码 (必填项)
    /// </summary>
    public BaseEntity FMaterialId { get; set; }

    /// <summary>
    /// 数量
    /// </summary>
    public decimal FQty { get; set; }

    /// <summary>
    /// 计划开工时间 (必填项)
    /// </summary>
    public DateTime FPlanStartDate { get; set; }

    /// <summary>
    /// 计划完工时间 (必填项)
    /// </summary>
    public DateTime FPlanFinishDate { get; set; }

    /// <summary>
    /// 批号
    /// </summary>
    public BaseEntity FLot { get; set; }

    /// <summary>
    /// 项目编号
    /// </summary>
    public BaseEntity FProjectID { get; set; }

    /// <summary>
    /// BOM版本
    /// </summary>
    public BaseEntity FBomId { get; set; }

    /// <summary>
    /// 生产车间
    /// </summary>
    public BaseEntity FWorkShopID { get; set; }
}
