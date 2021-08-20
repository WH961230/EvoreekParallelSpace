using Data;
using UnityEngine;

/// <summary>
/// 输入类 - 注册到 EventMgr 供 GameMgr 全局调用
/// </summary>
public class InputMgr : Singleton<InputMgr> , IBaseMgr
{
    private bool IsOpenInput = true;

    public void OnInit(GameEngine engine)
    {
        engine.managers.Add(this);
    }

    public void OnUpdate() {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Cursor.lockState = (Cursor.lockState == CursorLockMode.Locked)
                ? CursorLockMode.None
                : CursorLockMode.Locked;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var data = PlayerMgr.GetLocalPlayer;
            if (data != null)
            {
                var controller = data.controller;
                if (controller != null)
                {
                    MessageCenter.Instance.Dispatcher(MessageCode.Play_Jump);
                }
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            var data = PlayerMgr.GetLocalPlayer;
            if (data != null)
            {
                var controller = data.controller;
                if (controller != null)
                {
                    controller.isRun = true;
                }
            }
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            var data = PlayerMgr.GetLocalPlayer;
            if (data != null)
            {
                var controller = data.controller;
                if (controller != null)
                {
                    controller.isRun = false;
                }
            }
        }

        if (Input.GetMouseButtonDown(0)) 
        {
            MessageCenter.Instance.Dispatcher(MessageCode.Play_Shot);
        }
    }

    public void OnClear() {
    }
}
