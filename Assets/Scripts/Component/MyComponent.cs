using System;
using UnityEngine;

interface IComponentBase {
    void OnInit<T>() where T : MyComponent, new();
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnClear();
}

public class MyComponent : MonoBehaviour, IComponentBase {
    public void OnInit<T>() where T : MyComponent, new()
    {
        ComponentManagerLab.Instance.AddComponent<T>();
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