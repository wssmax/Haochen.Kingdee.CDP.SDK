using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haochen.Kingdee.CDP.Base;

namespace Haochen.Kingdee.CDP.Services;

public class BillTypeService : BaseService
{
    public BillTypeService()
    {
        FormID = "BOS_BillType";
    }

    /// <summary>
    /// 查询单据类型列表
    /// 根据业务名称查询业务类型
    /// </summary>
    /// <returns></returns>
    public Task<List<BaseEntity>> BillQuery(string billType)
    {
        var fieldKeys = new List<string>();
        GetPublicPropertyNames(typeof(BaseEntity), fieldKeys);
        QueryRequest request = new()
        {
            FormID = FormID,
            FieldKeys = string.Join(",", fieldKeys),
            OrderString = "FISDEFAULT DESC",
            FilterString = $"FBILLFORMID.FNumber='{billType}' and FFORBIDSTATUS='A'",
        };
        return BillQuery<BaseEntity>(request);
    }
}
