using System;
using UnityEngine;

public interface IControlBase {
    void OnInit(AbsSystem system);
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnClear();
}

public class MyControl : IControlBase {
    public Action OnUpdateAction; 
    public Action OnFixedUpdateAction;
    public Action OnLateUpdateAction;
    public ComponentManager manager;

    private AbsWorld absWorld;
    public AbsWorld AbsWorld {
        get { return absWorld; }
    }

    public virtual void OnInit(AbsSystem system) {
        this.absWorld = system.MyAbsWorld;
        manager = new ComponentManager();
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