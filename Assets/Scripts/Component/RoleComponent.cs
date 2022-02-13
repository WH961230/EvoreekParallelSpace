using UnityEngine;

public class RoleComponent : AbsComponent
{
    public override void OnInit<T>(AbsControl control, long roleId) {
        base.OnInit<T>(control, roleId);
    }

    public override void OnUpdate() {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.up);
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