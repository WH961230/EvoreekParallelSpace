using UnityEngine;
using UnityEngine.Serialization;

interface IComponentBase {
    void OnInit<T>(long id) where T : MyComponent, new();
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnClear();
}

public class MyComponent : MonoBehaviour, IComponentBase
{
    [SerializeField] public long ComponentId;
    public void OnInit<T>(long id) where T : MyComponent, new()
    {
        ComponentId = id;
        ComponentManager.Instance.AddComponent<T>(id);
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