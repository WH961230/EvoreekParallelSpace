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
    public int id;
    public WeaponType weaponType;
    public WeaponController weaponController;
    public BulletType bulletType;

    public WeaponBaseData(int Id, WeaponType weaponType, WeaponController controller, BulletType bulletType)
    {
        this.id = Id;
        this.weaponType = weaponType;
        this.weaponController = controller;
        this.bulletType = bulletType;
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
    public Weapon(int id, WeaponType wt, WeaponController wc, BulletType bt)
    {
        this.BaseData.id = id;
        this.BaseData.weaponController = wc;
        this.BaseData.weaponType = wt;
        this.BaseData.bulletType = bt;
    }
    
    /// <summary>
    /// 构造基本数据
    /// </summary>
    /// <param name="id"></param>
    /// <param name="oc"></param>
    public Weapon(int id, WeaponType wt, WeaponController wc)
    {
        this.BaseData.id = id;
        this.BaseData.weaponController = wc;
        this.BaseData.weaponType = wt;
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