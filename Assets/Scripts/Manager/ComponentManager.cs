using System.Collections.Generic;
using UnityEngine.UIElements;

//组件管理：组件是独立于控制器存在的
public class ComponentManager : Singleton<ComponentManager> {
    private MyControl control;
    private Dictionary<long, List<MyComponent>> componentDic = new Dictionary<long, List<MyComponent>>();

    public void OnInit(MyControl control) {
        this.control = control;
        control.OnUpdateAction += OnUpdate;
        control.OnFixedUpdateAction += OnFixedUpdate;
        control.OnLateUpdateAction += OnLateUpdate;
    }

    private void OnUpdate() {
        var keys = componentDic.Keys;
        foreach (var key in keys) {
            if (componentDic.TryGetValue(key, out List<MyComponent> list)) {
                foreach (var l in list) {
                    l.OnUpdate();
                }
            }
        }
    }

    private void OnFixedUpdate() {
        var keys = componentDic.Keys;
        foreach (var key in keys) {
            if (componentDic.TryGetValue(key, out List<MyComponent> list)) {
                foreach (var l in list) {
                    l.OnFixedUpdate();
                }
            }
        }
    }

    private void OnLateUpdate() {
        var keys = componentDic.Keys;
        foreach (var key in keys) {
            if (componentDic.TryGetValue(key, out List<MyComponent> list)) {
                foreach (var l in list) {
                    l.OnLateUpdate();
                }
            }
        }
    }

    public void OnClear() {
        control.OnUpdateAction -= OnUpdate;
        control.OnFixedUpdateAction -= OnFixedUpdate;
        control.OnLateUpdateAction -= OnLateUpdate;
        componentDic = null;
    }

    public void AddComponent<T>(long id) where T : MyComponent, new()
    {
        if (!HasComponentValue<T>(id))
        {
            componentDic.Add(id, new List<MyComponent>());
            return;
        }

        if (componentDic.TryGetValue(id, out var comList))
        {
            
        }
    }

    private bool HasComponentValue<T>(long id) {
        if (componentDic.TryGetValue(id, out var tempTarget)) {
            foreach (var t in tempTarget) {
                if (t.GetType() == typeof(T)) {
                    return true;
                }
            }
        }

        return false;
    }

    public void RemoveComponent<T>(long id) where T : MyComponent, new() {
        if (componentDic.TryGetValue(id, out List<MyComponent> tempList)) {
            for (int j = 0 ; j < tempList.Count ; j++) {
                if (tempList[j].GetType() == typeof(T)) {
                    tempList[j].OnClear();
                    tempList.RemoveAt(j);
                }
            }

            if (tempList.Count == 0) {
                componentDic.Remove(id);
            } else {
                componentDic[id] = tempList;    
            }
        }
    }
}