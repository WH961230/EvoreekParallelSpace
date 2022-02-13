using System.Collections.Generic;

public partial class WeaponData
{
    private List<WeaponInfo> allWeaponInfos = new List<WeaponInfo>();
    public List<WeaponInfo> AllWeaponInfos
    {
        get { return allWeaponInfos; }
    }
}

public class WeaponInfo {
    private long weaponId;
    public long WeaponId {
        get => weaponId;
    }

    private int componentId;
    public int ComponentId {
        get => componentId;
    }

    public WeaponInfo(long weaponId, int componentId) {
        this.weaponId = weaponId;
        this.componentId = componentId;
    }
}