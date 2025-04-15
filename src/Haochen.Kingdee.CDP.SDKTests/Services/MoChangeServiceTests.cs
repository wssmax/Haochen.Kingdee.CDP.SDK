using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haochen.Kingdee.CDP.Base;
using Haochen.Kingdee.CDP.Models;
using Haochen.Kingdee.CDP.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Haochen.Kingdee.CDP.Services.Tests
{
    [TestClass()]
    public class MoChangeServiceTests
    {
        [TestMethod()]
        public void SaveAsyncTest()
        {
            MoChangeService service = new();
            MoChangeInput input = new()
            {
                Model =
                {
                    FEntity =
                    [
                        new MoChangeEntry
                        {
                            FChangeType = "2", //变更前
                            FMoEntryId = 100368,
                            FMoId = 100274,
                            FMoNo = "PRD25.000173",
                            FPlanStartDate = DateTime.Now.AddDays(1),
                            FPlanFinishDate = DateTime.Now.AddDays(10),
                            FQty = 147,
                            FMaterialId = new BaseEntity("s6pro"),
                        },
                        new MoChangeEntry
                        {
                            FChangeType = "3", //变更后
                            FMoEntryId = 100368,
                            FMoId = 100274,
                            FMoNo = "PRD25.000173",
                            FQty = 100,
                            FPlanStartDate = DateTime.Now.AddDays(1),
                            FPlanFinishDate = DateTime.Now.AddDays(10),
                            FMaterialId = new BaseEntity("s6pro"),
                        },
                        new MoChangeEntry
                        {
                            FChangeType = "1", //新增
                            FMoEntryId = 0,
                            FMoId = 100274,
                            FMoNo = "PRD25.000173",
                            FPlanStartDate = DateTime.Now.AddDays(1),
                            FPlanFinishDate = DateTime.Now.AddDays(10),
                            FQty = 100,
                            FMaterialId = new BaseEntity("s6pro"),
                        },
                    ],
                },
            };
            var result = service.SaveAsync(input).Result;
            Assert.IsTrue(result.ResponseStatus.IsSuccess);
        }
    }
}
