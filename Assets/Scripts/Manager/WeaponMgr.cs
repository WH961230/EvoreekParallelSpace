using System.Collections.Generic;

/// <summary>
/// 武器管理 - 数据处理
/// </summary>
public class WeaponMgr : Singleton<WeaponMgr>, IBaseMgr
{
    public List<Weapon> Weapons = new List<Weapon>();
    
    private int id = -1;
    
    public void OnInit(GameEngine gameEngine)
    {
        gameEngine.managers.Add(this);
    }

    public void OnUpdate()
    {
    }

    /// <summary>
    /// 注册武器
    /// </summary>
    public void RegisterWeapon(WeaponType type, WeaponController wc)
    {
        //武器Id
        id++;
        //创建武器
        var weapon = new Weapon(id, type, wc);
        //保存武器信息
        Weapons.Add(weapon);
    }

    /// <summary>
    /// 销毁武器
    /// </summary>
    public void RemoveWeapon(int id)
    {
        foreach (var w in Weapons)
        {
            if (w.BaseData.Id == id)
            {
                w.OnClear();
                Weapons.Remove(w);
                break;
            }
        }
    }
    
    /// <summary>
    /// 拾取武器
    /// </summary>
    /// <param name="ownerController"></param>
    public void PickedWeapon(PlayerController oc, WeaponController wc)
    {
        //控制器表现
        //数据修改
    }
    
    public void OnClear()
    {
    }
}
