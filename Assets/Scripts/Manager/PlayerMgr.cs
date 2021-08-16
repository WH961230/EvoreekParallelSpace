using UnityEngine;

/// <summary>
/// 玩家管理 - 全局玩家信息管理
/// </summary>
public class PlayerMgr : Singleton<PlayerMgr> {
    private SOPlayer config;
    private PlayerController controller;
    
    public void OnInit() {
        // var type = System.Reflection.Assembly.Load("Assembly-CSharp").GetType("SOPlayer");
        // config = (SOPlayer)System.Activator.CreateInstance(type);

        EventMgr.Instance.AddEventListener(EventMgr.Instance.MGR_UPDATE, OnUpdate);
        EventMgr.Instance.AddEventListener(EventMgr.Instance.MGR_FIXEDUPDATE, OnFixedUpdate);
        EventMgr.Instance.AddEventListener(EventMgr.Instance.MGR_LATEUPDATE, OnLateUpdate);

        config = (SOPlayer) AssetLoader.LoadAsset(AssetType.Scriptable, "SOPlayer");
        var player = Object.Instantiate(AssetLoader.LoadAsset(AssetType.Prefab, config.PlayerSign)) as GameObject;
        if (null != player)
        {
            player.transform.position = config.PlayerInfo.playerBornVec;
            player.transform.localRotation = config.PlayerInfo.playerBornQua;
            
            controller = player.GetComponent<PlayerController>();
            controller.OnInit();

            //获取 playerId 信息
            var pid = controller.PlayerId;

            EventMgr.Instance.AddEventListener(EventMgr.Instance.CONTROLLER_UPDATE, controller.OnUpdate);
            EventMgr.Instance.AddEventListener(EventMgr.Instance.CONTROLLER_FIXEDUPDATE, controller.OnFixedUpdate);
            EventMgr.Instance.AddEventListener(EventMgr.Instance.CONTROLLER_LATEUPDATE, controller.OnLateUpdate);
        }
    }

    private void OnUpdate()
    {
        //每帧
    }
    public void OnFixedUpdate()
    {
        //每帧
    }

    public void OnLateUpdate()
    {
        //每帧
    }
}
