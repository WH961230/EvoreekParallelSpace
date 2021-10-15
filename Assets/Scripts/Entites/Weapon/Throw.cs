/// <summary>
/// 投掷
/// </summary>
public class Throw : Weapon
{
    public Throw(int id, string wn, WeaponType wt, WeaponController wc, BulletType bt, WeaponScriptableObject ws) : base(id, wn, wt, wc, bt, ws)
    {
    }

    public Throw(int id, string wn, WeaponType wt, WeaponController wc, WeaponScriptableObject ws) : base(id, wn, wt, wc, ws)
    {
    }
}