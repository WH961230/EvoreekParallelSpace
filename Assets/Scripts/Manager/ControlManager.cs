using System;
using System.Collections.Generic;

public class ControlManager {
    private AbsWorld myAbsWorld;
    private AbsSystem system;
    private List<IControlBase> controls = new List<IControlBase>();
    private Dictionary<Type, IControlBase> controlDic = new Dictionary<Type, IControlBase>();

    public void OnInit(AbsSystem system) {
        this.system = system;
        this.myAbsWorld = system.MyAbsWorld;
        system.OnUpdateAction += OnUpdate;
        system.OnFixedUpdateAction += OnFixedUpdate;
        system.OnLateUpdateAction += OnLateUpdate;
    }

    private void OnUpdate() {
        int count = controls.Count;
        for (int i = 0 ; i < count ; i++) {
            controls[i].OnUpdate();
        }
    }

    private void OnFixedUpdate() {
        int count = controls.Count;
        for (int i = 0 ; i < count ; i++) {
            controls[i].OnFixedUpdate();
        }
    }

    private void OnLateUpdate() {
        int count = controls.Count;
        for (int i = 0 ; i < count ; i++) {
            controls[i].OnLateUpdate();
        }
    }

    public void OnClear() {
        system.OnUpdateAction -= OnUpdate;
        system.OnFixedUpdateAction -= OnFixedUpdate;
        system.OnLateUpdateAction -= OnLateUpdate;
    }

    public void AddControl<T>() where T : IControlBase, new() {
        if (null == GetControl<T>()) {
            IControlBase e = new T();
            controls.Add(e);
            controlDic.Add(typeof(T), e);
            e.OnInit(system);
        }
    }

    public T GetControl<T>() {
        if (controlDic.TryGetValue(typeof(T), out IControlBase target)) {
            return (T)target;
        }

        return default;
    }

    public void RemoveControl<T>() where T : IControlBase, new() {
        var index = FindControlIndex<T>();
        if (index >= 0) {
            IControlBase e = controls[index];
            controls.RemoveAt(index);
            controlDic.Remove(e.GetType());
            e.OnClear();
        }
    }

    private int FindControlIndex<T>() where T : IControlBase, new() {
        for (var i = 0 ; i < controlDic.Count ; ++i) {
            if (controls[i].GetType() == typeof(T)) {
                return i;
            }
        }

        return -1;
    }
}