using UnityEngine;

public class CameraComponent : AbsComponent {
    private SOCamera mySO;
    private Transform target;
    public override void OnInit<T>(AbsControl control, int roleId) {
        base.OnInit<T>((RoleControl)control, roleId);
        mySO = Loader.Instance.LoadCameraConfig<SOCamera>("SOCamera");
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
    }

    private void OnKeyCodeDown(KeyCode e) {
    }

    private void OnAxis(AxisData data) {
        transform.localRotation *= Quaternion.Euler(new Vector3(data.MouseX, 0, data.MouseY));
    }

    public override void OnUpdate() {
        if (absControl.mySystem.MyAbsWorld)
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