using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AI管理 - AI数据管理
/// </summary>
public class AIManager : Singleton<AIManager>, IBaseManager
{
    private List<AI> AIs = new List<AI>();
    private int id = -1;

    public void OnInit(GameEngine gameEngine)
    {
        gameEngine.managers.Add(this);
        var ao = InitAIObj();
        if (null == ao)
        {
            return;
        }

        var ac = ao.GetComponent<AIController>();
        ac.OnInit();
        ac.AIId = ++id;
        
        var ai = new AI(
            ac.AIId,
            ac.AIName,
            ac,
            ac.hp
        );

        AIs.Add(ai);
    }

    private Transform InitAIObj() {
        //获取预制体
        var ac = ConfigManager.Instance.AIConfig;
        var ao = Object.Instantiate(AssetLoader.LoadAsset(AssetType.Prefab, AssetInfoType.Role, ac.AISign)) as GameObject;
        if (null == ao)
        {
            return null;
        }

        var at = ao.transform;
        at.position = ac.AIBornInfo.AIBornVec;
        at.localRotation = ac.AIBornInfo.AIBornQua;
        return at;
    }

    public AI GetAIById(int id)
    {
        AI ai = null;
        if (null != AIs && AIs.Count > 0)
        {
            foreach (var p in AIs)
            {
                if (p.BaseData.id == id)
                {
                    ai = p;
                }
            }
        }

        return ai;
    }

    public void OnUpdate() {
        if (null != AIs && AIs.Count > 0) {
            for (var i = 0 ; i < AIs.Count ; ++i)
            {
                var ai = AIs[i];
                if (ai != null)
                {
                    var c = ai.BaseData.AIController;
                    if (c != null)
                    {
                        c.OnUpdate();
                    }
                }
            }
        }
    }

    public void OnClear() {
    }
}