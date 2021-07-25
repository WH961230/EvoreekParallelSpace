using UnityEngine;

public class PlayerMgr : Singleton<PlayerMgr> {
    private SOPlayer config;
    private PlayerController controller;
    public void OnInit() {
        // var type = System.Reflection.Assembly.Load("Assembly-CSharp").GetType("SOPlayer");
        // config = (SOPlayer)System.Activator.CreateInstance(type);

        config = (SOPlayer) AssetLoader.LoadAsset(AssetType.Scriptable, "SOPlayer");
        var player = GameObject.Instantiate(AssetLoader.LoadAsset(AssetType.Prefab, config.PlayerSign)) as GameObject;
        player.transform.position = config.PlayerInfo.playerBornVec;
        player.transform.localRotation = config.PlayerInfo.playerBornQua;
        controller = player.GetComponent<PlayerController>();
        
        Debug.Log(config.PlayerSign);
    }
}
