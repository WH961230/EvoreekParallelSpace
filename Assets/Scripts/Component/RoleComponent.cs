using UnityEngine;

public class RoleComponent : AbsComponent {
    private long comId;
    public void OnInit<T> (IControlBase controlBase, long comId) where T : IComponentBase, new(){
        base.OnInit<T>(controlBase, comId);
    }

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