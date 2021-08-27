using System.Collections.Generic;

public class WeaponScopeHandle : Singleton<WeaponScopeHandle> {
    //weaponId scopeId
    private Dictionary<int, int> WeaponScopeDic = new Dictionary<int, int>();
}