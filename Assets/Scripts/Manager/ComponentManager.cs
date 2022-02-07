using System.Collections.Generic;
using UnityEngine.UIElements;

//组件管理：组件是独立于控制器存在的
public class ComponentManager {
    private MyControl control;
    //主体id 和组件集合
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

    //添加组件 必要参数：组件（内含组件id） 主体id
    public void AddComponent<T>(long id, MyComponent component) where T : MyComponent, new() {
        var comList = new List<MyComponent>();
        comList.Add(component);
        //没有主体id
        if (!HasKey(id)) {
            componentDic.Add(id, comList);
        }
        //有主体id 没有对应id的组件
        if (!HasComponent(id, component.ComponentId)) {
            componentDic.TryGetValue(id, out var list);
            if (null != list && list.Count > 0) {
                list.Add(component);
                componentDic.Add(id, list);
            } else {
                componentDic.Add(id, comList);
            }
        }
    }

    private bool HasKey(long id) {
        foreach (var key in componentDic.Keys) {
            if (key == id) {
                return true;
            }
        }

        return false;
    }

    private bool HasComponent(long id, long comId) {
        if (componentDic.TryGetValue(id, out var tempTarget)) {
            foreach (var t in tempTarget) {
                if (t.ComponentId == comId) {
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