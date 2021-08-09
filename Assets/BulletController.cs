using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform tran;
    void Start()
    {
        tran = transform;
        Invoke("OnDestroy", 2);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(tran.position, tran.position + tran.forward * 100f, Time.deltaTime * speed);
    }

    void OnDestroy()
    {
        Destroy(gameObject);
    }
}
