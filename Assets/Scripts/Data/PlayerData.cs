using System.Collections.Generic;
using UnityEngine;

public class PlayerData : DataBase
{
    private PlayerManager playerManager;
    private PlayerScriptableObject config;
    private List<PlayerController> controllers;

    private const string SO_PLAYER = "SOPlayer";

    public override void OnInit(GameEngine gameEngine)
    {
        base.OnInit(gameEngine);
        playerManager = new PlayerManager();
        MyManagerBase = playerManager;
        config = (PlayerScriptableObject) AssetLoader.LoadAsset(AssetType.Scriptable, AssetInfoType.Role, SO_PLAYER);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (null != controllers && controllers.Count > 0)
        {
            foreach (var controller in controllers)
            {
                controller.OnUpdate();
            }
        }
    }

    public void InitPlayer()
    {
        var playerObj = AssetLoader.LoadAsset(AssetType.Prefab, AssetInfoType.Role, config.PlayerSign, true);

        playerObj.transform.position = config.PlayerInfo.playerBornVec;
        playerObj.transform.localRotation = config.PlayerInfo.playerBornQua;

        var controller = playerObj.GetComponent<PlayerController>();
        if (null != controller)
        {
            controllers.Add(controller);
            var player = playerManager.InitPlayer(config.PlayerSign, controller, config.MaxHp);
            controller.OnInit(player);
        }
    }

    public void ClearPlayers(int[] playerIds)
    {
        playerManager.RemovePlayer(playerIds);
    }

    public override void OnClear()
    {
        base.OnClear();
    }
}