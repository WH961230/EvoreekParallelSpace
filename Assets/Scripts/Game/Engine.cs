using System;
using UnityEngine;

public class Engine : MonoBehaviour
{
    private Action OnUpdateAction;
    private Action OnFixedUpdateAction;
    private Action OnLateUpdateAction;
    private Action OnQuitAction;

    [SerializeField] private string InitId = "";

    public void AddUpdateAction(Action action) { OnUpdateAction += action; }
    public void AddFixedUpdateAction(Action action) { OnFixedUpdateAction += action; }
    public void AddLateUpdateAction(Action action) { OnLateUpdateAction += action; }
    public void AddQuitAction(Action action) { OnQuitAction += action; }

    public void RemoveUpdateAction(Action action) { OnUpdateAction -= action; }
    public void RemoveFixedUpdateAction(Action action) { OnFixedUpdateAction -= action; }
    public void RemoveLateUpdateAction(Action action) { OnLateUpdateAction -= action; }
    public void RemoveQuitAction(Action action) { OnQuitAction -= action; }

    void Start()
    {
        //初始化管理器
        ConfigManager.Instance.OnInit();
        WorldManager.Instance.OnInit(this);
        //获取配置
        var id = InitId;
        var gameConfig = GameConfig.Get(id);
        if (null == gameConfig)
        {
            Debug.LogError("###根据 id 查询到游戏模式为空###"); 
            return;
        }
        var sceneConfig = SceneConfig.Get(gameConfig.id);
        if (null == sceneConfig)
        {
            Debug.LogError("###根据游戏 id 查询到游戏场景为空###"); 
            return;
        }
        //获取世界信息
        var worldInfo = new WorldInfo() {
            gameConfig = gameConfig,
            sceneConfig = sceneConfig,
        };
        //创建游戏世界
        WorldManager.Instance.AddWorld<World>(worldInfo);
    }

    void Update()
    {
        OnUpdateAction?.Invoke();
    }

    private void FixedUpdate()
    {
        OnFixedUpdateAction?.Invoke();
    }

    private void LateUpdate()
    {
        OnLateUpdateAction?.Invoke();
    }

    public void Quit()
    {
        OnQuitAction?.Invoke();
        Clear();
    }

    private void Clear()
    {
        OnUpdateAction = null;
        OnFixedUpdateAction = null;
        OnLateUpdateAction = null;
        OnQuitAction = null;
    }
}