using UnityEngine;

public class BulletController : MonoBehaviour,IBaseController
{
    [Tooltip("弹药速度")][SerializeField] private float speed;
    [Tooltip("弹药类型")][SerializeField] public BulletType bulletType;
    public int bulletId;
    public Vector3 target;
    public Vector3 gravity;
    private RaycastHit[] hits = new RaycastHit[10];
    private Vector3 lastPoint;

    void OnDestroy() {
        Destroy(gameObject);
    }

    public void OnInit()
    {
        lastPoint = transform.position;
    }

    public void OnUpdate()
    {
        var t = transform;
        t.LookAt(target);
        var p = t.position;
        p = Vector3.Lerp(p, target, Time.deltaTime * speed);
        t.position = p;

        lastPoint = p;
    }

    public void OnFixedUpdate() {
    }

    public void OnLateUpdate() {
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.layer != LayerMask.NameToLayer("Player") &&
            other.collider.gameObject.layer != LayerMask.NameToLayer("Item"))
        {
            Debug.Log(other.collider.name);
        }
    }

    public void OnClear() {
        Destroy(this.gameObject);
    }
}
