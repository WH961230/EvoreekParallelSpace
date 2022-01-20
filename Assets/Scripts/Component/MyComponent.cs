using System;
using UnityEngine;

public interface IComponentBase {
    void OnInit<T>(IControlBase controlBase, long comId) where T : IComponentBase, new();
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnClear();
}

public abstract class AbsComponent : MonoBehaviour, IComponentBase {
    protected MyControl controlBase;
    public void OnInit<T>(IControlBase controlBase, long comId) where T : IComponentBase, new()
    {
        controlBase = (MyControl)controlBase;
        ComponentManagerLab.Instance.AddComponent<T>(comId);
    }

    public virtual void OnUpdate() {
    }

    public virtual void OnFixedUpdate() {
    }

    public virtual void OnLateUpdate() {
    }

    public virtual void OnClear() {
    }
}