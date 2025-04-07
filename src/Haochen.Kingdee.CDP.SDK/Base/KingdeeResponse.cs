namespace Haochen.Kingdee.CDP.SDK.Base;


/// <summary>
/// 表示整个响应结果,无返回值
/// </summary>
public class KingDeeResponse
{
    public ResponseResult Result { get; set; }
}

/// <summary>
/// 表示整个响应结果，有多返回值
/// </summary>
public class MultiResponse<T>
{
    public ResponseResult<T> Result { get; set; }
}
/// <summary>
/// 单返回值,单独查询结果
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingleResponse<T>
{
    public SingleResponseResult<T> Result { get; set; }
}

/// <summary>
/// 表示响应的结果部分
/// </summary>
public class ResponseResult : ResponseBase
{
    public ResponseStatus ResponseStatus { get; set; }
}

/// <summary>
/// 表示响应的结果部分
/// </summary>
public class ResponseResult<T> : ResponseResult
{
    public List<T> NeedReturnData { get; set; }
}

public class SingleResponseResult<T> : ResponseResult
{
    public T Result { get; set; }
}

/// <summary>
/// 表示响应状态
/// </summary>
public class ResponseStatus
{
    public string ErrorCode { get; set; }
    public bool IsSuccess { get; set; }
    public List<KingDeeMessage> Errors { get; set; }
    public List<SuccessEntity> SuccessEntitys { get; set; }
    public List<KingDeeMessage> SuccessMessages { get; set; }
    public string MsgCode { get; set; }
}

/// <summary>
/// 表示错误信息
/// </summary>
public class KingDeeMessage
{
    public string FieldName { get; set; }
    public string Message { get; set; }
    public int DIndex { get; set; }

    public override string ToString()
    {
        return Message;
    }
}

/// <summary>
/// 表示成功实体
/// </summary>
public class SuccessEntity : ResponseBase
{
    public int DIndex { get; set; }
}

public abstract class ResponseBase
{
    public string Id { get; set; }
    public string Number { get; set; }
}
