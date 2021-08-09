using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed;
    public Vector3 targetTran;
    void Start()
    {
        Invoke("OnDestroy", 1);
    }

    void Update()
    {
        if (null != targetTran) {
            Debug.DrawLine(transform.position, targetTran, Color.magenta);
            transform.LookAt(targetTran);
            transform.position = Vector3.Lerp(transform.position, targetTran, Time.deltaTime * speed); 
        }
    }

    void OnDestroy()
    {
        Destroy(gameObject);
    }
}
