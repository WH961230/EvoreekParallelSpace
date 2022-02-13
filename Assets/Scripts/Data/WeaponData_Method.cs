public partial class WeaponData
{
    public void AddWeaponInfo(WeaponInfo info) {
        allWeaponInfos?.Add(info);
    }
    
    public bool TryGetWeaponInfo(long weaponId, out WeaponInfo weaponInfo) {
        for (var i = 0; i < allWeaponInfos.Count; i++) {
            var info = allWeaponInfos[i];
            if (weaponId == info.WeaponId) {
                weaponInfo = info;
                return true;
            }
        }

        weaponInfo = null;
        return false;
    }
}