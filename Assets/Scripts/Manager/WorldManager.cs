using System;
using System.Collections.Generic;

public class WorldManager : Singleton<WorldManager>
{
    private Engine engine;
    private List<IWorld> IWorlds = new List<IWorld>();
    private Dictionary<Type, IWorld> IWorldDic = new Dictionary<Type, IWorld>();

    public void OnInit(Engine engine)
    {
        this.engine = engine;
        engine.OnUpdateAction += OnUpdate;
        engine.OnFixedUpdateAction += OnFixedUpdate;
        engine.OnLateUpdateAction += OnLateUpdate;
        engine.OnQuitAction += OnClear;
    }

    private void OnUpdate()
    {
        int count = IWorlds.Count;
        for (int i = 0; i < count; i++)
        {
            IWorlds[i].OnUpdate();
        }
    }

    private void OnFixedUpdate()
    {
        int count = IWorlds.Count;
        for (int i = 0; i < count; i++)
        {
            IWorlds[i].OnFixedUpdate();
        }
    }

    private void OnLateUpdate()
    {
        int count = IWorlds.Count;
        for (int i = 0; i < count; i++)
        {
            IWorlds[i].OnLateUpdate();
        }
    }

    private void OnClear()
    {
        engine.OnUpdateAction -= OnUpdate;
        engine.OnFixedUpdateAction -= OnFixedUpdate;
        engine.OnLateUpdateAction -= OnLateUpdate;
        engine.OnQuitAction -= OnClear;
        engine.Quit();
        engine = null;
    }

    public void AddWorld<T>() where T : IWorld, new()
    {
        if (null == GetWorld<T>())
        {
            IWorld e = new T();
            IWorlds.Add(e);
            IWorldDic.Add(typeof(T), e);
            e.OnInit(engine);
        }
    }

    public T GetWorld<T>()
    {
        if (IWorldDic.TryGetValue(typeof(T), out IWorld target))
        {
            return (T) target;
        }

        return default;
    }

    private void RemoveWorld<T>() where T : IWorld, new()
    {
        var index = FindWorldIndex<T>();
        if (index >= 0)
        {
            IWorld e = IWorlds[index];
            IWorlds.RemoveAt(index);
            IWorldDic.Remove(e.GetType());
            e.OnClear();
        }
    }

    private int FindWorldIndex<T>() where T : IWorld, new()
    {
        for (var i = 0; i < IWorldDic.Count; ++i)
        {
            if (IWorlds[i].GetType() == typeof(T))
            {
                return i;
            }
        }

        return -1;
    }
}