using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haochen.Kingdee.CDP.Base;

/// <summary>
/// 金蝶api保存功能基类
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class KingDeeInput<T> where T : new()
{
    /// <summary>
    /// 需要更新的字段，数组类型，格式：[key1,key2,...] （非必录）
    /// 注（更新字段时Model数据包中必须设置内码，若更新单据体字段还需设置分录内码）
    /// </summary>
    public List<string> NeedUpDateFields { get; set; } = [];

    /// <summary>
    /// 需返回结果的字段集合，数组类型，格式：[key,entitykey.key,...]（非必录）
    /// 注（返回单据体字段格式：entitykey.key）
    /// </summary>
    public List<string> NeedReturnFields { get; set; } = [];

    /// <summary>
    /// 表单数据包，JSON类型（必录）
    /// </summary>
    public T Model { get; set; } = new T();
}
