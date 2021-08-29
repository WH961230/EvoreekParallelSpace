/// <summary>
/// 枪
/// </summary>
public class Gun : Weapon
{
    public Gun(int id, string wn, WeaponType wt, WeaponController wc, BulletType bt) : base(id, wn, wt, wc, bt)
    {
    }

    public Gun(int id, string wn, WeaponType wt, WeaponController wc) : base(id, wn, wt, wc)
    {
    }
}