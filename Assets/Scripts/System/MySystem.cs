using System;

interface ISystemBase {
    void OnInit(IWorld world);
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnClear();
}

public class MySystem : ISystemBase {
    public Action OnUpdateAction;
    public Action OnFixedUpdateAction;
    public Action OnLateUpdateAction;

    public virtual void OnInit(IWorld world) {
        ControlManager.Instance.OnInit(this);
        ControlManager.Instance.AddControl<RoleControl>();
        ControlManager.Instance.AddControl<WeaponConatrol>();
    }

    public virtual void OnUpdate() {
        OnUpdateAction?.Invoke();
    }

    public virtual void OnFixedUpdate() {
        OnFixedUpdateAction?.Invoke();
    }

    public virtual void OnLateUpdate() {
        OnLateUpdateAction?.Invoke();
    }

    public virtual void OnClear() {
        ControlManager.Instance.OnClear();
    }
}