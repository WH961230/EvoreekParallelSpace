using System.Collections.Generic;
using Data;
using UnityEngine;

/// <summary>
/// 武器管理 - 数据处理
/// </summary>
public class WeaponMgr : Singleton<WeaponMgr>, IBaseMgr
{
    private readonly List<Weapon> Weapons = new List<Weapon>();
    private int id = -1;
    
    public void OnInit(GameEngine gameEngine)
    {
        gameEngine.managers.Add(this);
        MessageCenter.Instance.Register(MessageCode.Game_GameStart, InitWeapon);
    }

    public void OnUpdate()
    {
        if (null != Weapons && Weapons.Count > 0) {
            for (var i = 0 ; i < Weapons.Count ; ++i)
            {
                var w = Weapons[i];
                if (w != null)
                {
                    var wc = w.BaseData.weaponController;
                    if (wc != null)
                    {
                        wc.OnUpdate();
                    }
                }
            }
        }
    }

    private void InitWeapon()
    {
        //获取预制体
        var w = Object.Instantiate(AssetLoader.LoadAsset(AssetType.Prefab, AssetInfoType.Weapon, ConfigMgr.Instance.weaponConfig.WeaponSign)) as GameObject;
        if (null == w) {
            return;
        }

        w.transform.position = ConfigMgr.Instance.weaponConfig.WeaponInfo.weaponBornVec;
        w.transform.localRotation = ConfigMgr.Instance.weaponConfig.WeaponInfo.weaponBornQua;

        var wc = w.GetComponentInChildren<WeaponController>();
        wc.OnInit();
        wc.weaponId = ++id;

        //创建武器
        var weapon = new Weapon(
            wc.weaponId,
            wc.weaponName,
            wc.weaponType,
            wc,
            wc.bulletType,
            wc.weaponSetting
            );

        Weapons.Add(weapon);
        
        //提供基础弹药 30 发  生成 30 发弹药
        WeaponBulletHandle.Instance.WeaponAddBullet(wc.weaponId, BulletMgr.Instance.InitBulletByNum(30));
    }

    public Weapon GetWeaponById(int id)
    {
        Weapon weapon = null;
        if (null != Weapons && Weapons.Count > 0)
        {
            foreach (var w in Weapons)
            {
                if (w.BaseData.id == id)
                {
                    weapon = w;
                }
            }
        }

        return weapon;
    }
    public string GetWeaponInfoById(int id)
    {
        var weaponName = GetWeaponById(id).BaseData.weaponName;
        var bulletNum = WeaponBulletHandle.Instance.GetWeaponBulletNum(id);
        return weaponName + " [id:"+ id + " bNm:" + bulletNum +"]";
    }

    /// <summary>
    /// 销毁武器
    /// </summary>
    public void RemoveWeapon(int id)
    {
        foreach (var w in Weapons)
        {
            if (w.BaseData.id == id)
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
    }
    
    public void OnClear()
    {
    }
}
