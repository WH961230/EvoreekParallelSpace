using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface IWorld {
    void OnInit(WorldInfo info);
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnClear();
}

public abstract class AbsWorld : IWorld {
    //配置
    private GameConfig gameConfig;
    private SceneConfig sceneConfig;

    //行为
    private Action OnUpdateAction;
    private Action OnFixedUpdateAction;
    private Action OnLateUpdateAction;
    private Action OnQuitAction;

    //全局创建器
    public Supplier supplier;
    public SystemManager systemManager;
    public virtual void OnInit(WorldInfo info) {
        systemManager = new SystemManager();
        systemManager.OnInit(this);
        gameConfig = info.gameConfig;
        sceneConfig = info.sceneConfig;
        //SceneManager.LoadSceneByMode(sceneConfig.sceneSign, LoadSceneMode.Single);
        Loader.Instance.LoadGameSettingConfig<SOGameSetting>(gameConfig.configSign);
    }

    public void AddUpdateAction(Action action) {
        OnUpdateAction += action;
    }

    public void AddFixedUpdateAction(Action action) {
        OnFixedUpdateAction += action;
    }

    public void AddLateUpdateAction(Action action) {
        OnLateUpdateAction += action;
    }

    public void AddQuitAction(Action action) {
        OnQuitAction += action;
    }

    public void RemoveUpdateAction(Action action) {
        OnUpdateAction -= action;
    }

    public void RemoveFixedUpdateAction(Action action) {
        OnFixedUpdateAction -= action;
    }

    public void RemoveLateUpdateAction(Action action) {
        OnLateUpdateAction -= action;
    }

    public void RemoveQuitAction(Action action) {
        OnQuitAction -= action;
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
        OnQuitAction?.Invoke();
    }
}