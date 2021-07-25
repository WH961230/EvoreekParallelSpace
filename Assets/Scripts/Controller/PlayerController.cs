using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    [Header("==== 控制器 ====")]
    [SerializeField] private CharacterController controller;

    [Header("==== 移动参数 ====")] [InspectorLabel("移动向量")]
    [SerializeField] private float gravity;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float leftSpeed;
    [SerializeField] private float jumpSpeed;

    [Header("==== 预制 ====")] [InspectorLabel("a")]
    [SerializeField] private Transform roleCameraTarget;


    private Vector3 moveDirectVec;
    void Start() {
        Init();
    }

    void Init() {
        GlobalData.player = this;
    }

    void Update()
    {
        SetCameraTarget();
        CharactorMoveEvent();
    }

    private void SetCameraTarget()
    {
        if (null == GlobalData.globalCamera)
        {
            return;
        }

        if (null == GlobalData.globalCamera.Target)
        {
            GlobalData.globalCamera.Target = roleCameraTarget;
        }
    }

    void CharactorMoveEvent()
    {   
        var x = Input.GetAxis("Horizontal") * forwardSpeed * Time.deltaTime;
        var z = Input.GetAxis("Vertical") * leftSpeed * Time.deltaTime;
        var jump = Input.GetKeyDown(KeyCode.Space);
        float y = 0;
        controller.Move(moveDirectVec);
        if(jump)
        {
            y = jumpSpeed * Time.deltaTime;
        }
        // 在空中
        if (!controller.isGrounded
        )
        {
            y = gravity * Time.deltaTime;
        }

        moveDirectVec = new Vector3(x, y, z);
    }
}
