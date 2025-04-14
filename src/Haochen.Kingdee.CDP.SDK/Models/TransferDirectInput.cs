using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haochen.Kingdee.CDP.Base;

namespace Haochen.Kingdee.CDP.Models;

public class TransferDirectInput : KingDeeInput<TransferDirectModel> { }

/// <summary>
/// 直接调拨单
/// </summary>
public partial class TransferDirectModel
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
    public BaseEntity FBillTypeID { get; set; }

    /// <summary>
    /// 日期
    /// </summary>
    public DateTime? FDate { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string FNote { get; set; }

    /// <summary>
    /// 单据分录
    /// </summary>
    public List<TransferDirectEntry> FBillEntry { get; set; }
}

/// <summary>
/// 单据分录
/// </summary>
public partial class TransferDirectEntry
{
    /// <summary>
    /// 分录ID
    /// </summary>
    public int FEntryID { get; set; }

    /// <summary>
    /// 物料ID
    /// </summary>
    public BaseEntity FMaterialID { get; set; }

    /// <summary>
    /// 数量
    /// </summary>
    public double FQty { get; set; }

    /// <summary>
    /// 批号
    /// </summary>
    public BaseEntity FLot { get; set; }

    /// <summary>
    /// 源仓库ID
    /// </summary>
    public BaseEntity FSrcStockID { get; set; }

    /// <summary>
    /// 源仓库位置
    /// </summary>
    public StockLocID FSrcStockLocID { get; set; }

    /// <summary>
    /// 目标仓库ID
    /// </summary>
    public BaseEntity FDestStockID { get; set; }

    /// <summary>
    /// 目标仓库位置
    /// </summary>
    public StockLocID FDestStockLocID { get; set; }

    /// <summary>
    /// 分录备注
    /// </summary>
    public string FNoteEntry { get; set; }

    /// <summary>
    /// 源单据编号
    /// </summary>
    public string FSrcBillNo { get; set; }

    /// <summary>
    /// 是否赠品
    /// </summary>
    public bool FISFREE { get; set; }
}
