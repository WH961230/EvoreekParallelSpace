using System.Collections.Generic;

public class WeaponBulletHandle : Singleton<PlayerWeaponHandle>{
    //weaponId bulletNum
    private Dictionary<int,int> WeaponBulletDic = new Dictionary<int, int>();

    public void WeaponShootBullet(int weaponId, int bulletNum) {
        
    }

    public void WeaponReloadBullet(int weaponId, int bulletNum) {
        
    }
}