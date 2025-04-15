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
    /// 创建和修改生产订单变更
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
    public Task<ResponseResult> ExcuteToPlanConfirmAsync(RowOperateRequest entity)
    {
        return ExcuteOperationAsync("ToPlanConfirm", entity);
    }

    public Task<ResponseResult> ExcuteToPlanConfirmAsync(List<FIDwithEntryID> data)
    {
        var entity = CreateRowExcute(data);
        return ExcuteToPlanConfirmAsync(entity);
    }

    /// <summary>
    /// 执行到下达
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<ResponseResult> ExcuteToReleaseAsync(RowOperateRequest entity)
    {
        return ExcuteOperationAsync("ToRelease", entity);
    }

    public Task<ResponseResult> ExcuteToReleaseAsync(List<FIDwithEntryID> data)
    {
        var entity = CreateRowExcute(data);
        return ExcuteToReleaseAsync(entity);
    }

    /// <summary>
    /// 执行到开工
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<ResponseResult> ExcuteToStartAsync(RowOperateRequest entity)
    {
        return ExcuteOperationAsync("ToStart", entity);
    }

    public Task<ResponseResult> ExcuteToStartAsync(List<FIDwithEntryID> data)
    {
        var entity = CreateRowExcute(data);
        return ExcuteToStartAsync(entity);
    }

    /// <summary>
    /// 执行到完工
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<ResponseResult> ExcuteToFinishAsync(RowOperateRequest entity)
    {
        return ExcuteOperationAsync("ToFinish", entity);
    }

    public Task<ResponseResult> ExcuteToFinishAsync(List<FIDwithEntryID> data)
    {
        var entity = CreateRowExcute(data);
        return ExcuteToFinishAsync(entity);
    }

    /// <summary>
    /// 执行到结案
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<ResponseResult> ExcuteToCloseAsync(RowOperateRequest entity)
    {
        return ExcuteOperationAsync("ToClose", entity);
    }

    public Task<ResponseResult> ExcuteToCloseAsync(List<FIDwithEntryID> data)
    {
        var entity = CreateRowExcute(data);
        return ExcuteToCloseAsync(entity);
    }

    /// <summary>
    /// 反执行的计划
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<ResponseResult> UndoToPlanAsync(RowOperateRequest entity)
    {
        return ExcuteOperationAsync("UndoToPlan", entity);
    }

    public Task<ResponseResult> UndoToPlanAsync(List<FIDwithEntryID> data)
    {
        var entity = CreateRowExcute(data);
        return UndoToPlanAsync(entity);
    }

    /// <summary>
    /// 反执行的计划确认
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<ResponseResult> UndoToPlanConfirmAsync(RowOperateRequest entity)
    {
        return ExcuteOperationAsync("UndoToPlanConfirm", entity);
    }

    public Task<ResponseResult> UndoToPlanConfirmAsync(List<FIDwithEntryID> data)
    {
        var entity = CreateRowExcute(data);
        return UndoToPlanConfirmAsync(entity);
    }

    /// <summary>
    /// 反执行到下达
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<ResponseResult> UndoToReleaseAsync(RowOperateRequest entity)
    {
        return ExcuteOperationAsync("UndoToRelease", entity);
    }

    public Task<ResponseResult> UndoToReleaseAsync(List<FIDwithEntryID> data)
    {
        var entity = CreateRowExcute(data);
        return UndoToReleaseAsync(entity);
    }

    /// <summary>
    /// 反执行到开工
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<ResponseResult> UndoToStartAsync(RowOperateRequest entity)
    {
        return ExcuteOperationAsync("UndoToStart", entity);
    }

    public Task<ResponseResult> UndoToStartAsync(List<FIDwithEntryID> data)
    {
        var entity = CreateRowExcute(data);
        return UndoToStartAsync(entity);
    }

    /// <summary>
    /// 反执行到完工
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<ResponseResult> UndoToFinishAsync(RowOperateRequest entity)
    {
        return ExcuteOperationAsync("UndoToFinish", entity);
    }

    public Task<ResponseResult> UndoToFinishAsync(List<FIDwithEntryID> data)
    {
        var entity = CreateRowExcute(data);
        return UndoToFinishAsync(entity);
    }

    /// <summary>
    /// 强制结案
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<ResponseResult> ForceCloseAsync(RowOperateRequest entity)
    {
        return ExcuteOperationAsync("ForceClose", entity);
    }

    public Task<ResponseResult> ForceCloseAsync(List<FIDwithEntryID> data)
    {
        var entity = CreateRowExcute(data);
        return ForceCloseAsync(entity);
    }
}
