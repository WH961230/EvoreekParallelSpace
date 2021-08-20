using System.Collections.Generic;
using Data;
using UnityEngine;

public class PlayerData {
    public int id;
    public string name;
    public bool isLocalPlayer;
    public PlayerController controller;
}

/// <summary>
/// 玩家管理 - 全局玩家信息管理
/// </summary>
public class PlayerMgr : Singleton<PlayerMgr> , IBaseMgr{
    private static List<PlayerData> allPlayers;

    public static List<PlayerData> AllPlayers {
        get => allPlayers;
        set => allPlayers = value;
    }
    
    public static PlayerData GetLocalPlayer {
        get {
            PlayerData data = null;
            if (null == AllPlayers || AllPlayers.Count <= 0) {
                return data;
            }

            foreach (var p in AllPlayers) {
                if (p.isLocalPlayer) {
                    data = p;
                    break;
                }
            }

            return data;
        }
    }

    public static int GetLocalPlayerId
    {
        get
        {
            int id = -1;
            if (null == AllPlayers || AllPlayers.Count <= 0) {
                return id;
            }

            foreach (var p in AllPlayers) {
                if (p.isLocalPlayer) {
                    id = p.id;
                    break;
                }
            }

            return id;
        }
    }
    
    //初始化 - 获取配置
    public void OnInit(GameEngine engine) {
        engine.managers.Add(this);
        
        MessageCenter.Instance.Register(MessageCode.Game_GameStart, CreatePlayer);
        MessageCenter.Instance.Register(MessageCode.Game_GameOver, OnClear);
        MessageCenter.Instance.Register<int>(MessageCode.Play_Dead, RemoveControllerById);
        
        AllPlayers = new List<PlayerData>();
    }

    private void CreatePlayer() {
        var player = Object.Instantiate(AssetLoader.LoadAsset(AssetType.Prefab, ConfigMgr.Instance.playerConfig.PlayerSign)) as GameObject;
        if (null == player) {
            return;
        }
        player.transform.position = ConfigMgr.Instance.playerConfig.PlayerInfo.playerBornVec;
        player.transform.localRotation = ConfigMgr.Instance.playerConfig.PlayerInfo.playerBornQua;

        var controller = player.GetComponent<PlayerController>();
        controller.OnInit();
        
        var playerData = new PlayerData()
        {
            id = controller.PlayerId,
            name = controller.name,
            controller = controller,
            isLocalPlayer = true,
        };
        
        allPlayers.Add(playerData);
    }

    public PlayerController GetControllerById(int id)
    {
        if (null == allPlayers || allPlayers.Count <= 0) return null;
        PlayerController controller = null;
        foreach (var c in allPlayers)
        {
            if (c.id == id)
            {
                controller = c.controller;
                break;
            }
        }

        return controller;
    }

    private void RemoveControllerById(int id) {
        for (var i = 0 ; i < allPlayers.Count ; ++i) {
            if (allPlayers[i] != null)
            {
                var crl = allPlayers[i];
                if (crl.id == id) {
                    crl.controller.OnClear();
                    allPlayers.Remove(crl);
                    break;
                }
            }
        }
    }

    public void OnUpdate() {
        if (null != allPlayers && allPlayers.Count > 0) {
            for (var i = 0 ; i < allPlayers.Count ; ++i)
            {
                var data = allPlayers[i];
                if (data != null)
                {
                    var controller = data.controller;
                    if (controller != null)
                    {
                        controller.OnUpdate();
                    }
                };
            }
        }
    }

    public void OnClear() {
        if (null != allPlayers && allPlayers.Count > 0) {
            for (var i = 0 ; i < allPlayers.Count ; ++i)
            {
                var data = allPlayers[i];
                if (data != null)
                {
                    var controller = data.controller;
                    if (controller != null)
                    {
                        controller.OnClear();
                    }
                };
            }
        }
    }
}
