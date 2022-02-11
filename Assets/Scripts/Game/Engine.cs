using System;
using UnityEngine;

public class Engine : MonoBehaviour {
    private WorldManager worldManager;

    private Action OnUpdateAction;
    private Action OnFixedUpdateAction;
    private Action OnLateUpdateAction;
    private Action OnQuitAction;

    [SerializeField] private string InitId = "";

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

    void Start() {
        InitConfig();
        InitManager();
        InitWorld();
    }

    private void InitConfig() {
        ItemConfig.OnInit();
        GameConfig.OnInit();
        RoleConfig.OnInit();
        SceneConfig.OnInit();
    }

    private void InitManager() {
        worldManager = new WorldManager();
        worldManager.OnInit(this);
    }

    private void InitWorld() {
        var id = InitId;
        var gameConfig = GameConfig.Get(id);
        if (null == gameConfig) {
            Debug.LogError("###根据 id 查询到游戏模式为空###");
            return;
        }

        var sceneConfig = SceneConfig.Get(gameConfig.id);
        if (null == sceneConfig) {
            Debug.LogError("###根据游戏 id 查询到游戏场景为空###");
            return;
        }

        var worldInfo = new WorldInfo() {
            gameConfig = gameConfig,
            sceneConfig = sceneConfig,
        };
        worldManager.AddWorld<World>(worldInfo);
    }

    void Update() {
        OnUpdateAction?.Invoke();
    }

    private void FixedUpdate() {
        OnFixedUpdateAction?.Invoke();
    }

    private void LateUpdate() {
        OnLateUpdateAction?.Invoke();
    }

    public void Quit() {
        OnQuitAction?.Invoke();
        Clear();
    }

    private void Clear() {
        OnUpdateAction = null;
        OnFixedUpdateAction = null;
        OnLateUpdateAction = null;
        OnQuitAction = null;
    }
}