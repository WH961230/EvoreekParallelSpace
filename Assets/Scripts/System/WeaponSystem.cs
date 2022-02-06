public class WeaponSystem : MySystem {
    private WeaponControl control;
    public override void OnInit() {
        base.OnInit();
        ControlManager.Instance.AddControl<WeaponControl>();
    }

    public override void OnUpdate() {
        base.OnUpdate();
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