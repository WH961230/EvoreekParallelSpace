using System;
using UnityEngine;

public interface IControlBase {
    void OnInit(AbsSystem system);
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnClear();
}

public abstract class AbsControl : IControlBase {
    public Action OnUpdateAction; 
    public Action OnFixedUpdateAction;
    public Action OnLateUpdateAction;
    public ComponentManager manager;
    public AbsWorld myWorld;
    public AbsSystem mySystem;
    public AbsData myDatas;
    public SUPPLIERTYPE myType;

    public virtual void OnInit(AbsSystem system) {
        myWorld = system.MyAbsWorld;
        mySystem = system;
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