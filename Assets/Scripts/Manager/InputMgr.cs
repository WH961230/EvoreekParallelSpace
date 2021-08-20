using Data;
using UnityEngine;

/// <summary>
/// 输入类 - 注册到 EventMgr 供 GameMgr 全局调用
/// </summary>
public class InputMgr : Singleton<InputMgr> , IBaseMgr
{
    //输入开关 - 默认开启
    private bool IsOpenInput = true;
    //当前输入键值
    private KeyCode currentKey;

    public void OnInit(GameEngine engine)
    {
        engine.managers.Add(this);
    }

    public void OnUpdate() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MessageCenter.Instance.Dispatcher(MessageCode.Play_Jump);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Cursor.lockState = CursorLockMode.Locked; // 当按下 A 键时，鼠标锁定并消失
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Cursor.lockState = CursorLockMode.None; // 当按下 S 键时，鼠标解锁并显示
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            Cursor.lockState = CursorLockMode.Locked; // 当按下 A 键时，鼠标锁定并消失
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            MessageCenter.Instance.Dispatcher<int>(MessageCode.Play_Dead, GameData.GetLocalPlayer.id);
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            MessageCenter.Instance.Dispatcher(MessageCode.Game_GameOver);
        }
        
        if (Input.GetMouseButtonDown(0)) 
        {
            MessageCenter.Instance.Dispatcher(MessageCode.Play_Shot);
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            GameData.GetLocalPlayer.controller.RunTrigger = true;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            GameData.GetLocalPlayer.controller.RunTrigger = false;
        }
    }

    public void OnClear() {
    }
}
