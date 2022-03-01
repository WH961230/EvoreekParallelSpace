using UnityEngine;

public class RoleComponent : AbsComponent {
    private SORole mySO;
    public override void OnInit<T>(AbsControl control, int roleId) {
        base.OnInit<T>((RoleControl)control, roleId);
        //后期替换字符串为  txt 文本 需要完善 RoleConfig
        mySO = Loader.Instance.LoadRoleConfig<SORole>("SORole");
        RegisterMessage();
    }

    private void RegisterMessage() {
        MessageCenter.RegisterMessage<KeyCode>(MessageCode.OnKeyCodeDown, OnKeyCodeDown);
        MessageCenter.RegisterMessage<KeyCode>(MessageCode.OnKeyCode, OnKeyCode);
        MessageCenter.RegisterMessage<AxisData>(MessageCode.OnAxis, OnAxis);
    }

    private void UnRegisterMessage() {
        MessageCenter.UnRegisterMessage(MessageCode.OnKeyCodeDown);
        MessageCenter.UnRegisterMessage(MessageCode.OnKeyCode);
        MessageCenter.UnRegisterMessage(MessageCode.OnAxis);
    }

    private void OnKeyCode(KeyCode e) {
        if (e == KeyCode.W) {
            transform.Translate(Vector3.forward * mySO.MoveSpeed_Forward);
        } else if (e == KeyCode.A) {
            transform.Translate(Vector3.left * mySO.MoveSpeed_Left);
        } else if (e == KeyCode.S) {
            transform.Translate(Vector3.back * mySO.MoveSpeed_Back);
        } else if (e == KeyCode.D) {
            transform.Translate(Vector3.right * mySO.MoveSpeed_Right);
        }
    }
    
    private void OnKeyCodeDown(KeyCode e) {
    }

    private void OnAxis(AxisData data) {
        transform.localRotation *= Quaternion.Euler(new Vector3(data.MouseX, 0, data.MouseY));
    }

    public override void OnUpdate() {
    }

    public override void OnFixedUpdate() {
        base.OnFixedUpdate();
    }

    public override void OnLateUpdate() {
        base.OnLateUpdate();
    }

    public override void OnClear() {
        UnRegisterMessage();
        base.OnClear();
    }
}