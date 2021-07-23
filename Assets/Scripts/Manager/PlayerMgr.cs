using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMgr : Singleton<PlayerMgr> {
    private SOPlayer config;
    private PlayerController controller;
    public void OnInit() {
        // var type = System.Reflection.Assembly.Load("Assembly-CSharp").GetType("SOPlayer");
        // config = (SOPlayer)System.Activator.CreateInstance(type);

        config = (SOPlayer) AssetLoader.LoadAsset(AssetType.Scriptable, "SOPlayer");
        var player = GameObject.Instantiate(AssetLoader.LoadAsset(AssetType.Prefab, config.PlayerSign), config.PlayerBornTran);
        controller = player.GetComponent<PlayerController>();

        Debug.Log(config.PlayerSign);
    }
}
