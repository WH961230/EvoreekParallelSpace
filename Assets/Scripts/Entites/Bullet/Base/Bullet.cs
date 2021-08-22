
public enum BulletType
{
    小,
    中,
    大,
}

/// <summary>
/// 弹药基础数据
/// </summary>
public class BulletBaseData
{
    public int Id;
    public BulletType type;
    public BulletController bulletController;
}

/// <summary>
/// 弹药
/// </summary>
public class Bullet
{
    public BulletBaseData BaseData;

    public Bullet(int id, BulletType type, BulletController bc)
    {
        this.BaseData.Id = id;
        this.BaseData.type = type;
        this.BaseData.bulletController = bc;
    }
}