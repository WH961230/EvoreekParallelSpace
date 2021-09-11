using System.Collections.Generic;
using UnityEngine;

public class WeaponBulletHandle : Singleton<WeaponBulletHandle> {
    //weaponId bulletNum
    private Dictionary<int,List<int>> WeaponBulletDic = new Dictionary<int, List<int>>();

    #region 弹药增删改查
    /// <summary>
    /// 增加弹药
    /// </summary>
    /// <param name="weaponId">武器标识</param>
    /// <param name="bulletNum">增加弹药数量</param>
    public void WeaponAddBullet(int weaponId, int addBulletNum) {
        if (null == WeaponBulletDic) {
            return;
        }
        var list = BulletMgr.Instance.InitBulletByNum(addBulletNum);

        if (WeaponBulletDic.ContainsKey(weaponId)) {
            var bulletList = WeaponBulletDic[weaponId];
            foreach (var l in list)
            {
                bulletList.Add(l);
            }
            WeaponBulletDic[weaponId] = bulletList;
        } else {
            WeaponBulletDic.Add(weaponId, list);
        }
        Debug.LogFormat("补充武器 {0} 总弹药数 {1} 补充弹药数 {2}", 
            WeaponMgr.Instance.GetWeaponInfoById(weaponId), 
            WeaponBulletDic[weaponId].Count, addBulletNum);
    }

    /// <summary>
    /// 消耗指定武器弹药
    /// </summary>
    /// <param name="weaponId">武器</param>
    /// <param name="consumeBulletNum">消耗数量</param>
    private void WeaponConsumeBullet(int weaponId, int bulletId)
    {
        if (null == WeaponBulletDic)
        {
            return;
        }

        if (WeaponBulletDic.ContainsKey(weaponId))
        {
            var bulletIdList = WeaponBulletDic[weaponId];
            if (bulletIdList.Count <= 0)
            {
                return;
            }

            if (bulletIdList.Contains(bulletId))
            {
                bulletIdList.Remove(bulletId);
            }

            WeaponBulletDic[weaponId] = bulletIdList;
        }

        Debug.LogFormat("消耗武器 {0} 弹药数 {1}", WeaponMgr.Instance.GetWeaponInfoById(weaponId),
            WeaponBulletDic[weaponId].Count);
    }

    /// <summary>
    /// 获取武器弹药数量
    /// </summary>
    /// <param name="weaponId"></param>
    /// <returns></returns>
    public int GetWeaponBulletNum(int weaponId) {
        if (null == WeaponBulletDic) {
            return 0;
        }

        int bulletNum = 0;
        if (WeaponBulletDic.ContainsKey(weaponId)) {
            bulletNum = WeaponBulletDic[weaponId].Count;
        }

        return bulletNum;
    }
    #endregion

    #region 弹药操作

    public void WeaponShotBullet(int weaponId, Vector3 startPoint, Quaternion startQua, Vector3 target)
    {
        if (WeaponBulletDic.ContainsKey(weaponId))
        {
            int bulletId = -1;
            var listBulletId = WeaponBulletDic[weaponId];
            if (listBulletId.Count > 0)
            {
                bulletId = listBulletId[0];
                var b = BulletMgr.Instance.GetBulletById(bulletId);
                var bTran = b.BaseData.bulletController.transform;
                bTran.position = startPoint;
                bTran.rotation = startQua;
                b.BaseData.bulletController.target = target;
            }
            
            WeaponConsumeBullet(weaponId, bulletId);
        }
    }


    #endregion
}