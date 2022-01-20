using System;
using System.Collections.Generic;

public class SystemManager : Singleton<SystemManager>
{
    private World world;
    private List<ISystemBase> system = new List<ISystemBase>();
    private Dictionary<Type, ISystemBase> systemTypeDic = new Dictionary<Type, ISystemBase>();

    public void OnInit(World world)
    {
        this.world = world;
        world.OnUpdateAction += OnUpdate;
        world.OnFixedUpdateAction += OnFixedUpdate;
        world.OnLateUpdateAction += OnLateUpdate;
    }

    private void OnUpdate()
    {
        int count = system.Count;
        for (int i = 0; i < count; i++)
        {
            system[i].OnUpdate();
        }
    }

    private void OnFixedUpdate()
    {
        int count = system.Count;
        for (int i = 0; i < count; i++)
        {
            system[i].OnFixedUpdate();
        }
    }

    private void OnLateUpdate()
    {
        int count = system.Count;
        for (int i = 0; i < count; i++)
        {
            system[i].OnLateUpdate();
        }
    }

    public void OnClear()
    {
        world.OnUpdateAction -= OnUpdate;
        world.OnFixedUpdateAction -= OnFixedUpdate;
        world.OnLateUpdateAction -= OnLateUpdate;
    }

    public void AddSystem<T>() where T : ISystemBase, new()
    {
        if (null == GetSystem<T>())
        {
            ISystemBase e = new T();
            system.Add(e);
            systemTypeDic.Add(typeof(T), e);
            e.OnInit(world);
        }
    }

    private T GetSystem<T>()
    {
        if (systemTypeDic.TryGetValue(typeof(T), out ISystemBase target))
        {
            return (T) target;
        }

        return default;
    }

    public void RemoveSystem<T>() where T : ISystemBase, new()
    {
        var index = FindSystemIndex<T>();
        if (index >= 0)
        {
            ISystemBase e = system[index];
            system.RemoveAt(index);
            systemTypeDic.Remove(e.GetType());
            e.OnClear();
        }
    }

    private int FindSystemIndex<T>() where T : ISystemBase, new()
    {
        for (var i = 0; i < systemTypeDic.Count; ++i)
        {
            if (system[i].GetType() == typeof(T))
            {
                return i;
            }
        }

        return -1;
    }
}