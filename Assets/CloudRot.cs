using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudRot : MonoBehaviour
{
    [Tooltip("旋转速度")] [SerializeField] private float rotateSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
    }
}
