using Unity.VisualScripting;

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
    public string weaponName;
    public WeaponType weaponType;
    public WeaponController weaponController;
    public BulletType bulletType;
    public SOWeapon weaponSetting;

    public WeaponBaseData(int Id, string wn, WeaponType wt, WeaponController wc, BulletType bt, SOWeapon ws)
    {
        this.id = Id;
        this.weaponName = wn;
        this.weaponType = wt;
        this.weaponController = wc;
        this.bulletType = bt;
        this.weaponSetting = ws;
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
    public Weapon(int id, string wn, WeaponType wt, WeaponController wc, BulletType bt, SOWeapon ws)
    {
        this.BaseData.id = id;
        this.BaseData.weaponName = wn;
        this.BaseData.weaponController = wc;
        this.BaseData.weaponType = wt;
        this.BaseData.bulletType = bt;
        this.BaseData.weaponSetting = ws;
    }
    
    /// <summary>
    /// 构造基本数据
    /// </summary>
    /// <param name="id"></param>
    /// <param name="oc"></param>
    public Weapon(int id, string wn, WeaponType wt, WeaponController wc, SOWeapon ws)
    {
        this.BaseData.id = id;
        this.BaseData.weaponName = wn;
        this.BaseData.weaponController = wc;
        this.BaseData.weaponType = wt;
        this.BaseData.weaponSetting = ws;
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