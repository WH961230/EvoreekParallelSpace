using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class ComponentManagerLab : Singleton<ComponentManagerLab> {
    private MyControl control;
    private Dictionary<long, List<IComponentBase>> componentDic = new Dictionary<long, List<IComponentBase>>();//ID + 组件

    public void OnInit(MyControl control) {
        this.control = control;
        control.OnUpdateAction += OnUpdate;
        control.OnFixedUpdateAction += OnFixedUpdate;
        control.OnLateUpdateAction += OnLateUpdate;
    }

    private void OnUpdate() {
        var keys = componentDic.Keys;
        foreach (var key in keys) {
            if (componentDic.TryGetValue(key, out List<IComponentBase> list)) {
                foreach (var l in list) {
                    l.OnUpdate();
                }
            }
        }
    }

    private void OnFixedUpdate() {
        var keys = componentDic.Keys;
        foreach (var key in keys) {
            if (componentDic.TryGetValue(key, out List<IComponentBase> list)) {
                foreach (var l in list) {
                    l.OnFixedUpdate();
                }
            }
        }
    }

    private void OnLateUpdate() {
        var keys = componentDic.Keys;
        foreach (var key in keys) {
            if (componentDic.TryGetValue(key, out List<IComponentBase> list)) {
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

    public void AddComponent<T>(long comId) where T : IComponentBase, new() {
        if (!HasComponentValue<T>(comId)) {
            if (componentDic.TryGetValue(comId, out var list)) {
                IComponentBase temp = new T();
                list.Add(temp);
                temp.OnInit(control);
                componentDic[comId] = list;
            }
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

    public void RemoveComponent<T>(long id) where T : IComponentBase, new() {
        if (componentDic.TryGetValue(id, out List<IComponentBase> tempList)) {
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