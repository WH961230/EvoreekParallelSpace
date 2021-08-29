/// <summary>
/// 近战
/// </summary>
public class Melee : Weapon
{
    public Melee(int id, string wn, WeaponType wt, WeaponController wc, BulletType bt) : base(id, wn, wt, wc, bt)
    {
    }

    public Melee(int id, string wn, WeaponType wt, WeaponController wc) : base(id, wn, wt, wc)
    {
    }
}