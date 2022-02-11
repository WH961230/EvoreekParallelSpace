using System;
using System.Collections.Generic;

public class SystemManager : Singleton<SystemManager>
{
    private AbsWorld absWorld;
    private List<AbsSystem> system = new List<AbsSystem>();
    private Dictionary<Type, AbsSystem> systemTypeDic = new Dictionary<Type, AbsSystem>();

    public void OnInit(AbsWorld absWorld)
    {
        this.absWorld = absWorld;
        absWorld.AddUpdateAction(OnUpdate);
        absWorld.AddFixedUpdateAction(OnFixedUpdate);
        absWorld.AddLateUpdateAction(OnLateUpdate);
        absWorld.AddQuitAction(OnClear);
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
        absWorld.RemoveUpdateAction(OnUpdate);
        absWorld.RemoveFixedUpdateAction(OnFixedUpdate);
        absWorld.RemoveLateUpdateAction(OnLateUpdate);
        absWorld.RemoveQuitAction(OnClear);
    }

    public void AddSystem<T>() where T : AbsSystem, new()
    {
        if (null == GetSystem<T>())
        {
            AbsSystem e = new T();
            system.Add(e);
            systemTypeDic.Add(typeof(T), e);
            e.OnInit(absWorld);
        }
    }

    public T GetSystem<T>() where T : AbsSystem, new()
    {
        if (systemTypeDic.TryGetValue(typeof(T), out AbsSystem target))
        {
            return (T) target;
        }

        return default;
    }

    public void RemoveSystem<T>() where T : AbsSystem, new()
    {
        var index = FindSystemIndex<T>();
        if (index >= 0)
        {
            AbsSystem e = system[index];
            system.RemoveAt(index);
            systemTypeDic.Remove(e.GetType());
            e.OnClear();
        }
    }

    private int FindSystemIndex<T>() where T : AbsSystem, new()
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