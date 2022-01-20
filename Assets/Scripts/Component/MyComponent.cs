using System;
using UnityEngine;

public interface IComponentBase {
    void OnInit(IControlBase controlBase);
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnClear();
}

public abstract class AbsComponent : MonoBehaviour, IComponentBase {
    protected MyControl controlBase;
    public void OnInit(IControlBase controlBase) {
        controlBase = (MyControl)controlBase;
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

public class MyComponent : AbsComponent {
    protected void OnInit<T> (IControlBase controlBase, long comId) where T : MyComponent, new() {
        base.OnInit(controlBase);
        // ComponentManager.Instance.AddComponent<T>();
        ComponentManagerLab.Instance.AddComponent<T>(comId);
    }

    public override void OnUpdate() {
        base.OnUpdate();
    }

    public override void OnFixedUpdate() {
        base.OnFixedUpdate();
    }

    public override void OnLateUpdate() {
        base.OnLateUpdate();
    }

    public override void OnClear() {
        base.OnClear();
    }
}