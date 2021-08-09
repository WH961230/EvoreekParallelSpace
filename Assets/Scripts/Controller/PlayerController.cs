using System;
using Unity.VisualScripting;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("==== 控制器 ====")]
    [SerializeField] CharacterController controller;
    [SerializeField] Animator animator;

    [Header("==== 移动参数 ====")] [InspectorLabel("移动向量")]
    [SerializeField] float gravity;
    [SerializeField] float forwardMoveSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float ySpeed;
    [SerializeField] float xSpeed;
    [SerializeField] float jumpSpeed;

    [Header("==== 预制 ====")] [InspectorLabel("a")]
    [SerializeField] Transform roleCameraTarget;
    [SerializeField] Transform roleFrontCameraTarget;
    [SerializeField] Transform roleCameraRotObj;
    [SerializeField] Transform bulletPrefab;
    [SerializeField] Transform bulletShotTran;

    [Header("==== 角色状态 ====")] [InspectorLabel("")]
    [SerializeField] bool isJump;
    [SerializeField] bool isRun;

    private Vector3 moveDirection = Vector3.zero;

    void Start() {
        GameData.player = this;
    }

    void Update() {
        SetCameraTarget();
        SetFrontCameraTarget();
        MoveEvent();
        EyeEvent();
        ShotEvent();
        
        
        // 当按下 A 键时，鼠标锁定并消失
        if (Input.GetKeyDown(KeyCode.A))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
 
        // 当按下 S 键时，鼠标解锁并显示
        if (Input.GetKeyDown(KeyCode.S))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private bool isShot;

    void ShotEvent() {
        if (Input.GetMouseButton(0)) {
            isShot = true;
        }

        if (isShot) {
            var targetVec = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;
            if (Physics.Raycast(targetVec, out hit, 200, ~(1 << 25))) {
                var bullet = Instantiate(bulletPrefab.gameObject);
                Debug.Log("hitName : " + hit.collider.name);
                bullet.transform.position = bulletShotTran.position;
                bullet.transform.GetComponent<BulletController>().targetTran = hit.point; 
            }
            isShot = false;
        }
    }

    private void OnDrawGizmos() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out hit, 200,~(1 << 25))) {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(bulletShotTran.position, hit.point);
        }

        var rect = new Rect(new Vector2(Screen.width / 2, Screen.height / 2), Vector2.one);
        Gizmos.DrawGUITexture(rect, Texture2D.whiteTexture);
    }

    private void SetCameraTarget() { 
        var globalCamera = GameData.GameCamera;
        if (!globalCamera) 
        {
            return;
        }

        var target = globalCamera.GetTarget();
        if (!target)
        {
            globalCamera.SetTarget(roleCameraTarget);
        }
    }
    
    private void SetFrontCameraTarget() { 
        var globalFrontCamera = GameData.GameFrontCamera;
        if (!globalFrontCamera) 
        {
            return;
        }

        var target = globalFrontCamera.GetTarget();
        if (!target)
        {
            globalFrontCamera.SetTarget(roleFrontCameraTarget);
        }
    }

    void EyeEvent() 
    {
        if (!roleCameraRotObj || !controller) 
        {
            return;
        }

        var y = Input.GetAxis("Mouse Y");
        var x = Input.GetAxis("Mouse X");

        controller.transform.Rotate(Vector3.up * x * xSpeed);
        roleCameraRotObj.transform.Rotate(Vector3.left * y * ySpeed);
    }

    void MoveEvent()
    {
        if (!controller || !animator) {
            return;
        }

        //角色在地面
        if (controller.isGrounded) {
            isRun = false;

            //前后移动
            var hor = Input.GetAxis("Horizontal");
            var ver = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                ver *= runSpeed;
                isRun = true;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                animator.SetLayerWeight(1,Mathf.Abs(animator.GetLayerWeight(1) - 1));
                animator.SetBool("Wep", !animator.GetBool("Wep"));
            }
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                animator.SetBool("Wep", !animator.GetBool("Wep"));
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetLayerWeight(1,Mathf.Abs(animator.GetLayerWeight(1) - 1));
                animator.SetBool("Aim", !animator.GetBool("Aim"));
            }

            moveDirection = new Vector3(hor, 0, ver);
            moveDirection = controller.transform.TransformDirection(moveDirection);
            moveDirection *= forwardMoveSpeed;

            //动画 - 水平 垂直 - 参数
            animator.SetFloat("Horizontal", hor);
            animator.SetFloat("Vertical", ver);
            
            //角色非跳跃状态
            if (!isJump)
            {
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
                {
                    //角色输入跳跃
                    if (Input.GetButton("Jump"))
                    {
                        isJump = true;
                        //动画 - 跳跃
                        animator.SetBool("Jump", true);
                        moveDirection.y = jumpSpeed;
                    }
                }
            }
            else
            {
                //重置 跳跃状态
                isJump = false;
                animator.SetBool("Jump", false);
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
