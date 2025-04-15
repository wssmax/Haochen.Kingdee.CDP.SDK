using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haochen.Kingdee.CDP.Base;
using Haochen.Kingdee.CDP.Models;
using Haochen.Kingdee.CDP.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Haochen.Kingdee.CDP.Services.Tests;

[TestClass()]
public class PickMtrlServiceTests
{
    [TestMethod()]
    public void SaveAsyncTest()
    {
        PickMtrlService service = new();
        PickMtrlInput input = new()
        {
            Model = new PickMtrlModal()
            {
                FEntity =
                [
                    new PickMtrlEntry()
                    {
                        FMaterialId = new BaseEntity("2.1110005"),
                        FActualQty = 1,
                        FStockId = new BaseEntity("CK003"),
                        //FStockLocId = new StockLocID("a1.02.0"),
                        FPPBomEntryId = 101453,
                        FPPBomBillNo = "PPBOM00000258",
                        FMoEntryId = 100361,
                        FMoId = 100269,
                        FMoBillNo = "PRD25.000167-002",
                        //FLot = new BaseEntity("p2025040001"),
                        FParentMaterialId = new BaseEntity("s6pro"),
                        FAppQty = 1,
                        FBaseActualQty = 1,
                        FBaseStockActualQty = 1,
                        FStockUnitId = new BaseEntity("件"),
                        FBaseUnitId = new BaseEntity("件"),
                        FUnitId = new BaseEntity("件"),
                        FParentOwnerId = new BaseEntity("101.2"),
                        FOwnerId = new BaseEntity("101.2"),
                        FEntryWorkShopId = new BaseEntity("BM000002"),
                    },
                ],
            },
        };

        var result = service.SaveAsync(input).Result;
        Assert.IsTrue(result.ResponseStatus.IsSuccess);
    }
}
