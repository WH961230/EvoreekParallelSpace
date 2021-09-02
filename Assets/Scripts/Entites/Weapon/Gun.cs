﻿/// <summary>
/// 枪
/// </summary>
public class Gun : Weapon
{
    public Gun(int id, string wn, WeaponType wt, WeaponController wc, BulletType bt, SOWeapon ws) : base(id, wn, wt, wc, bt, ws)
    {
    }

    public Gun(int id, string wn, WeaponType wt, WeaponController wc, SOWeapon ws) : base(id, wn, wt, wc, ws)
    {
    }
}