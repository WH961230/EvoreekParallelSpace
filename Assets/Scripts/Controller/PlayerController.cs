using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("==== 控制器 ====")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Animator animator;

    [Header("==== 移动参数 ====")] [InspectorLabel("移动向量")]
    [SerializeField] private float gravity;
    [SerializeField] private float forwardMoveSpeed;
    [SerializeField] private float leftMoveSpeed;
    [SerializeField] private float ySpeed;
    [SerializeField] private float xSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private bool isJump;

    [Header("==== 预制 ====")] [InspectorLabel("a")]
    [SerializeField] private Transform roleCameraTarget;
    
    
    private Vector3 moveDirection = Vector3.zero;

    void Start() {
        Init();
    }

    void Init() {
        GlobalData.player = this;
    }

    void Update()
    {
        SetCameraTarget();
        MoveEvent();
        EyeEvent();
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

    void EyeEvent() {
        var y = Input.GetAxis("Mouse Y");
        var x = Input.GetAxis("Mouse X");
        controller.transform.Rotate(Vector3.up * x * xSpeed);
        roleCameraTarget.transform.Rotate(Vector3.left * y * ySpeed);
    }

    void MoveEvent()
    {
        if (!controller) {
            return;
        }

        if (controller.isGrounded) {
            animator.SetBool("Jump", false);
            var hor = Input.GetAxis("Horizontal") * leftMoveSpeed;
            var ver = Input.GetAxis("Vertical") * leftMoveSpeed;
            moveDirection = new Vector3(hor, 0, ver);
            moveDirection = controller.transform.TransformDirection(moveDirection);
            moveDirection *= forwardMoveSpeed;
            animator.SetFloat("Horizontal", hor);
            animator.SetFloat("Vertical", ver);
            if (Input.GetButton("Jump")) {
                animator.SetBool("Jump", true);
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
