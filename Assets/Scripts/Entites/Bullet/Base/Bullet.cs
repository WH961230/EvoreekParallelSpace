
public enum BulletType
{
    mini,//gun ump
    middle,//m4 scar
    large,//ak
}

/// <summary>
/// 弹药基础数据
/// </summary>
public class BulletBaseData
{
    public int id;
    public BulletType type;
    public BulletController bulletController;
}

/// <summary>
/// 弹药
/// </summary>
public class Bullet : IBaseEntites
{
    private BulletBaseData BaseData;

    public Bullet(int id, BulletType type, BulletController bc)
    {
        this.BaseData.id = id;
        this.BaseData.type = type;
        this.BaseData.bulletController = bc;
    }

    public void OnInit() {
    }

    public void OnClear() {
    }
}