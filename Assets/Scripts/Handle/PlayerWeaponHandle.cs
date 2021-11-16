using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class PlayerWeaponHandle : Singleton<PlayerWeaponHandle>
{
    //玩家所有武器字典
    private Dictionary<int,List<int>> PlayerWeaponDic = new Dictionary<int, List<int>>();
    //当前武器字典
    private Dictionary<int,int> PlayerWeaponCurDic = new Dictionary<int, int>();

    /// <summary>
    /// 设置玩家当前武器
    /// </summary>
    /// <param name="playerId"></param>
    /// <param name="weaponId"></param>
    public void PlayerSetCurWeapon(int playerId, int weaponId)
    {
        //是否有武器
        var hasWeapon = PlayerHasWeapon(playerId, weaponId);
        if (hasWeapon)
        {
            //是否存在玩家键值对
            if (PlayerWeaponCurDic.ContainsKey(playerId))
            {
                //设置玩家当前武器键值对
                PlayerWeaponCurDic[playerId] = weaponId;
            }
            else
            {
                //创建玩家键值对
                PlayerWeaponCurDic.Add(playerId, weaponId);
            }

            // Debug.LogFormat("设置当前武器：玩家 {0} 武器 {1}", 
                // PlayerManager.Instance.GetPlayerNameById(playerId),
                // WeaponManager.Instance.GetWeaponInfoById(weaponId));
        }
    }
    
    /// <summary>
    /// 获取玩家当前武器
    /// </summary>
    /// <param name="playerId"></param>
    /// <param name="weaponId"></param>
    public int PlayerGetCurWeapon(int playerId)
    {
        var weaponId = -1;
        //是否存在玩家键值对
        if (PlayerWeaponCurDic.ContainsKey(playerId))
        {
            //设置玩家当前武器键值对
            weaponId = PlayerWeaponCurDic[playerId];
        }
        return weaponId;
    }
    
    /// <summary>
    /// 删除玩家当前武器
    /// </summary>
    /// <param name="playerId"></param>
    /// <param name="weaponId"></param>
    private void PlayerRemoveCurWeapon(int playerId)
    {
        //是否存在玩家键值对
        if (PlayerWeaponCurDic.ContainsKey(playerId))
        {
            // Debug.LogFormat("删除当前武器：玩家 {0} 武器 {1}", 
            //     PlayerManager.Instance.GetPlayerNameById(playerId), 
            //     WeaponManager.Instance.GetWeaponInfoById(PlayerWeaponCurDic[playerId])
            // );
            //设置玩家当前武器键值对
            PlayerWeaponCurDic[playerId] = -1;
        }
    }

    public void PlayerDropWeapon(int playerId)
    {
        /*var player = PlayerManager.Instance.GetPlayerById(playerId);
        if (null == player)//玩家没找到
        {
            return;
        }
    
        var weaponId = PlayerGetCurWeapon(playerId);
        if (weaponId == -1)//当前武器为空
        {
            return;
        }
        //移除当前武器
        PlayerRemoveCurWeapon(playerId);
        
        var alreadyHave = PlayerHasWeapon(playerId, weaponId);
        if (!alreadyHave)//玩家不存在当前武器
        {
            return;
        }
        var weaponIds = PlayerWeaponDic[playerId];
        //武器集合中移除该武器
        weaponIds.Remove(weaponId);
        //字典增加
        PlayerWeaponDic[playerId] = weaponIds;
        //表现 丢弃武器
        var weaponTran = WeaponManager.Instance.GetWeaponById(weaponId).BaseData.weaponController.transform;
        player.BaseData.playerController.DropWeapon(weaponTran);
        Debug.LogFormat("丢弃当前武器：玩家 {0} 武器 {1}", 
            PlayerManager.Instance.GetPlayerNameById(playerId), 
            WeaponManager.Instance.GetWeaponInfoById(weaponId)
        );*/
    }

    public void PlayerPickWeapon(int playerId, int weaponId)
    {
        /*var player = PlayerManager.Instance.GetPlayerById(playerId);
        var weapon = WeaponManager.Instance.GetWeaponById(weaponId);
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
            //装备武器表现
            player.BaseData.playerController.WeaponNormalHandle(weapon.BaseData.weaponController);
            //第一把 设置为当前武器
            PlayerSetCurWeapon(playerId, weaponId);
            Debug.LogFormat("拾起武器：玩家 {0} 武器 {1}", 
                PlayerManager.Instance.GetPlayerNameById(playerId), 
                WeaponManager.Instance.GetWeaponInfoById(weaponId)
            );
            return;
        }
        
        //玩家是否已有武器
        var alreadyHave = PlayerHasWeapon(playerId, weaponId);
        if (!alreadyHave)
        {
            var weaponIds = PlayerWeaponDic[playerId];
            weaponIds.Add(weaponId);
            //字典增加
            PlayerWeaponDic[playerId] = weaponIds;
            //表现 - 持有武器
            player.BaseData.playerController.WeaponNormalHandle(weapon.BaseData.weaponController);
            PlayerSetCurWeapon(playerId, weaponId);
            Debug.LogFormat("拾起武器：玩家 {0} 武器 {1}", 
                PlayerManager.Instance.GetPlayerNameById(playerId), 
                WeaponManager.Instance.GetWeaponInfoById(weaponId)
            );
        }*/
    }

    /// <summary>
    /// 是否已装备武器
    /// </summary>
    /// <param name="playerId"></param>
    /// <param name="weaponId"></param>
    /// <returns></returns>
    private bool PlayerHasWeapon(int playerId, int weaponId)
    {
        var hasWeapon = false;
        if (PlayerWeaponDic.ContainsKey(playerId))
        {
            var values = PlayerWeaponDic[playerId];
            hasWeapon = values.Contains(weaponId);
        }
        return hasWeapon;
    }
}