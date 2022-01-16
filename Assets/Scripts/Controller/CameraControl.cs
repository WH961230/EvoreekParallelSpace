using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class A
{
    public Transform tran;
}

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform targetRotate;
    [SerializeField] private Vector3 offVec;
    [SerializeField] private bool isEye;
    [SerializeField] private bool isFollowTarget;
    [SerializeField] private float followTime;
    void Start()
    {
        
    }

    private float xRotate = 0.0f;
    private float yRotate = 0.0f;

    [SerializeField] public List<A> a = new List<A>();
    void Update()
    {
        // if (isEye)
        // {
        //     xRotate -= Input.GetAxis("Mouse Y");
        //     yRotate += Input.GetAxis("Mouse X");
        //     transform.rotation = Quaternion.Euler(xRotate, yRotate, 0);
        // }
        //
        // if (isFollowTarget)
        // {
        //     transform.position = Vector3.Lerp(transform.position, target.position, followTime);
        // }

        foreach (var a1 in a)
        {
            if (Vector3.Distance(targetRotate.position, a1.tran.position) < 5f)
            {
                Debug.LogError(a1.tran.gameObject.name);
            }
        }
    }
}
