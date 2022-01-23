using System;
using UnityEngine;

public class Engine : MonoBehaviour {
    public Action OnUpdateAction;
    public Action OnFixedUpdateAction;
    public Action OnLateUpdateAction;
    public Action OnQuitAction;

    void Start() {
        ConfigManager.Instance.OnInit();
        WorldManager.Instance.OnInit(this);
        long wid = 0;
        WorldManager.Instance.AddWorld<World>(new WorldInfo() {worldId = ++wid, worldSign = "世界1", sceneSign = "Battle"});
        WorldManager.Instance.AddWorld<World>(new WorldInfo() {worldId = ++wid, worldSign = "世界2", sceneSign = ""});
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