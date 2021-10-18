using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家管理 - 玩家数据管理
/// </summary>
public class PlayerManager : ManagerBase{
    private List<Player> players = new List<Player>();
    public int id = -1;

    public Player GetPlayerById(int id)
    {
        Player player = null;
        if (null != players && players.Count > 0)
        {
            foreach (var p in players)
            {
                if (p.BaseData.id == id)
                {
                    player = p;
                }
            }
        }

        return player;
    }
    /// <summary>
    /// 获取玩家名字
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetPlayerNameById(int id)
    {
        return GetPlayerById(id).BaseData.name + " ["+ id + "]";
    }

    /// <summary>
    /// 创建玩家
    /// </summary>
    public Player InitPlayer(string name, PlayerController controller, int hp) {
        var player = new Player(
            ++id,
            name,
            controller,
            hp
        );
        
        player.OnInit();
        players.Add(player);
        GameData.LockPlayer = player;
        return player;
    }

    /// <summary>
    /// 移除指定的玩家
    /// </summary>
    /// <param name="id"></param>
    public void RemovePlayerById(int id) ,{
        for (var i = 0 ; i < players.Count ; ++i) {
            if (null != players[i])
            {
                var p = players[i];
                if (p.BaseData.id == id) {
                    p.OnClear();
                    players.Remove(p);
                    break;
                }
            }
        }
    }

    public void OnUpdate() {
        if (null != players && players.Count > 0) {
            for (var i = 0 ; i < players.Count ; ++i)
            {
                var p = players[i];
                if (null != p)
                {
                    var c = p.BaseData.playerController;
                    if (null != c)
                    {
                        c.OnUpdate();
                    }
                }
            }
        }
    }

    public void OnClear() {
        if (null != players && players.Count > 0) {
            for (var i = 0 ; i < players.Count ; ++i)
            {
                var p = players[i];
                if (null != p)
                {
                    var c = p.BaseData.playerController;
                    if (null != c)
                    {
                        c.OnClear();
                    }
                };
            }
        }
    }
    
        
    private bool Has(int id) {
        foreach (var player in players) {
            if (player.BaseData.id == id) {
                return true;
            }
        }

        return false;
    }

    public void Add(Player player) {
        if (!Has(player.BaseData.id)) {
            players.Add(player);
        }
    }

    public void RemovePlayer(int[] ids) {
        foreach (var id in ids) {
            foreach (var player in players) {
                if (player.BaseData.id == id) {
                    players.Remove(player);
                    break;
                }
            } 
        }
    }

    public void UpdatePlayer(Player updatePlayer) {
        foreach (var player in players) {
            if (player.BaseData.id == updatePlayer.BaseData.id) {
                players.Remove(player);
                Add(updatePlayer);
                break;
            }
        }
    }

    public Player GetPlayer(int id) {
        foreach (var player in players) {
            if (player.BaseData.id == id) {
                return player;
            }
        }

        return null;
    }
}
