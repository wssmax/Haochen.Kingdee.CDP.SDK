namespace Haochen.Kingdee.CDP.Base;

/// <summary>
/// 仓位信息
/// 默认值启用一个参数
/// 前缀为分录属性名称,默认FStockLocID__
/// </summary>
public class StockLocID : Dictionary<string, BaseEntity>
{
    private string _prefix = "FStockLocID__";

    public StockLocID(string number)
    {
        var prefix = _prefix + "FF100001";
        this.Add(prefix, new BaseEntity(number));
    }

    public StockLocID(string number, string _prefix)
    {
        this._prefix = _prefix + "__";
        var prefix = this._prefix + "FF100001";
        this.Add(prefix, new BaseEntity(number));
    }

    public void Add(string key, string value)
    {
        this.Add(_prefix + key, new BaseEntity(value));
    }
}
