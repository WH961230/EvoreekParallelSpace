using System;

public interface ISystemBase {
    void OnInit(IWorld world);
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnClear();
}

public abstract class AbsSystem : ISystemBase {
    protected World world;

    public virtual void OnInit(IWorld world) {
        this.world = (World)world;
    }

    public virtual void OnUpdate() {
    }

    public virtual void OnFixedUpdate() {
    }

    public virtual void OnLateUpdate() {
    }

    public virtual void OnClear() {
    }
}

public class MySystem : AbsSystem {
    public Action OnUpdateAction;
    public Action OnFixedUpdateAction;
    public Action OnLateUpdateAction;

    public override void OnInit(IWorld worldMaster) {
        base.OnInit(worldMaster);
        ControlManager.Instance.OnInit(this);
        //不限时间周期
        ControlManager.Instance.AddControl<RoleControl>();
        ControlManager.Instance.AddControl<WeaponConatrol>();
    }

    public override void OnUpdate() {
        base.OnUpdate();
        OnUpdateAction?.Invoke();
    }

    public override void OnFixedUpdate() {
        base.OnFixedUpdate();
        OnFixedUpdateAction?.Invoke();
    }

    public override void OnLateUpdate() {
        base.OnLateUpdate();
        OnLateUpdateAction?.Invoke();
    }

    public override void OnClear() {
        ControlManager.Instance.OnClear();
        base.OnClear();
    }
}