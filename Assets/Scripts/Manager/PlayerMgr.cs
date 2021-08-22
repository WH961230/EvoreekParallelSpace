using System.Collections.Generic;
using Data;
using UnityEngine;


/// <summary>
/// 玩家管理 - 玩家数据管理
/// </summary>
public class PlayerMgr : Singleton<PlayerMgr> , IBaseMgr{
    public List<Player> Players = new List<Player>();
    
    /// <summary>
    /// 获取本地角色
    /// </summary>
    public Player GetLocalPlayer {
        get {
            Player player = null;
            if (null == Players || Players.Count <= 0) {
                return player;
            }

            foreach (var p in Players) {
                if (p.BaseData.Type == PlayerType.LocalPlayer) {
                    player = p;
                    break;
                }
            }

            return player;
        }
    }

    public int GetLocalPlayerId
    {
        get
        {
            int id = -1;
            if (null == Players || Players.Count <= 0) {
                return id;
            }

            foreach (var p in Players) {
                if (p.BaseData.Type == PlayerType.LocalPlayer) {
                    id = p.BaseData.Id;
                    break;
                }
            }

            return id;
        }
    }
    
    /// <summary>
    /// 初始化 - 获取配置
    /// </summary>
    /// <returns></returns>
    public void OnInit(GameEngine engine) {
        engine.managers.Add(this);
        
        //消息注册
        MessageCenter.Instance.Register(MessageCode.Game_GameStart, InitPlayer);
        MessageCenter.Instance.Register(MessageCode.Game_GameOver, OnClear);
        MessageCenter.Instance.Register<int>(MessageCode.Play_Dead, RemoveControllerById);
    }

    /// <summary>
    /// 创建玩家
    /// </summary>
    private void InitPlayer() {
        //获取预制体
        var playerObj = Object.Instantiate(AssetLoader.LoadAsset(AssetType.Prefab, ConfigMgr.Instance.playerConfig.PlayerSign)) as GameObject;
        if (null == playerObj) {
            return;
        }

        playerObj.transform.position = ConfigMgr.Instance.playerConfig.PlayerInfo.playerBornVec;
        playerObj.transform.localRotation = ConfigMgr.Instance.playerConfig.PlayerInfo.playerBornQua;

        var pc = playerObj.GetComponent<PlayerController>();
        pc.OnInit();
        
        var player = new Player(1,"测试", PlayerType.LocalPlayer, pc);
        Players.Add(player);
    }

    public PlayerController GetControllerById(int id)
    {
        if (null == Players || Players.Count <= 0) return null;
        PlayerController controller = null;
        foreach (var c in Players)
        {
            if (c.BaseData.Id == id)
            {
                controller = c.BaseData.PlayerController;
                break;
            }
        }

        return controller;
    }

    /// <summary>
    /// 移除指定的玩家
    /// </summary>
    /// <param name="id"></param>
    private void RemoveControllerById(int id) {
        for (var i = 0 ; i < Players.Count ; ++i) {
            if (Players[i] != null)
            {
                var p = Players[i];
                if (p.BaseData.Id == id) {
                    p.BaseData.PlayerController.OnClear();
                    Players.Remove(p);
                    break;
                }
            }
        }
    }

    public void OnUpdate() {
        if (null != Players && Players.Count > 0) {
            for (var i = 0 ; i < Players.Count ; ++i)
            {
                var p = Players[i];
                if (p != null)
                {
                    var c = p.BaseData.PlayerController;
                    if (c != null)
                    {
                        c.OnUpdate();
                    }
                }
            }
        }
    }

    public void OnClear() {
        if (null != Players && Players.Count > 0) {
            for (var i = 0 ; i < Players.Count ; ++i)
            {
                var p = Players[i];
                if (p != null)
                {
                    var c = p.BaseData.PlayerController;
                    if (c != null)
                    {
                        c.OnClear();
                    }
                };
            }
        }
    }
}
