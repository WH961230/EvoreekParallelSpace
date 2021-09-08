using Data;
using UnityEngine;

/// <summary>
/// 输入类 - 注册到 EventMgr 供 GameMgr 全局调用
/// </summary>
public class InputMgr : Singleton<InputMgr>, IBaseMgr {
    private bool IsOpenInput = true;

    public struct InputData {
        public float mouseX;
        public float mouseY;
        public float horizontal;
        public float vertical;
    }
    
    public void OnInit(GameEngine engine) {
        engine.managers.Add(this);
    }

    public void OnUpdate() {
        var p = GameData.LockPlayer;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Cursor.lockState = (Cursor.lockState == CursorLockMode.Locked)
                ? CursorLockMode.None
                : CursorLockMode.Locked;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (p != null) {
                var c = p.BaseData.playerController;
                if (c != null) {
                    c.JumpInput = true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.F)) {
            MessageCenter.Instance.Dispatcher(MessageCode.Play_PickWeapon);
        }

        if (Input.GetKeyDown(KeyCode.G)) {
            MessageCenter.Instance.Dispatcher(MessageCode.Play_DropWeapon);
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            if (p != null) {
                var c = p.BaseData.playerController;
                if (c != null) {
                    c.JumpInput = false;
                }
            }
        }

        if (Input.GetKey(KeyCode.LeftShift)) {
            if (p != null) {
                var c = p.BaseData.playerController;
                if (c != null) {
                    c.RunInput = true;
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            if (p != null) {
                var c = p.BaseData.playerController;
                if (c != null) {
                    c.RunInput = false;
                }
            }
        }

        if (Input.GetMouseButtonDown(0)) {
            MessageCenter.Instance.Dispatcher(MessageCode.Play_Attack);
        }
        
        if (Input.GetMouseButtonDown(1)) {
            MessageCenter.Instance.Dispatcher(MessageCode.Play_Aim);
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            MessageCenter.Instance.Dispatcher(MessageCode.Play_Reload);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }

        if (Mathf.Abs(Input.GetAxis("Mouse X")) > 0.001f ||
            Mathf.Abs(Input.GetAxis("Mouse Y")) > 0.001f ||
            Mathf.Abs(Input.GetAxis("Horizontal")) > 0.001f||
            Mathf.Abs(Input.GetAxis("Vertical")) > 0.001f) {

            var inputData = new InputData() {
                mouseX = Input.GetAxis("Mouse X"),
                mouseY = Input.GetAxis("Mouse Y"),
                horizontal = Input.GetAxis("Horizontal"),
                vertical = Input.GetAxis("Vertical")
            };
            MessageCenter.Instance.Dispatcher(MessageCode.Game_InputData, inputData);
        } else {
            MessageCenter.Instance.Dispatcher(MessageCode.Game_InputData, new InputData());
        }
    }

    public void OnClear() {
    }
}