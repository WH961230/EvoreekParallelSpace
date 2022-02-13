using UnityEngine;
using UnityEngine.Serialization;

interface IComponentBase {
    void OnInit<T>(AbsControl control, long id) where T : AbsComponent, new();
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnClear();
}

public abstract class AbsComponent : MonoBehaviour, IComponentBase {
    private AbsControl absControl;
    [SerializeField] public int ComponentId;
    [SerializeField] public bool IsActive;
    //组件的绑定需要参数 相邻高级 组件id可以获取instance 主体id
    public virtual void OnInit<T>(AbsControl control, long id) where T : AbsComponent, new() {
        absControl = control;
        ComponentId = GetInstanceID();
        IsActive = true;
        absControl.manager.AddComponent<T>(id, this);
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