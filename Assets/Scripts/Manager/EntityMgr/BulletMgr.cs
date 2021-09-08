using System.Collections.Generic;
using UnityEngine;

public class BulletMgr : Singleton<BulletMgr>,IBaseMgr
{
    public List<Bullet> bullets = new List<Bullet>();
    private int id = -1;

    public void OnInit(GameEngine gameEngine)
    {
        gameEngine.managers.Add(this);
    }

    public void OnUpdate() {
    }

    /// <summary>
    /// 初始化弹药
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bc"></param>
    private void InitBullet()
    {
        var bulletObj = Object.Instantiate(AssetLoader.LoadAsset(AssetType.Prefab, AssetInfoType.Weapon, ConfigMgr.Instance.bulletConfig.BulletSign)) as GameObject;
        if (null == bulletObj)
        {
            return;
        }
        var bc = bulletObj.GetComponent<BulletController>();
        var type = bc.bulletType;
        id++;
        var bullet = new Bullet(id, type, bc);
        bullets.Add(bullet);
        //隐藏资源备用
        bc.gameObject.SetActive(false);
    }

    public int InitBulletByNum(int num)
    {
        for (int i = 0; i < num; i++)
        {
            InitBullet();
        }

        return num;
    }

    public void OnClear()
    {
    }
}