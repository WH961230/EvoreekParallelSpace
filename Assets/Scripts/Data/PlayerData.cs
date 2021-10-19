using System.Collections.Generic;
using UnityEngine;

public class PlayerData : DataBase{
    private PlayerManager manager;
    private PlayerScriptableObject config;
    private List<PlayerController> controllers;
    public override void OnInit(GameEngine gameEngine) {
        base.OnInit(gameEngine);
    }

    public override void OnUpdate() {
        base.OnUpdate();
        if (null != controllers && controllers.Count > 0) {
            foreach (var controller in controllers) {
                controller.OnUpdate();
            }
        }
    }

    protected override void InitManager() {
        base.InitManager();
        manager = new PlayerManager();
    }

    protected override void InitConfig() {
        base.InitConfig();
        config = (PlayerScriptableObject)AssetLoader.LoadAsset(AssetType.Scriptable, AssetInfoType.Role, "SOPlayer");
    }

    public void InitPlayer() {
        var obj = AssetLoader.LoadAsset(AssetType.Prefab, AssetInfoType.Role, config.PlayerSign);
        var playerObj = (GameObject)Object.Instantiate(obj);
        if (null == playerObj) {
            return;
        }

        playerObj.transform.position = config.PlayerInfo.playerBornVec;
        playerObj.transform.localRotation = config.PlayerInfo.playerBornQua;

        var controller = playerObj.GetComponent<PlayerController>();
        if (null != controller) {
            controllers.Add(controller);
            var player = manager.InitPlayer(config.PlayerSign, controller, config.MaxHp);
            controller.OnInit(player);
        }
    }

    public void ClearPlayer(int[] playerIds) {
        manager.RemovePlayer(playerIds);
    }

    public override void OnClear() {
        base.OnClear();
    }
}