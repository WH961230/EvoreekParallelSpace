/// <summary>
/// 投掷
/// </summary>
public class Throw : Weapon
{
    public Throw(int id, string wn, WeaponType wt, WeaponController wc, BulletType bt, SOWeapon ws) : base(id, wn, wt, wc, bt, ws)
    {
    }

    public Throw(int id, string wn, WeaponType wt, WeaponController wc, SOWeapon ws) : base(id, wn, wt, wc, ws)
    {
    }
}