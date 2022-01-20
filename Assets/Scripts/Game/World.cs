﻿using System;
using UnityEngine;

public interface IWorld
{
    void OnInit(Engine engine);
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnClear();
}

public abstract class AbsWorld : IWorld
{
    protected Engine engine;
    public virtual void OnInit(Engine engine)
    {
        this.engine = engine;
    }

    public virtual void OnUpdate() { }

    public virtual void OnFixedUpdate() { }

    public virtual void OnLateUpdate() { }

    public virtual void OnClear() { }
}

public class World : AbsWorld
{
    public Action OnUpdateAction;
    public Action OnFixedUpdateAction;
    public Action OnLateUpdateAction;

    public override void OnInit(Engine engine)
    {
        base.OnInit(engine);
        SystemManager.Instance.OnInit(this);
        SystemManager.Instance.AddSystem<RoleSystem>();
        SystemManager.Instance.AddSystem<WeaponSystem>();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        OnUpdateAction?.Invoke();
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        OnFixedUpdateAction?.Invoke();
    }

    public override void OnLateUpdate()
    {
        base.OnLateUpdate();
        OnLateUpdateAction?.Invoke();
    }

    public override void OnClear()
    {
        engine.OnQuitAction?.Invoke();
        base.OnClear();
    }
}