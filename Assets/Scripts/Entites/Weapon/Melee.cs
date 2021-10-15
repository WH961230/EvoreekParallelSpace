/// <summary>
/// 近战
/// </summary>
public class Melee : Weapon
{
    public Melee(int id, string wn, WeaponType wt, WeaponController wc, BulletType bt, WeaponScriptableObject ws) : base(id, wn, wt, wc, bt, ws)
    {
    }

    public Melee(int id, string wn, WeaponType wt, WeaponController wc, WeaponScriptableObject ws) : base(id, wn, wt, wc, ws)
    {
    }
}