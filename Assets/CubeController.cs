using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CubeController : MonoBehaviour
{
    private Vector3 tran;
    private Vector3 target;
    void Start()
    {
        tran = transform.position;
        target = tran + Vector3.forward * 5;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(tran, target, Time.deltaTime);
    }
}
