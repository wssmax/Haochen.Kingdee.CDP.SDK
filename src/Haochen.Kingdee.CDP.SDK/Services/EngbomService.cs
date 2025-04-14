using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haochen.Kingdee.CDP.Base;
using Haochen.Kingdee.CDP.Models;

namespace Haochen.Kingdee.CDP.Services
{
    /// <summary>
    /// 物料清单服务
    /// </summary>
    public class EngbomService : BaseService
    {
        public EngbomService()
        {
            FormID = "ENG_BOM";
        }

        /// <summary>
        /// 创建和修改采购申请单
        /// </summary>
        /// <param name="entity"></param>
        public Task<ResponseResult> SaveAsync(EngbomInput entity)
        {
            return base.SaveAsync(entity);
        }
    }
}
