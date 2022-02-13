using System;

interface ISystemBase {
    void OnInit(AbsWorld absWorld);
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnClear();
}

public abstract class AbsSystem : ISystemBase {
    public Action OnUpdateAction;
    public Action OnFixedUpdateAction;
    public Action OnLateUpdateAction;
    public ControlManager manager;

    private AbsWorld myAbsWorld;
    public AbsWorld MyAbsWorld {
        get {
            return myAbsWorld;
        }
    }

    public virtual void OnInit(AbsWorld absWorld) {
        this.myAbsWorld = absWorld;
        manager = new ControlManager();
        manager.OnInit(this);
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
        manager.OnClear();
        manager = null;
    }
}