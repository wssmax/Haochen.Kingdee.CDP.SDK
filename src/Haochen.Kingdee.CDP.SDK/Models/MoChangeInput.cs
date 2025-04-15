using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haochen.Kingdee.CDP.Base;

namespace Haochen.Kingdee.CDP.Models;

/// <summary>
/// 生产订单变更单
/// </summary>
public class MoChangeInput : KingDeeInput<MoChangeModel> { }

/// <summary>
/// 生产订单主表
/// </summary>
public class MoChangeModel
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
    /// 单据状态
    /// </summary>
    public string FDocumentStatus { get; set; }

    /// <summary>
    /// 单据类型 (必填项)
    /// </summary>
    public BaseEntity FBillType { get; set; } // 必填

    /// <summary>
    /// 生产组织 (必填项)
    /// </summary>
    public BaseEntity FPrdOrgID { get; set; } // 必填

    /// <summary>
    /// 单据日期 (必填项)
    /// </summary>
    public DateTime? FDate { get; set; } // 必填

    /// <summary>
    /// 明细列表
    /// </summary>
    public List<MoChangeEntry> FEntity { get; set; } = [];

    /// <summary>
    /// 备注
    /// </summary>
    public string FDescription { get; set; }

    /// <summary>
    /// 变更原因
    /// </summary>
    public BaseEntity FChangeReason { get; set; }
}

/// <summary>
/// 生产订单明细
/// </summary>
public class MoChangeEntry
{
    /// <summary>
    /// 生产订单编号 (必填项)
    /// </summary>
    public string FMoNo { get; set; }

    /// <summary>
    /// 生产订单内码
    /// </summary>
    public int FMoId { get; set; }

    /// <summary>
    /// 生产订单分录内码
    /// </summary>
    public int FMoEntryId { get; set; }

    /// <summary>
    /// 变更类型
    /// </summary>
    public string FChangeType { get; set; }

    /// <summary>
    /// 生产订单行号
    /// </summary>
    public int? FMoEntrySeq { get; set; }

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
    public BaseEntity FUnitID { get; set; }
}
