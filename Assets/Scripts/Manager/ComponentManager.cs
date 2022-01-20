using System;
using System.Collections.Generic;

public class ComponentManager : Singleton<ComponentManager> {
    private MyControl control;
    private List<IComponentBase> components = new List<IComponentBase>();
    private Dictionary<Type, IComponentBase> componentDic = new Dictionary<Type, IComponentBase>();

    public void OnInit(MyControl control) {
        this.control = control;
        control.OnUpdateAction += OnUpdate;
        control.OnFixedUpdateAction += OnFixedUpdate;
        control.OnLateUpdateAction += OnLateUpdate;
    }

    private void OnUpdate() {
        int count = components.Count;
        for (int i = 0 ; i < count ; i++) {
            components[i].OnUpdate();
        }
    }

    private void OnFixedUpdate() {
        int count = components.Count;
        for (int i = 0 ; i < count ; i++) {
            components[i].OnFixedUpdate();
        }
    }

    private void OnLateUpdate() {
        int count = components.Count;
        for (int i = 0 ; i < count ; i++) {
            components[i].OnLateUpdate();
        }
    }

    public void OnClear() {
        control.OnUpdateAction -= OnUpdate;
        control.OnFixedUpdateAction -= OnFixedUpdate;
        control.OnLateUpdateAction -= OnLateUpdate;
    }

    public void AddComponent<T>(long id) where T : IComponentBase, new() {
        if (null == GetComponent<T>()) {
            IComponentBase e = new T();
            components.Add(e);
            componentDic.Add(typeof(T), e);
            e.OnInit<T>(control, id);
        }
    }

    private T GetComponent<T>() {
        if (componentDic.TryGetValue(typeof(T), out IComponentBase target)) {
            return (T)target;
        }

        return default;
    }

    public void RemoveComponent<T>() where T : IComponentBase, new() {
        var index = FindComponentIndex<T>();
        if (index >= 0) {
            IComponentBase e = components[index];
            components.RemoveAt(index);
            componentDic.Remove(e.GetType());
            e.OnClear();
        }
    }

    private int FindComponentIndex<T>() where T : IComponentBase, new() {
        for (var i = 0 ; i < componentDic.Count ; ++i) {
            if (components[i].GetType() == typeof(T)) {
                return i;
            }
        }

        return -1;
    }
}