using UnityEngine;

public class PlayerOperateController : Singleton<PlayerOperateController>, IBaseController
{
    public PlayerOperateWin PlayerOperateWin
    {
        get
        {
            if (null == PlayerOperateWin)
            {
                return Object.FindObjectOfType<PlayerOperateWin>();
            }

            return PlayerOperateWin;
        }
    }
    
    
    public void OnInit()
    {
    }

    public void OnUpdate()
    {
    }

    public void OnFixedUpdate()
    {
    }

    public void OnLateUpdate()
    {
    }

    public void OnClear()
    {
    }
}