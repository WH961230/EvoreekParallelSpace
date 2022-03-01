public class AISystem : AbsSystem{
    public override void OnInit(AbsWorld absWorld) {
        base.OnInit(absWorld);
        manager.AddControl<AIControl>();
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