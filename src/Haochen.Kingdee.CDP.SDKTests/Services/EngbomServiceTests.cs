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
    public class EngbomServiceTests
    {
        [TestMethod()]
        public void SaveAsyncTest()
        {
            EngbomService service = new();
            EngbomInput input = new()
            {
                Model = new EngbomModel()
                {
                    FMaterialID = new BaseEntity("1.02"),
                    FTreeEntity =
                    [
                        new EngbomEntry()
                        {
                            FMaterialIDchild = new BaseEntity("1.02.001.0006"),
                            FNumerator = 1,
                            FDenominator = 1,
                            FEffectDate = DateTime.Now,
                        },
                    ],
                },
            };
            var result = service.SaveAsync(input).Result;
            Assert.IsTrue(result.ResponseStatus.IsSuccess);
        }
    }
}
