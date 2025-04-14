using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haochen.Kingdee.CDP.Base;

namespace Haochen.Kingdee.CDP.Models;

/// <summary>
/// 生产领料单
/// </summary>
public class PickMtrlInput : KingDeeInput<PickMtrlModal> { }

/// <summary>
/// 生产领料单
/// </summary>
public partial class PickMtrlModal
{
    /// <summary>
    /// 实体主键
    /// </summary>
    public int FID { get; set; }

    /// <summary>
    /// 单据分录
    /// </summary>
    public List<PickMtrlEntry> FEntity { get; set; }
}

/// <summary>
/// 生产领料单明细
/// </summary>
/// <summary>
/// 生产领料单明细
/// </summary>
public partial class PickMtrlEntry
{
    /// <summary>
    /// 分录ID
    /// </summary>
    public int FEntryID { get; set; }

    /// <summary>
    /// 用料清单分录内码
    /// </summary>
    public int FPPBomEntryId { get; set; }

    /// <summary>
    /// 用料清单编号
    /// </summary>
    public string FPPBomBillNo { get; set; }

    /// <summary>
    /// 生产订单分录内码
    /// </summary>
    public int FMoEntryId { get; set; }

    /// <summary>
    /// 生产订单内码
    /// </summary>
    public int FMoId { get; set; }

    /// <summary>
    /// 生产订单编号
    /// </summary>
    public string FMoBillNo { get; set; }

    /// <summary>
    /// 单位ID
    /// </summary>
    public BaseEntity FUnitId { get; set; }

    /// <summary>
    /// 物料ID
    /// </summary>
    public BaseEntity FMaterialId { get; set; }

    /// <summary>
    /// 实发数量
    /// </summary>
    public double FActualQty { get; set; }

    /// <summary>
    /// 仓库ID
    /// </summary>
    public BaseEntity FStockId { get; set; }

    /// <summary>
    /// 仓位
    /// </summary>
    public StockLocID FStockLocId { get; set; }

    /// <summary>
    /// 批号
    /// </summary>
    public BaseEntity FLot { get; set; }

    /// <summary>
    /// 车间
    /// </summary>
    public BaseEntity FEntryWorkShopId { get; set; }

    /// <summary>
    /// 父项物料ID
    /// </summary>
    public BaseEntity FParentMaterialId { get; set; }

    /// <summary>
    /// 申请数量
    /// </summary>
    public double FAppQty { get; set; }

    /// <summary>
    /// 基本单位实发数量
    /// </summary>
    public double FBaseActualQty { get; set; }

    /// <summary>
    /// 主库存基本单位实发数量
    /// </summary>
    public double FBaseStockActualQty { get; set; }

    /// <summary>
    /// 主库存单位ID
    /// </summary>
    public BaseEntity FStockUnitId { get; set; }

    /// <summary>
    /// 基本单位ID
    /// </summary>
    public BaseEntity FBaseUnitId { get; set; }

    /// <summary>
    /// 产品货主
    /// </summary>
    public BaseEntity FParentOwnerId { get; set; }

    /// <summary>
    /// 货主
    /// </summary>
    public BaseEntity FOwnerId { get; set; }
}
