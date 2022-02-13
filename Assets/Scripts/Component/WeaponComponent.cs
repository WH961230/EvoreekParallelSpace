using UnityEngine;

public class WeaponComponent : AbsComponent
{
    public override void OnInit<T>(AbsControl control, long id)
    {
        base.OnInit<T>(control, id);
    }

    public override void OnUpdate() {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left);
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