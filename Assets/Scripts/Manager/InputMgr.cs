using UnityEngine;

/// <summary>
/// 输入类 - 注册到 EventMgr 供 GameMgr 全局调用
/// </summary>
public class InputMgr : MonoBehaviour
{
    //输入开关 - 默认开启
    private bool IsOpenInput = true;
    //当前输入键值
    private KeyCode currentKey;

    public void OnInit()
    {
        MessageCenter.Instance.AddEventListener(MessageCenter.Instance.MGR_UPDATE, OnUpdate);
        MessageCenter.Instance.AddEventListener(MessageCenter.Instance.MGR_FIXEDUPDATE, OnFixedUpdate);
        MessageCenter.Instance.AddEventListener(MessageCenter.Instance.MGR_LATEUPDATE, OnLateUpdate);
    }

    public void OnUpdate()
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

    private void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameData.player.JumpTrigger = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            GameData.player.JumpTrigger = false;
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
        
        if (Input.GetMouseButtonDown(0)) 
        {
            GameData.player.ShotTrigger = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            GameData.player.ShotTrigger = false;
        }
        
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            GameData.player.RunTrigger = true;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            GameData.player.RunTrigger = false;
        }
    }
}
