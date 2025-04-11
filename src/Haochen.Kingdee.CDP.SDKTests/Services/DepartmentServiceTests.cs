using Microsoft.VisualStudio.TestTools.UnitTesting;
using Haochen.Kingdee.CDP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haochen.Kingdee.CDP.Services.Tests
{
    [TestClass()]
    public class DepartmentServiceTests
    {
        [TestMethod()]
        public void BillQueryTest()
        {
            DepartmentService service = new();
            var result = service.BillQuery(100039).Result;
            Assert.IsNotNull(result);
        }
    }
}