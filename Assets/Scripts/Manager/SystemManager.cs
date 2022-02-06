using System;
using System.Collections.Generic;

public class SystemManager
{
    private World world;
    private List<MySystem> system = new List<MySystem>();
    private Dictionary<Type, MySystem> systemTypeDic = new Dictionary<Type, MySystem>();

    public void OnInit(World world)
    {
        this.world = world;
        world.AddUpdateAction(OnUpdate);
        world.AddFixedUpdateAction(OnFixedUpdate);
        world.AddLateUpdateAction(OnLateUpdate);
        world.AddQuitAction(OnClear);
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
        world.RemoveUpdateAction(OnUpdate);
        world.RemoveFixedUpdateAction(OnFixedUpdate);
        world.RemoveLateUpdateAction(OnLateUpdate);
        world.RemoveQuitAction(OnClear);
    }

    public void AddSystem<T>() where T : MySystem, new()
    {
        if (null == GetSystem<T>())
        {
            MySystem e = new T();
            system.Add(e);
            systemTypeDic.Add(typeof(T), e);
            e.OnInit();
        }
    }

    public T GetSystem<T>() where T : MySystem, new()
    {
        if (systemTypeDic.TryGetValue(typeof(T), out MySystem target))
        {
            return (T) target;
        }

        return default;
    }

    public void RemoveSystem<T>() where T : MySystem, new()
    {
        var index = FindSystemIndex<T>();
        if (index >= 0)
        {
            MySystem e = system[index];
            system.RemoveAt(index);
            systemTypeDic.Remove(e.GetType());
            e.OnClear();
        }
    }

    private int FindSystemIndex<T>() where T : MySystem, new()
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