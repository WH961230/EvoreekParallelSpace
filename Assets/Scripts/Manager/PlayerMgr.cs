using UnityEngine;

/// <summary>
/// 玩家管理 - 全局玩家信息管理
/// </summary>
public class PlayerMgr : Singleton<PlayerMgr> {
    private SOPlayer config;
    private PlayerController controller;
    
    public void OnInit() {
        MessageCenter.Instance.AddEventListener(MessageCenter.Instance.MGR_UPDATE, OnUpdate);
        MessageCenter.Instance.AddEventListener(MessageCenter.Instance.MGR_FIXEDUPDATE, OnFixedUpdate);
        MessageCenter.Instance.AddEventListener(MessageCenter.Instance.MGR_LATEUPDATE, OnLateUpdate);

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

            MessageCenter.Instance.AddEventListener(MessageCenter.Instance.CONTROLLER_UPDATE, controller.OnUpdate);
            MessageCenter.Instance.AddEventListener(MessageCenter.Instance.CONTROLLER_FIXEDUPDATE, controller.OnFixedUpdate);
            MessageCenter.Instance.AddEventListener(MessageCenter.Instance.CONTROLLER_LATEUPDATE, controller.OnLateUpdate);
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
