using UnityEngine;

public class BulletController : MonoBehaviour,IBaseController
{
    [SerializeField] private float speed;
    [Tooltip("弹药类型")][SerializeField] public BulletType bulletType;
    [HideInInspector] public Vector3 targetTran;
    void Start() {
        Invoke("OnDestroy", 0.5f);
    }

    void Update() {
        Debug.DrawLine(transform.position, targetTran, Color.magenta);
        transform.LookAt(targetTran);
        transform.position = Vector3.Lerp(transform.position, targetTran, Time.deltaTime * speed);
        if (Vector3.Distance(transform.position, targetTran) < 0.01f) {
            OnDestroy();
        }
    }

    void OnDestroy() {
        Destroy(gameObject);
    }

    public void OnInit() {
    }

    public void OnUpdate() {
    }

    public void OnFixedUpdate() {
    }

    public void OnLateUpdate() {
    }

    public void OnClear() {
        Destroy(this.gameObject);
    }
}
