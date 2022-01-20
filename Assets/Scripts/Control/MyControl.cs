using System;

public interface IControlBase {
    void OnInit(ISystemBase systemBase);
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnClear();
}

public abstract class AbsControl : IControlBase {
    protected MySystem systemBase;

    public virtual void OnInit(ISystemBase systemBase) {
        systemBase = (MySystem)systemBase;
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

public class MyControl : AbsControl {
    public Action OnUpdateAction; 
    public Action OnFixedUpdateAction;
    public Action OnLateUpdateAction;
    public override void OnInit(ISystemBase systemBase) {
        base.OnInit(systemBase);
        ComponentManagerLab.Instance.OnInit(this);
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
        base.OnClear();
    }
}