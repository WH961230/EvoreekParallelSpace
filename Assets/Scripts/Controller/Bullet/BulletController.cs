using System;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour,IBaseController
{
    [SerializeField] private float speed;
    [Tooltip("弹药类型")][SerializeField] public BulletType bulletType;
    [HideInInspector] public Vector3 targetTran;
    void Start() {
        Invoke("OnDestroy", 10f);
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
