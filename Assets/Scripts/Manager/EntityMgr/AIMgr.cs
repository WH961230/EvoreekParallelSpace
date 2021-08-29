using System.Collections.Generic;

/// <summary>
/// AI管理 - AI数据管理
/// </summary>
public class AIMgr : IBaseMgr
{
    private List<AI> AIs = new List<AI>();

    public void OnInit(GameEngine gameEngine) {
        gameEngine.managers.Add(this);
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
    }

    public void OnClear() {
    }
}