public class RoleSystem : MySystem {
    public override void OnInit()
    {
        base.OnInit();
        ControlManager.Instance.AddControl<RoleControl>();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
    }

    public override void OnLateUpdate()
    {
        base.OnLateUpdate();
    }

    public override void OnClear()
    {
        base.OnClear();
    }
}