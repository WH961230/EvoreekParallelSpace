using UnityEngine;
using UnityEngine.Serialization;

interface IComponentBase {
    void OnInit<T>(MyControl control, long comId) where T : MyComponent, new();
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnClear();
}

public class MyComponent : MonoBehaviour, IComponentBase {
    private MyControl myControl;
    [SerializeField] public long ComponentId;
    public void OnInit<T>(MyControl control, long comId) where T : MyComponent, new() {
        myControl = control;
        ComponentId = comId;
        myControl.manager.AddComponent<T>(comId, this);
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