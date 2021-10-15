using UnityEngine;

public class PlayerData : DataBase{
    private PlayerManager playerManager;
    private PlayerScriptableObject playerConfig;

    public override void OnInit(GameEngine gameEngine) {
        base.OnInit(gameEngine);
    }

    public override void OnUpdate() {
        base.OnUpdate();
    }

    protected override void InitMgr() {
        base.InitMgr();
        playerManager = new PlayerManager();
    }

    protected override void InitConfig() {
        base.InitConfig();
        playerConfig = (PlayerScriptableObject)AssetLoader.LoadAsset(AssetType.Scriptable, AssetInfoType.Role, "SOPlayer");
    }

    public Player InitStartPlayer() {
        var obj = AssetLoader.LoadAsset(AssetType.Prefab, AssetInfoType.Role, playerConfig.PlayerSign);
        var playerObj = (GameObject)Object.Instantiate(obj);
        if (null == playerObj) {
            return null;
        }

        playerObj.transform.position = playerConfig.PlayerInfo.playerBornVec;
        playerObj.transform.localRotation = playerConfig.PlayerInfo.playerBornQua;

        var controller = playerObj.GetComponent<PlayerController>();
        controller.OnInit();
        controller.playerId
        
    }

    public override void OnClear() {
        base.OnClear();
    }
}