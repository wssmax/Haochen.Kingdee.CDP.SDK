using Haochen.Kingdee.CDP.Base;
using Haochen.Kingdee.CDP.Models;

namespace Haochen.Kingdee.CDP.Services.Tests
{
    [TestClass()]
    public class TransferDirectServiceTests
    {
        [TestMethod()]
        public async Task SaveAsyncTest()
        {
            TransferDirectService service = new();
            TransferDirectInput input = new()
            {
                Model = new TransferDirectModel
                {
                    FBillEntry =
                    [
                        new TransferDirectEntry
                        {
                            FMaterialID = new BaseEntity("1.02.001.0005"),
                            FSrcStockID = new BaseEntity("CK024"),
                            FDestStockID = new BaseEntity("CK007"),
                            FSrcStockLocID = new StockLocID("a1.02.01", "FSrcStockLocID"),
                            FDestStockLocID = new StockLocID("a1.02.01", "FDestStockLocID"),
                            FQty = 1,
                        },
                    ],
                },
            };
            var result = await service.SaveAsync(input);
            Assert.IsTrue(result.ResponseStatus.IsSuccess);
        }
    }
}
