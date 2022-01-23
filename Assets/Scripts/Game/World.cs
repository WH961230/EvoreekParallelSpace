using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface IWorld
{
    void OnInit(Engine engine, WorldInfo info);
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnClear();
}

public class World : IWorld {
    private Engine engine;
    private WorldData data;
    private SOGameSetting config;
    public Action OnUpdateAction;
    public Action OnFixedUpdateAction;
    public Action OnLateUpdateAction;

    public virtual void OnInit(Engine engine, WorldInfo info) {
        this.engine = engine;
        data = new WorldData(info);
        config = Loader.Instance.LoadConfig<SOGameSetting>("GameSetting");
        UnityEngine.SceneManagement.SceneManager.LoadScene(config.SceneSign, config.loadSceneMode);
        // SystemManager.Instance.OnInit(this);
        // SystemManager.Instance.AddSystem<RoleSystem>();
        // SystemManager.Instance.AddSystem<WeaponSystem>();
    }

    public virtual void OnUpdate()
    {
        OnUpdateAction?.Invoke();
    }

    public virtual void OnFixedUpdate()
    {
        OnFixedUpdateAction?.Invoke();
    }

    public virtual void OnLateUpdate()
    {
        OnLateUpdateAction?.Invoke();
    }

    public virtual void OnClear()
    {
        engine.OnQuitAction?.Invoke();
    }
}