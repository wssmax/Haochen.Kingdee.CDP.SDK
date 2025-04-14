using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haochen.Kingdee.CDP.Base;
using Haochen.Kingdee.CDP.Models;

namespace Haochen.Kingdee.CDP.Services
{
    public class PickMtrlService : BaseService
    {
        public PickMtrlService()
        {
            FormID = "PRD_PickMtrl";
        }

        /// <summary>
        /// 创建和修改生产领料单
        /// 生产领料单源自 生产用料清单
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<ResponseResult> SaveAsync(PickMtrlInput entity)
        {
            return base.SaveAsync(entity);
        }
    }
}
