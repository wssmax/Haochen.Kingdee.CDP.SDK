using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Kingdee.CDP.WebApi.SDK;
using Newtonsoft.Json;

namespace Haochen.Kingdee.CDP.Base;

/// <summary>
/// Kingdee.CDP基础服务类
/// </summary>
public abstract class BaseService
{
    protected K3CloudApi _k3Client;
    protected string FormID { get; set; }

    protected JsonSerializerSettings Settings { get; set; }

    public BaseService()
    {
        _k3Client = new K3CloudApi();
        RepoResult reporesult = _k3Client.CheckAuthInfo();
        if (!reporesult.ResponseStatus.IsSuccess)
        {
            throw new Exception("Kingdee.CDP远程登录失败!");
        }

        Settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented,
        };
    }

    /// <summary>
    /// 新建单据，保存
    /// </summary>
    /// <param name="entity"></param>
    protected async Task<ResponseResult> SaveAsync<T>(T entity)
    {
        var input = JsonConvert.SerializeObject(entity, Settings);
        var data = await Task.Run(() => _k3Client.Save(FormID, input));
        var result = JsonConvert.DeserializeObject<KingDeeResponse>(data);
        return result.Result;
    }

    /// <summary>
    /// 根据id或者编码
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="single"></param>
    /// <returns></returns>
    protected async Task<T> ViewAsync<T>(SingleRequest single)
    {
        string jsonstring = JsonConvert.SerializeObject(single);
        var data = await Task.Run(() => _k3Client.View(FormID, jsonstring));
        var result = JsonConvert.DeserializeObject<SingleResponse<T>>(data);
        var str = JsonConvert.SerializeObject(result);
        if (result.Result.ResponseStatus.IsSuccess)
            return result.Result.Result;
        return default;
    }

    /// <summary>
    /// 条件列表查询
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    protected async Task<List<T>> BillQuery<T>(QueryRequest request)
    {
        string jsonstring = JsonConvert.SerializeObject(request);
        var data = await Task.Run(() => _k3Client.BillQuery(jsonstring));
        try
        {
            var result = JsonConvert.DeserializeObject<List<T>>(data);
            return result;
        }
        catch (Exception ex)
        {
            //IDE 输出异常,在VS输出窗口输出异常
            Debug.WriteLine(data);
            return default;
        }
    }

    /// <summary>
    /// 删除单据
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<ResponseResult> DeleteAsync(DeleteRequest entity)
    {
        var data = await Task.Run(() => _k3Client.Delete(FormID, JsonConvert.SerializeObject(entity)));
        var result = JsonConvert.DeserializeObject<KingDeeResponse>(data);
        return result.Result;
    }

    /// <summary>
    /// 提交单据
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<ResponseResult> SubmitAsync(SubmitRequest entity)
    {
        var data = await Task.Run(() => _k3Client.Submit(FormID, JsonConvert.SerializeObject(entity)));
        var result = JsonConvert.DeserializeObject<KingDeeResponse>(data);
        return result.Result;
    }

    /// <summary>
    /// 撤销单据
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<ResponseResult> CancelAssignAsync(SubmitRequest entity)
    {
        var data = await Task.Run(() => _k3Client.CancelAssign(FormID, JsonConvert.SerializeObject(entity)));
        var result = JsonConvert.DeserializeObject<KingDeeResponse>(data);
        return result.Result;
    }

    /// <summary>
    /// 审核单据
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<ResponseResult> AuditAsync(AuditRequest entity)
    {
        var data = await Task.Run(() => _k3Client.Audit(FormID, JsonConvert.SerializeObject(entity)));
        var result = JsonConvert.DeserializeObject<KingDeeResponse>(data);
        return result.Result;
    }

    /// <summary>
    /// 反审核单据
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<ResponseResult> UnAuditAsync(AuditRequest entity)
    {
        var data = await Task.Run(() => _k3Client.UnAudit(FormID, JsonConvert.SerializeObject(entity)));
        var result = JsonConvert.DeserializeObject<KingDeeResponse>(data);
        return result.Result;
    }

    /// <summary>
    /// 行执行，
    /// </summary>
    /// <param name="operateNumber">操作类型</param>
    /// <param name="entity"></param>
    /// <returns></returns>
    protected async Task<ResponseResult> ExcuteOperationAsync(string operateNumber, RowOperateRequest entity)
    {
        var data = await Task.Run(() => _k3Client.ExcuteOperation(FormID, operateNumber, JsonConvert.SerializeObject(entity, Settings)));
        var result = JsonConvert.DeserializeObject<KingDeeResponse>(data);
        return result.Result;
    }

    /// <summary>
    /// 作废
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<ResponseResult> Cancel(RowOperateRequest entity)
    {
        return ExcuteOperationAsync("Cancel", entity);
    }

    /// <summary>
    /// 反作废
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<ResponseResult> UnCancel(RowOperateRequest entity)
    {
        return ExcuteOperationAsync("UnCancel", entity);
    }

    /// <summary>
    /// 级联获取类的熟悉并存入数组
    /// </summary>
    /// <param name="type"></param>
    /// <param name="propertyNames"></param>
    /// <param name="prefix"></param>
    public static void GetPublicPropertyNames(Type type, List<string> propertyNames, string prefix = "")
    {
        // 获取所有公共属性
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var property in properties)
        {
            //忽略的项目
            var ignore = property.GetCustomAttribute<JsonIgnoreAttribute>();
            if (ignore != null)
                continue;
            // 构造属性名称
            string propertyName = string.IsNullOrEmpty(prefix) ? property.Name : $"{prefix}.{property.Name}";
            var att = property.GetCustomAttribute<JsonPropertyAttribute>();
            if (att != null)
            {
                propertyName = att.PropertyName;
            }
            propertyNames.Add(propertyName);

            // 检查属性类型是否为自定义类且不是字符串
            if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
            {
                // 递归调用以遍历该自定义类的属性
                GetPublicPropertyNames(property.PropertyType, propertyNames, propertyName);
            }
        }
    }
}
