using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家管理 - 玩家数据管理
/// </summary>
public class PlayerManager : ManagerBase{
    private List<Player> players = new List<Player>();
    private int id = -1;

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

    public override void OnInit(GameEngine gameEngine) {
        base.OnInit(gameEngine);
    }

    public override void OnUpdate() {
        base.OnUpdate();
    }

    public override void OnClear() {
        base.OnClear();
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
