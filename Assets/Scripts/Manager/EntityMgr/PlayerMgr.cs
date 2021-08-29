using System.Collections.Generic;
using Data;
using UnityEngine;

/// <summary>
/// 玩家管理 - 玩家数据管理
/// </summary>
public class PlayerMgr : Singleton<PlayerMgr> , IBaseMgr{
    private List<Player> Players = new List<Player>();
    private int id = -1;

    public Player GetPlayerById(int id)
    {
        Player player = null;
        if (null != Players && Players.Count > 0)
        {
            foreach (var p in Players)
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
    /// 初始化 - 获取配置
    /// </summary>
    /// <returns></returns>
    public void OnInit(GameEngine engine) {
        engine.managers.Add(this);
        //消息注册
        MessageCenter.Instance.Register(MessageCode.Game_GameStart, InitPlayer);
        MessageCenter.Instance.Register(MessageCode.Game_GameOver, OnClear);
        MessageCenter.Instance.Register<int>(MessageCode.Play_Dead, RemovePlayerById);
    }

    /// <summary>
    /// 创建玩家
    /// </summary>
    private void InitPlayer()
    {
        var po = InitPlayerObj();
        if (null == po)
        {
            return;
        }

        var pc = po.GetComponent<PlayerController>();
        pc.OnInit();
        pc.playerId = ++id;
        
        var player = new Player(
            pc.playerId,
            pc.playerName,
            pc
        );

        Players.Add(player);
        GameData.LockPlayer = player;
    }

    private Transform InitPlayerObj()
    {
        //获取预制体
        var pc = ConfigMgr.Instance.playerConfig;
        var po = Object.Instantiate(AssetLoader.LoadAsset(AssetType.Prefab, pc.PlayerSign)) as GameObject;
        if (null == po)
        {
            return null;
        }

        var pt = po.transform;
        pt.position = pc.PlayerInfo.playerBornVec;
        pt.localRotation = pc.PlayerInfo.playerBornQua;
        return pt;
    }

    /// <summary>
    /// 移除指定的玩家
    /// </summary>
    /// <param name="id"></param>
    private void RemovePlayerById(int id) {
        for (var i = 0 ; i < Players.Count ; ++i) {
            if (Players[i] != null)
            {
                var p = Players[i];
                if (p.BaseData.id == id) {
                    p.OnClear();
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
                    var c = p.BaseData.playerController;
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
                    var c = p.BaseData.playerController;
                    if (c != null)
                    {
                        c.OnClear();
                    }
                };
            }
        }
    }
}
