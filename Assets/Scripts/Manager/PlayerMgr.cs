using System.Collections.Generic;
using Data;
using UnityEngine;

/// <summary>
/// 玩家管理 - 全局玩家信息管理
/// </summary>
public class PlayerMgr : Singleton<PlayerMgr> , IBaseMgr{
    private List<BaseController> controllers;
    
    //初始化 - 获取配置
    public void OnInit(GameEngine engine) {
        engine.managers.Add(this);
        MessageCenter.Instance.Register(MessageCode.Game_GameStart, CreatePlayer);
        MessageCenter.Instance.Register(MessageCode.Game_GameOver, OnClear);
        MessageCenter.Instance.Register<int>(MessageCode.Play_Dead, RemovePlayerById);
        controllers = new List<BaseController>();
    }

    //创建
    private void CreatePlayer() {
        var player = Object.Instantiate(AssetLoader.LoadAsset(AssetType.Prefab, ConfigMgr.Instance.playerConfig.PlayerSign)) as GameObject;
        if (null == player) {
            return;
        }
        player.transform.position = ConfigMgr.Instance.playerConfig.PlayerInfo.playerBornVec;
        player.transform.localRotation = ConfigMgr.Instance.playerConfig.PlayerInfo.playerBornQua;

        var controller = player.GetComponent<PlayerController>();
        controller.OnInit();
        
        controllers.Add(controller);
    }

    private void RemovePlayerById(int id) {
        for (var i = 0 ; i < controllers.Count ; ++i) {
            var crl = (PlayerController)controllers[i];
            if (crl.PlayerId == id) {
                controllers[i].OnClear();
                controllers.Remove(crl);
                break;
            }
        }
    }

    //刷新
    public void OnUpdate() {
        if (null != controllers && controllers.Count > 0) {
            for (var i = 0 ; i < controllers.Count ; ++i) {
                controllers[i].OnUpdate();
            }
        }
    }

    public void OnClear() {
        if (null != controllers && controllers.Count > 0) {
            for (var i = 0 ; i < controllers.Count ; ++i) {
                controllers[i].OnClear();
            }
        }
    }
}
