using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Haochen.Kingdee.CDP.Base;
using Haochen.Kingdee.CDP.Models;
using Haochen.Kingdee.CDP.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Haochen.Kingdee.CDP.Services.Tests
{
    [TestClass()]
    public class MoServiceTests
    {
        [TestMethod()]
        public void BillQueryTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public async Task SaveAsyncTest1()
        {
            var service = new MoService();
            var entity = new MoInput
            {
                Model = new MoModel
                {
                    FTreeEntity =
                    [
                        new MoEntry
                        {
                            FMaterialID = new BaseEntity("s6"),
                            FWorkShopID = new BaseEntity("BM000005"),
                            FQty = 15.0, // 数量
                            FPlanStartDate = DateTime.Now.AddHours(1),
                            FPlanFinishDate = DateTime.Now.AddHours(2),
                        },
                    ],
                },
            };
            var response = await service.SaveAsync(entity);

            Assert.IsTrue(response.ResponseStatus.IsSuccess);
            entity.Model.FID = int.Parse(response.Id);
            string fnumber = response.Number ?? "MO000109";

            response = await service.SaveAsync(entity);
            Assert.IsTrue(response.ResponseStatus.IsSuccess);

            SubmitRequest submit = new();
            submit.Numbers.Add(fnumber);
            response = await service.SubmitAsync(submit);
            Assert.IsTrue(response.ResponseStatus.IsSuccess);

            AuditRequest audit = new();
            audit.Numbers.Add(fnumber);
            response = await service.AuditAsync(audit);
            Assert.IsTrue(response.ResponseStatus.IsSuccess);
            RowOperateRequest operate = new();
            operate.Numbers.Add(fnumber);
            response = await service.ExcuteToStartAsync(operate);
            Assert.IsTrue(response.ResponseStatus.IsSuccess);
            response = await service.ExcuteToFinishAsync(operate);
            Assert.IsTrue(response.ResponseStatus.IsSuccess);
            response = await service.UndoToStartAsync(operate);
            Assert.IsTrue(response.ResponseStatus.IsSuccess);
            response = await service.UndoToReleaseAsync(operate);
            Assert.IsTrue(response.ResponseStatus.IsSuccess);
            response = await service.UndoToPlanConfirmAsync(operate);
            Assert.IsTrue(response.ResponseStatus.IsSuccess);
            response = await service.UnAuditAsync(audit);
            Assert.IsTrue(response.ResponseStatus.IsSuccess);
            DeleteRequest delete = new();
            delete.Numbers.Add(fnumber);
            response = await service.DeleteAsync(delete);
            Assert.IsTrue(response.ResponseStatus.IsSuccess);
        }
    }
}
