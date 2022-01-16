using System;
using UnityEngine;

public interface IGameWorld
{
    void OnInit(GameEngine gameEngine);
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnClear();
}

public abstract class AbsGameWorld : IGameWorld
{
    protected GameEngine gameEngine;
    public virtual void OnInit(GameEngine gameEngine)
    {
        this.gameEngine = gameEngine;
    }

    public virtual void OnUpdate() { }

    public virtual void OnFixedUpdate() { }

    public virtual void OnLateUpdate() { }

    public virtual void OnClear() { }
}

public class GameWorld : AbsGameWorld
{
    private SystemManager systemManager;
    public Action OnUpdateAction;
    public Action OnFixedUpdateAction;
    public Action OnLateUpdateAction;

    public override void OnInit(GameEngine gameEngine)
    {
        base.OnInit(gameEngine);
        InitSystem();
        AddSystem();
    }

    private void InitSystem()
    {
        systemManager = new SystemManager(this);
    }

    private void AddSystem()
    {
        systemManager.AddSystem<PlayerSystem>();
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
        gameEngine.OnClearAction?.Invoke();
        base.OnClear();
    }
}