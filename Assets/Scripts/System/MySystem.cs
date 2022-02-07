using System;

interface ISystemBase {
    void OnInit(World world);
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnClear();
}

public class MySystem : ISystemBase {
    public Action OnUpdateAction;
    public Action OnFixedUpdateAction;
    public Action OnLateUpdateAction;
    protected ControlManager manager;

    private World myWorld;
    public World MyWorld {
        get {
            return myWorld;
        }
    }

    public virtual void OnInit(World world) {
        this.myWorld = world;
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