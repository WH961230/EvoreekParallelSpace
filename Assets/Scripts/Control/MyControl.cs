using System;

public interface IControlBase {
    void OnInit(MySystem system);
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnClear();
}

public class MyControl : IControlBase {
    public Action OnUpdateAction; 
    public Action OnFixedUpdateAction;
    public Action OnLateUpdateAction;
    public virtual void OnInit(MySystem system) {
        ComponentManager.Instance.OnInit(this);
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
    }
}