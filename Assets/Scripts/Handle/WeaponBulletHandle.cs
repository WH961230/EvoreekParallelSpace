using System.Collections.Generic;
using UnityEngine;

public class WeaponBulletHandle : Singleton<WeaponBulletHandle>{
    //weaponId bulletNum
    private Dictionary<int,int> WeaponBulletDic = new Dictionary<int, int>();

    #region 弹药增删改查
    /// <summary>
    /// 增加弹药
    /// </summary>
    /// <param name="weaponId">武器标识</param>
    /// <param name="bulletNum">增加弹药数量</param>
    public void WeaponAddBullet(int weaponId, int addBulletNum)
    {
        if (null == WeaponBulletDic) {
            return;
        }
        if (WeaponBulletDic.ContainsKey(weaponId))
        {
            var bulletNum = WeaponBulletDic[weaponId];
            WeaponBulletDic[weaponId] = bulletNum + addBulletNum;
        }
        else
        {
            WeaponBulletDic.Add(weaponId, addBulletNum);
        }
        Debug.LogFormat("补充武器 {0} 总弹药数 {1} 补充弹药数 {2}", 
            WeaponMgr.Instance.GetWeaponInfoById(weaponId), 
            WeaponBulletDic[weaponId], addBulletNum);
    }

    /// <summary>
    /// 消耗指定武器弹药
    /// </summary>
    /// <param name="weaponId">武器</param>
    /// <param name="consumeBulletNum">消耗数量</param>
    public void WeaponConsumeBullet(int weaponId, int consumeBulletNum)
    {
        if (null == WeaponBulletDic) {
            return;
        }
        if (WeaponBulletDic.ContainsKey(weaponId))
        {
            var bulletNum = WeaponBulletDic[weaponId];
            var afterBulletNum = Mathf.Min(0, bulletNum - consumeBulletNum);
            WeaponBulletDic[weaponId] = afterBulletNum;
        }
        else
        {
            WeaponBulletDic.Add(weaponId, 0);
        }
        Debug.LogFormat("消耗武器 {0} 弹药数 {1}", 
            WeaponMgr.Instance.GetWeaponInfoById(weaponId), 
            WeaponBulletDic[weaponId]
            );
    }

    /// <summary>
    /// 获取武器弹药数量
    /// </summary>
    /// <param name="weaponId"></param>
    /// <returns></returns>
    public int GetWeaponBulletNum(int weaponId)
    {
        if (null == WeaponBulletDic) {
            return 0;
        }

        int bulletNum = 0;
        if (WeaponBulletDic.ContainsKey(weaponId))
        {
            bulletNum = WeaponBulletDic[weaponId];
        }

        return bulletNum;
    }
    #endregion
}