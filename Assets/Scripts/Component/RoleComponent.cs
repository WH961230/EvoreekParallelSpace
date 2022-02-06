using UnityEngine;

public class RoleComponent : MyComponent
{
    public override void OnUpdate() {
        base.OnUpdate();
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