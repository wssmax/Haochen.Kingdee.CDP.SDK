金蝶Kingdee.CDP.WebApi.SDK.dll作为一款官方SDK，为开发者提供了丰富的技术功能，能够满足多种业务场景的开发需求。然而，在实际开发过程中，我们发现该SDK存在一些使用上的不便之处，尤其是在参数处理方面，给开发者带来了额外的工作量。本文将详细介绍我们针对该SDK进行二次封装的实践过程，旨在通过优化开发流程，提升开发效率，为开发者提供更加简洁、高效的开发体验。

### 一、SDK现状分析

金蝶Kingdee.CDP.WebApi.SDK.dll按照技术功能进行了封装，这种封装方式虽然在一定程度上保证了功能的完整性，但也导致了每个具体业务包含大量的参数。在实际开发中，许多参数并非必要，开发者需要花费大量时间去拼接JSON数据，以适配SDK的接口要求。这种重复且繁琐的工作不仅降低了开发效率，还容易引入错误。

### 二、二次封装的目标与策略

为了简化开发者对金蝶Kingdee.CDP.WebApi.SDK.dll的调用，我们决定对其进行二次封装。二次封装的目标是将相关的JSON数据转换为C#模型，并对模型进行裁剪，保留关键参数，同时确保模型的可扩展性。为此，我们采用了以下策略：

#### （一）JSON数据转换为C#模型

我们将SDK中涉及的JSON数据结构转换为C#类模型。通过这种方式，开发者可以直接使用C#对象进行操作，而无需手动拼接JSON字符串。这不仅提高了代码的可读性和可维护性，还减少了因手动拼接JSON数据而可能引入的错误。
```
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
```

#### （二）裁剪非关键参数

在分析SDK接口参数的过程中，我们发现许多参数在实际业务场景中并不常用。为了简化开发流程，我们对这些参数进行了裁剪，仅保留了关键参数。这样，开发者在调用接口时，只需关注与业务逻辑紧密相关的参数，从而提高了开发效率。
```
​/// <summary>
/// 生产订单明细
/// </summary>
public partial class MoEntry
{
    /// <summary>
    /// 实体主键
    /// </summary>
    public int FEntryID { get; set; }

    /// <summary>
    /// 物料编码
    /// </summary>
    public BaseEntity FMaterialID { get; set; }

    /// <summary>
    /// 数量
    /// </summary>
    public double FQty { get; set; }

    /// <summary>
    /// 计划开工时间
    /// </summary>
    public DateTime FPlanStartDate { get; set; }

    /// <summary>
    /// 计划完工时间
    /// </summary>
    public DateTime FPlanFinishDate { get; set; }

    /// <summary>
    /// 批号
    /// </summary>
    public BaseEntity FLot { get; set; }

    /// <summary>
    /// BOM版本
    /// </summary>
    public BaseEntity FBomID { get; set; }

    /// <summary>
    /// 生产车间
    /// </summary>
    public BaseEntity FWorkShopID { get; set; }
}
```

#### （三）采用partial类进行定义

为了确保模型的可扩展性，我们采用了partial类进行定义。partial类允许开发者在不修改原有代码的基础上，通过定义新的类文件来扩展模型的功能。这种设计既保证了二次封装的稳定性，又为开发者提供了灵活的扩展机制。

