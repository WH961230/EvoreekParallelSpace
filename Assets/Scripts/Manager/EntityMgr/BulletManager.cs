using System.Collections.Generic;
using UnityEngine;

public class BulletManager : Singleton<BulletManager>,IBaseManager
{
    public List<Bullet> bullets = new List<Bullet>();
    private int id = -1;

    public void OnInit(GameEngine gameEngine)
    {
        gameEngine.managers.Add(this);
    }

    /// <summary>
    /// 初始化弹药
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bc"></param>
    public int InitBullet()
    {
        var bulletObj = Object.Instantiate(AssetLoader.LoadAsset(AssetType.Prefab, AssetInfoType.Weapon,
            ConfigManager.Instance.bulletConfig.BulletSign)) as GameObject;
        var bc = bulletObj.GetComponent<BulletController>();
        var type = bc.bulletType;
        id++;
        var bullet = new Bullet(id, type, bc);
        bullets.Add(bullet);
        //隐藏资源备用
        bc.gameObject.SetActive(false);
        return id;
    }

    public List<int> InitBulletByNum(int num)
    {
        List<int> bulletList = new List<int>();
        for (int i = 0; i < num; i++)
        {
            var n = InitBullet();
            bulletList.Add(n);
        }

        return bulletList;
    }

    public Bullet GetBulletById(int id)
    {
        foreach (var b in bullets)
        {
            if (b.BaseData.id == id)
            {
                return b;
            }
        }

        return null;
    }
    
    public void OnUpdate() {
        if (null != bullets && bullets.Count > 0) {
            for (var i = 0 ; i < bullets.Count ; ++i)
            {
                var b = bullets[i];
                if (b != null)
                {
                    var bc = b.BaseData.bulletController;
                    if (bc != null)
                    {
                        bc.OnUpdate();
                    }
                }
            }
        }
    }

    public void OnClear()
    {
    }
}