using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haochen.Kingdee.CDP.Base;
using Haochen.Kingdee.CDP.Models;

namespace Haochen.Kingdee.CDP.Services;

/// <summary>
/// 直接调拨单业务处理
/// </summary>
public class TransferDirectService : BaseService
{
    public TransferDirectService()
    {
        FormID = "STK_TransferDirect";
    }

    /// <summary>
    /// 保存直接调拨单
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<ResponseResult> SaveAsync(TransferDirectInput entity)
    {
        return base.SaveAsync(entity);
    }
}
