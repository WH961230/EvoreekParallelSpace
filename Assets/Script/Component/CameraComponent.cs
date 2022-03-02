using UnityEngine;

public class CameraComponent : AbsComponent {
    private SOCamera mySO;
    private Transform target;
    public override void OnInit<T>(AbsControl control, int roleId) {
        base.OnInit<T>((RoleControl)control, roleId);
        mySO = Loader.Instance.LoadCameraConfig<SOCamera>("SOCamera");
    }

    public override void OnUpdate() {
        LookAtTargetEvent();
    }

    private void LookAtTargetEvent() {
        var role = WorldData.role;
        if (null != role) {
            var roleComponent = absControl.manager.GetComponent<RoleComponent>(role.ComponentId);
            transform.position = roleComponent.transform.position;
        }
    }

    public override void OnFixedUpdate() {
        base.OnFixedUpdate();
    }

    public override void OnLateUpdate() {
        base.OnLateUpdate();
    }

    public override void OnClear() {
        base.OnClear();
    }
}