using System.Collections.Generic;
using Data;
using UnityEngine;

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
        MessageCenter.Instance.Register(MessageCode.Game_GameStart, InitWeapon);
    }

    public void OnUpdate()
    {
    }

    public void InitWeapon()
    {
        //获取预制体
        var weaponObj = Object.Instantiate(AssetLoader.LoadAsset(AssetType.Prefab, ConfigMgr.Instance.weaponConfig.WeaponSign)) as GameObject;
        if (null == weaponObj) {
            return;
        }

        weaponObj.transform.position = ConfigMgr.Instance.weaponConfig.WeaponInfo.weaponBornVec;
        weaponObj.transform.localRotation = ConfigMgr.Instance.weaponConfig.WeaponInfo.weaponBornQua;

        var wc = weaponObj.GetComponent<WeaponController>();
        wc.OnInit();
        wc.weaponId = ++id;
        
        //创建武器
        var weapon = new Weapon(
            wc.weaponId,
            wc.weaponType,
            wc
        );
        
        Weapons.Add(weapon);
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

    public Weapon GetWeaponById(int id)
    {
        Weapon weapon = null;
        if (null != Weapons && Weapons.Count > 0)
        {
            foreach (var w in Weapons)
            {
                if (w.BaseData.Id == id)
                {
                    weapon = w;
                }
            }
        }

        return weapon;
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
