using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameEngine : MonoBehaviour
{
    private GameWorldManager gameWorldManager;
    public Action OnUpdateAction;
    public Action OnFixedUpdateAction;
    public Action OnLateUpdateAction;
    public Action OnClearAction;
    void Start()
    {
        InitManager();
        gameWorldManager.AddGameWorld<GameWorld>();
    }

    private void InitManager()
    {
        gameWorldManager = new GameWorldManager(this);
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

    public void Clear()
    {
        OnClearAction?.Invoke();
    }
}
