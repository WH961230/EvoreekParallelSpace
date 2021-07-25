using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("==== 相机参数 ====")] 
    [SerializeField] private Vector3 offsetTarget;
    [SerializeField] private Quaternion offsetQuaTarget;


    [SerializeField] public Transform Target { set; get; }

    private void Start() {
        GlobalData.globalCamera = this;
    }

    private void Update()
    {
        TargetMoveEvent();
    }

    private void TargetMoveEvent()
    {
        if (null == Target)
        {
            return;
        }

        transform.position = Target.position;
        transform.rotation = Target.rotation;
    }
}
