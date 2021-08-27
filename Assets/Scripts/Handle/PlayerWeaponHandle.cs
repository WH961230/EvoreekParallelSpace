using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
public class PlayerWeaponHandle : Singleton<PlayerWeaponHandle>
{
    private Dictionary<int,List<int>> PlayerWeaponDic = new Dictionary<int, List<int>>();

    public void PlayerDropWeapon(int playerId, int weaponId)
    {
        var player = PlayerMgr.Instance.GetPlayerById(playerId);
        var weapon = WeaponMgr.Instance.GetWeaponById(weaponId);
        if (null == player || null == weapon)
        {
            return;
        }
    }
    
    /// <summary>
    /// 拾起武器
    /// </summary>
    /// <param name="playerId"></param>
    /// <param name="weaponId"></param>
    public void PlayerPickWeapon(int playerId, int weaponId)
    {
        var player = PlayerMgr.Instance.GetPlayerById(playerId);
        var weapon = WeaponMgr.Instance.GetWeaponById(weaponId);
        if (null == player || null == weapon)
        {
            return;
        }
        //初次赋值 或者 不存在玩家 Id
        if (PlayerWeaponDic.Count == 0 || !PlayerWeaponDic.ContainsKey(playerId))
        {
            var weaponIds = new List<int>();
            weaponIds.Add(weaponId);
            PlayerWeaponDic.Add(playerId, weaponIds);
            player.BaseData.playerController.HandleWeapon(weapon.BaseData.weaponController.transform);
            return;
        }
        
        //玩家已有武器
        var alreadyHave = PlayerHasWeapon(playerId, weaponId);
        if (!alreadyHave)
        {
            var weaponIds = PlayerWeaponDic[playerId];
            weaponIds.Add(weaponId);
            //字典增加
            PlayerWeaponDic[playerId] = weaponIds;
            player.BaseData.playerController.HandleWeapon(weapon.BaseData.weaponController.transform);
        }
    }

    /// <summary>
    /// 是否已装备武器
    /// </summary>
    /// <param name="playerId"></param>
    /// <param name="weaponId"></param>
    /// <returns></returns>
    private bool PlayerHasWeapon(int playerId, int weaponId)
    {
        //没有玩家 false
        //有玩家没有武器 false
        //有玩家有武器 true
        List<int> weaponIds = null;
        //遍历字典
        foreach (var p in PlayerWeaponDic){
            if (p.Key == playerId)
            {
                weaponIds = p.Value;
                break;
            }
        }
        //遍历武器 id 集合
        if (null != weaponIds)
        {
            foreach (var w in weaponIds)
            {
                if (w == weaponId)
                {
                    return true;
                }
            }
        }

        return false;
    }
}