using System.Collections.Generic;

public class BulletMgr : Singleton<BulletMgr>,IBaseMgr
{
    public List<Bullet> bullets;
    private int id = -1;

    public void OnInit(GameEngine gameEngine)
    {
        gameEngine.managers.Add(this);
    }

    public void OnUpdate()
    {
    }

    /// <summary>
    /// 初始化弹药
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bc"></param>
    public void InitBullet(BulletType type, BulletController bc)
    {
        id++;
        var bullet = new Bullet(id, type, bc);
        bullets.Add(bullet);
    }

    public void OnClear()
    {
    }
}