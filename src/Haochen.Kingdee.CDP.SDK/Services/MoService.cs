using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haochen.Kingdee.CDP.Base;
using Haochen.Kingdee.CDP.Models;

namespace Haochen.Kingdee.CDP.Services;

/// <summary>
/// 生产订单服务类
/// 对应表:T_PRD_MO
/// </summary>
public class MoService : BaseService
{
    private readonly BillTypeService billTypeService = new();

    public MoService()
    {
        FormID = "PRD_MO";
    }

    /// <summary>
    /// 生产订单类型
    /// </summary>
    /// <returns></returns>
    public Task<List<BaseEntity>> BillTypeList()
    {
        return billTypeService.BillQuery(FormID);
    }

    /// <summary>
    /// 获取生产订单列表
    /// </summary>
    public Task<List<T>> BillQuery<T>(string where)
    {
        var fieldKeys = new List<string>();
        GetPublicPropertyNames(typeof(T), fieldKeys);
        QueryRequest query = new()
        {
            FormID = FormID,
            FieldKeys = string.Join(",", fieldKeys),
            FilterString = where,
            OrderString = "FId DESC",
        };
        return BillQuery<T>(query);
    }

    /// <summary>
    /// 创建和修改采购申请单
    /// </summary>
    /// <param name="entity"></param>
    public Task<ResponseResult> SaveAsync(MoInput entity)
    {
        return base.SaveAsync(entity);
    }

    /// <summary>
    /// 执行到计划确认
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<ResponseResult> ExcuteToPlanConfirm(RowOperateRequest entity)
    {
        return ExcuteOperationAsync("ToPlanConfirm", entity);
    }

    /// <summary>
    /// 执行到下达
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<ResponseResult> ExcuteToRelease(RowOperateRequest entity)
    {
        return ExcuteOperationAsync("ToRelease", entity);
    }

    /// <summary>
    /// 执行到开工
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<ResponseResult> ExcuteToStart(RowOperateRequest entity)
    {
        return ExcuteOperationAsync("ToStart", entity);
    }

    /// <summary>
    /// 执行到完工
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<ResponseResult> ExcuteToFinish(RowOperateRequest entity)
    {
        return ExcuteOperationAsync("ToFinish", entity);
    }

    /// <summary>
    /// 执行到结案
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<ResponseResult> ExcuteToClose(RowOperateRequest entity)
    {
        return ExcuteOperationAsync("ToClose", entity);
    }

    /// <summary>
    /// 反执行的计划
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<ResponseResult> UndoToPlan(RowOperateRequest entity)
    {
        return ExcuteOperationAsync("UndoToPlan", entity);
    }

    /// <summary>
    /// 反执行的计划确认
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<ResponseResult> UndoToPlanConfirm(RowOperateRequest entity)
    {
        return ExcuteOperationAsync("UndoToPlanConfirm", entity);
    }

    /// <summary>
    /// 反执行到下达
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<ResponseResult> UndoToRelease(RowOperateRequest entity)
    {
        return ExcuteOperationAsync("UndoToRelease", entity);
    }

    /// <summary>
    /// 反执行到开工
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<ResponseResult> UndoToStart(RowOperateRequest entity)
    {
        return ExcuteOperationAsync("UndoToStart", entity);
    }

    /// <summary>
    /// 反执行到完工
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<ResponseResult> UndoToFinish(RowOperateRequest entity)
    {
        return ExcuteOperationAsync("UndoToFinish", entity);
    }

    /// <summary>
    /// 强制结案
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<ResponseResult> ForceClose(RowOperateRequest entity)
    {
        return ExcuteOperationAsync("ForceClose", entity);
    }
}
