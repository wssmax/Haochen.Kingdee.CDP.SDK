using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haochen.Kingdee.CDP.Base;
using Microsoft.VisualBasic;

namespace Haochen.Kingdee.CDP.Services
{
    /// <summary>
    /// 部门相关业务服务
    /// </summary>
    public class DepartmentService : BaseService
    {
        public DepartmentService()
        {
            FormID = "BD_Department";
        }

        /// <summary>
        /// 查询部门列表
        /// </summary>
        /// <returns></returns>
        public Task<List<BaseEntity>> BillQuery(int organId)
        {
            var fieldKeys = new List<string>();
            GetPublicPropertyNames(typeof(BaseEntity), fieldKeys);
            QueryRequest request = new()
            {
                FormID = FormID,
                FieldKeys = string.Join(",", fieldKeys),
                FilterString = $"FUseOrgID='{organId}' and FFORBIDSTATUS='A'",
            };
            return BillQuery<BaseEntity>(request);
        }
    }
}
