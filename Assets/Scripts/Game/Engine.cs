using System;
using UnityEngine;

public class Engine : MonoBehaviour
{
    private WorldManager worldManager;
    public Action OnUpdateAction;
    public Action OnFixedUpdateAction;
    public Action OnLateUpdateAction;
    public Action OnQuitAction;
    void Start()
    {
        worldManager = new WorldManager(this);
        worldManager.AddWorld<World>();
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

    private void Clear() {
        OnUpdateAction = null;
        OnFixedUpdateAction = null;
        OnLateUpdateAction = null;
        OnQuitAction = null;
        worldManager = null;
    }
}
