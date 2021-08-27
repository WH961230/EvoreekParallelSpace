using UnityEngine;

public class BulletController : MonoBehaviour,IBaseController
{
    [SerializeField] private float speed;
    public Vector3 targetTran;
    void Start()
    {
        Invoke("OnDestroy", 1);
    }

    void Update() {
        Debug.DrawLine(transform.position, targetTran, Color.magenta);
        transform.LookAt(targetTran);
        transform.position = Vector3.Lerp(transform.position, targetTran, Time.deltaTime * speed);
    }

    void OnDestroy()
    {
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
