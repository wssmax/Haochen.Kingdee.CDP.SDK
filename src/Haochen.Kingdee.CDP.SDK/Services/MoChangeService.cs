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
    /// 生产订单变更服务
    /// </summary>
    public class MoChangeService : BaseService
    {
        public MoChangeService()
        {
            FormID = "PRD_MOChange";
        }

        /// <summary>
        /// 创建和修改生产订单变更
        /// </summary>
        /// <param name="entity"></param>
        public Task<ResponseResult> SaveAsync(MoChangeInput entity)
        {
            return base.SaveAsync(entity);
        }

    }
}
