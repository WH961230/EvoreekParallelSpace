/// <summary>
/// 武器类型
/// </summary>
public enum WeaponType
{
    枪械,
    近战,
    投掷,
}

/// <summary>
/// 武器基本信息
/// </summary>
public struct WeaponBaseData{
    public int Id;
    public WeaponType Type;
    public WeaponController weaponController;

    public WeaponBaseData(int Id, WeaponType type, WeaponController controller)
    {
        this.Id = Id;
        this.Type = type;
        this.weaponController = controller;
    }
}

/// <summary>
/// 武器
/// </summary>
public class Weapon : IBaseEntites
{
    public WeaponBaseData BaseData;

    /// <summary>
    /// 构造基本数据
    /// </summary>
    /// <param name="id"></param>
    /// <param name="oc"></param>
    public Weapon(int id, WeaponType type, WeaponController wc)
    {
        this.BaseData.Id = id;
        this.BaseData.weaponController = wc;
        this.BaseData.Type = type;
    }
    
    /// <summary>
    /// 初始化赋值
    /// </summary>
    public void OnInit()
    {
    }

    public void OnClear()
    {
        var controller = BaseData.weaponController;
        if (controller != null)
        {
            controller.OnClear();
        }
    }
}