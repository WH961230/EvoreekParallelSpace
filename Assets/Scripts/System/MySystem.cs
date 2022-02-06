using System;

interface ISystemBase {
    void OnInit();
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnClear();
}

public class MySystem : ISystemBase {
    public Action OnUpdateAction;
    public Action OnFixedUpdateAction;
    public Action OnLateUpdateAction;

    public virtual void OnInit() {
        ControlManager.Instance.OnInit(this);
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