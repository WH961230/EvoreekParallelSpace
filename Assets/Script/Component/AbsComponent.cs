using UnityEngine;

interface IComponentBase {
    void OnInit<T>(AbsControl control, int id) where T : AbsComponent, new();
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnClear();
}

public abstract class AbsComponent : MonoBehaviour, IComponentBase {
    protected AbsControl absControl;
    protected AbsSO absSO;
    [SerializeField] public int InstanceId;
    [SerializeField] public bool IsActive;
    //组件的绑定需要参数 相邻高级 组件id可以获取instance 主体idork
    public virtual void OnInit<T>(AbsControl control, int id) where T : AbsComponent, new() {
        absControl = control;
        InstanceId = id;
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