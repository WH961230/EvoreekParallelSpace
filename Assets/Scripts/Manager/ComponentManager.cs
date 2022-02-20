using System.Collections.Generic;

//组件管理：组件是独立于控制器存在的
public class ComponentManager {
    private AbsControl control;
    //主体id 和组件集合
    private Dictionary<long, List<AbsComponent>> componentDic = new Dictionary<long, List<AbsComponent>>();

    public void OnInit(AbsControl control) {
        this.control = control;
        control.OnUpdateAction += OnUpdate;
        control.OnFixedUpdateAction += OnFixedUpdate;
        control.OnLateUpdateAction += OnLateUpdate;
    }

    private void OnUpdate() {
        var keys = componentDic.Keys;
        foreach (var key in keys) {
            if (componentDic.TryGetValue(key, out List<AbsComponent> list)) {
                foreach (var l in list) {
                    if (l.IsActive)
                    {
                        l.OnUpdate();
                    }
                }
            }
        }
    }

    private void OnFixedUpdate() {
        var keys = componentDic.Keys;
        foreach (var key in keys) {
            if (componentDic.TryGetValue(key, out List<AbsComponent> list)) {
                foreach (var l in list) {
                    if (l.IsActive)
                    {
                        l.OnFixedUpdate();
                    }
                }
            }
        }
    }

    private void OnLateUpdate() {
        var keys = componentDic.Keys;
        foreach (var key in keys) {
            if (componentDic.TryGetValue(key, out List<AbsComponent> list)) {
                foreach (var l in list) {
                    if (l.IsActive)
                    {
                        l.OnLateUpdate();
                    }
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
    public void  AddComponent<T>(long id, AbsComponent component) where T : AbsComponent, new() {
        var comList = new List<AbsComponent>();
        comList.Add(component);
        if (!HasKey(id)) {
            componentDic.Add(id, comList);
        }
        if (!HasComponent(id, component.InstanceId)) {
            componentDic.TryGetValue(id, out var list);
            if (null != list && list.Count > 0) {
                list.Add(component);
                componentDic.Add(id, list);
            } else {
                componentDic.Add(id, comList);
            }
        }
    }

    public T GetComponent<T>(long id) where T : AbsComponent, new()
    {
        if (componentDic.TryGetValue(id, out var outList))
        {
            for (int i = 0; i < outList.Count; i++)
            {
                var temp = outList[i];
                if (temp is T)
                {
                    return (T)temp;
                }
            }
        }

        return null;
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
                if (t.InstanceId == comId) {
                    return true;
                }
            }
        }

        return false;
    }

    public void RemoveComponent<T>(long id) where T : AbsComponent, new() {
        if (componentDic.TryGetValue(id, out List<AbsComponent> tempList)) {
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