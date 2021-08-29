/// <summary>
/// 投掷
/// </summary>
public class Throw : Weapon
{
    public Throw(int id, string wn, WeaponType wt, WeaponController wc, BulletType bt) : base(id, wn, wt, wc, bt)
    {
    }

    public Throw(int id, string wn, WeaponType wt, WeaponController wc) : base(id, wn, wt, wc)
    {
    }
}