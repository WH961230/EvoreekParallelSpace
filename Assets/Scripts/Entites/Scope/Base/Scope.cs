/// <summary>
/// 类型
/// </summary>
public enum ScopeType
{
    
}


/// <summary>
/// 基本信息
/// </summary>
public struct ScopeBaseData{
    public int id;
    public ScopeType scopeType;
    public ScopeController scopeController;

    public ScopeBaseData(int Id, ScopeType st, ScopeController sc)
    {
        this.id = Id;
        this.scopeType = st;
        this.scopeController = sc;
    }
}

public class Scope : IBaseEntites{
    public ScopeBaseData BaseData;
    
    public void OnInit() {
    }

    public void OnClear() {
    }
}