using System;
using UnityEngine;

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
    public ComponentManager manager;

    private World world;
    public World World {
        get { return world; }
    }

    public virtual void OnInit(MySystem system) {
        this.world = system.MyWorld;
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