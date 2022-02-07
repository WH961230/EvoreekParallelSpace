using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface IWorld
{
    void OnInit(WorldInfo info);
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnClear();
}

public class World : IWorld
{
    //配置
    private GameConfig gameConfig;
    // private SceneConfig sceneConfig;
    //行为
    private Action OnUpdateAction;
    private Action OnFixedUpdateAction;
    private Action OnLateUpdateAction;
    private Action OnQuitAction;
    //全局创建器
    public Supplier supplier;
    //系统
    private SystemManager systemManager;


    public virtual void OnInit(WorldInfo info) {
        //创建器
        supplier = new Supplier(this);
        
        //世界系统管理器 - 通过SO配置决定添加哪些系统
        systemManager = new SystemManager(this);
        systemManager.AddSystem<RoleSystem>();
        systemManager.AddSystem<WeaponSystem>();

        //游戏配置
        gameConfig = info.gameConfig;

        //场景配置
        // sceneConfig = info.sceneConfig;
        //加载世界队对应场景
        // SceneManager.LoadSceneByMode(sceneConfig.sceneSign, LoadSceneMode.Single);

        //获取游戏配置
        var soGameSetting = Loader.Instance.LoadGameSettingConfig<SOGameSetting>(gameConfig.configSign);
        Debug.LogError(soGameSetting.TestStr);
    }

    public void AddUpdateAction(Action action) { OnUpdateAction += action; }
    public void AddFixedUpdateAction(Action action) { OnFixedUpdateAction += action; }
    public void AddLateUpdateAction(Action action) { OnLateUpdateAction += action; }
    public void AddQuitAction(Action action) { OnQuitAction += action; }
    public void RemoveUpdateAction(Action action) { OnUpdateAction -= action; }
    public void RemoveFixedUpdateAction(Action action) { OnFixedUpdateAction -= action; }
    public void RemoveLateUpdateAction(Action action) { OnLateUpdateAction -= action; }
    public void RemoveQuitAction(Action action) { OnQuitAction -= action; }

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
        OnQuitAction?.Invoke();
        systemManager.OnClear();
        systemManager = null;
    }
}