using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haochen.Kingdee.CDP.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Haochen.Kingdee.CDP.Services.Tests
{
    [TestClass()]
    public class BillTypeServiceTests
    {
        [TestMethod()]
        public async Task BillQueryTest()
        {
            BillTypeService billTypeService = new BillTypeService();
            var result = await billTypeService.BillQuery("PRD_MO");
            Assert.IsNotNull(result);
        }
    }
}
