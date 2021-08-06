using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("==== 控制器 ====")]
    [SerializeField] CharacterController controller;
    [SerializeField] Animator animator;

    [Header("==== 移动参数 ====")] [InspectorLabel("移动向量")]
    [SerializeField] float gravity;
    [SerializeField] float forwardMoveSpeed;
    [SerializeField] float leftMoveSpeed;
    [SerializeField] float ySpeed;
    [SerializeField] float xSpeed;
    [SerializeField] float jumpSpeed;

    [Header("==== 预制 ====")] [InspectorLabel("a")]
    [SerializeField] Transform roleCameraTarget;

    private Vector3 moveDirection = Vector3.zero;

    void Start() {
        GameData.player = this;
        // 注册 Update
    }

    void Update() {
        SetCameraTarget();
        MoveEvent();
        EyeEvent();
    }

    private bool CheckNull(Object obj) {
        if (null == obj) {
            Debug.LogErrorFormat("obj : {0} is null",obj);
        }
        return null == obj;
    }

    private void SetCameraTarget() { 
        var globalCamera = GameData.GameCamera;
        if (CheckNull(globalCamera)) {
            return;
        }

        var target = globalCamera.GetTarget();
        if (CheckNull(target))
        {
            globalCamera.SetTarget(roleCameraTarget);
        }
    }

    void EyeEvent() 
    {
        if (CheckNull(roleCameraTarget) || CheckNull(controller)) {
            return;
        }

        var y = Input.GetAxis("Mouse Y");
        var x = Input.GetAxis("Mouse X");

        controller.transform.Rotate(Vector3.up * x * xSpeed);
        roleCameraTarget.transform.Rotate(Vector3.left * y * ySpeed);
    }

    void MoveEvent()
    {
        if (CheckNull(controller) || CheckNull(animator)) {
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
