using System.Collections.Generic;

//组件管理：组件是独立于控制器存在的
public class ComponentManagerLab : Singleton<ComponentManagerLab> {
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

    public void AddComponent<T>() where T : MyComponent, new() {
        // if (HasComponentValue<T>()) {
        //     return;
        // }
        //
        // MyComponent tempComponent = new T();
        // tempComponent.OnInit<T>(control, );
        // if (componentDic.TryGetValue(comId, out var list)) {
        //     if (null == list) {
        //         list = new List<MyComponent>(){tempComponent};
        //     } else {
        //         list.Add(tempComponent);
        //     }
        //     componentDic[comId] = list;
        // } else {
        //     componentDic.Add(comId, );
        // }
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