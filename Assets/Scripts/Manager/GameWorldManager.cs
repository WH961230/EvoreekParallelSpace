using System;
using System.Collections.Generic;

public class GameWorldManager
{
    private GameEngine gameEngine;
    private List<IGameWorld> gameWorld = new List<IGameWorld>();
    private Dictionary<Type, IGameWorld> gameWorldTypeDic = new Dictionary<Type, IGameWorld>();

    public GameWorldManager()
    {
    }

    public GameWorldManager(GameEngine gameEngine)
    {
        this.gameEngine = gameEngine;
        gameEngine.OnUpdateAction += OnUpdate;
        gameEngine.OnFixedUpdateAction += OnFixedUpdate;
        gameEngine.OnLateUpdateAction += OnLateUpdate;
        gameEngine.OnClearAction += OnClear;
    }

    private void OnUpdate()
    {
        int count = gameWorld.Count;
        for (int i = 0; i < count; i++)
        {
            gameWorld[i].OnUpdate();
        }
    }

    private void OnFixedUpdate()
    {
        int count = gameWorld.Count;
        for (int i = 0; i < count; i++)
        {
            gameWorld[i].OnFixedUpdate();
        }
    }

    private void OnLateUpdate()
    {
        int count = gameWorld.Count;
        for (int i = 0; i < count; i++)
        {
            gameWorld[i].OnLateUpdate();
        }
    }

    private void OnClear()
    {
        gameEngine.OnUpdateAction -= OnUpdate;
        gameEngine.OnFixedUpdateAction -= OnFixedUpdate;
        gameEngine.OnLateUpdateAction -= OnLateUpdate;
        gameEngine.OnClearAction -= OnClear;
        gameEngine.Clear();
        gameEngine = null;
    }

    public void AddGameWorld<T>() where T : IGameWorld, new()
    {
        if (null == GetGameWorld<T>())
        {
            IGameWorld e = new T();
            gameWorld.Add(e);
            gameWorldTypeDic.Add(typeof(T), e);
            e.OnInit(gameEngine);
        }
    }

    public T GetGameWorld<T>()
    {
        if (gameWorldTypeDic.TryGetValue(typeof(T), out IGameWorld target))
        {
            return (T) target;
        }

        return default;
    }

    private void RemoveGameWorld<T>() where T : IGameWorld, new()
    {
        var index = FindGameWorldIndex<T>();
        if (index >= 0)
        {
            IGameWorld e = gameWorld[index];
            gameWorld.RemoveAt(index);
            gameWorldTypeDic.Remove(e.GetType());
            e.OnClear();
        }
    }

    private int FindGameWorldIndex<T>() where T : IGameWorld, new()
    {
        for (var i = 0; i < gameWorldTypeDic.Count; ++i)
        {
            if (gameWorld[i].GetType() == typeof(T))
            {
                return i;
            }
        }

        return -1;
    }
}