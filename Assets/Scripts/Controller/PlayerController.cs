using System;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour, BaseController
{
    [Header("==== 角色ID ====")]
    [SerializeField] private int playerId = -1;
    public int PlayerId
    {
        get
        {
            if (playerId == -1)
            {
                playerId = GetInstanceID();
            }
            return playerId;
        }
    }

    [Header("==== 控制器 ====")]
    [SerializeField] CharacterController controller;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;

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
    [SerializeField] bool isShot;
    
    [Header("==== 角色消息 ====")] [InspectorLabel("")]
    public bool JumpTrigger;
    public bool ShotTrigger;
    public bool RunTrigger;

    private Vector3 moveDirection = Vector3.zero;
    
    public void OnInit()
    {
        GameData.player = this;
    }

    public void OnUpdate() {
        SetCameraTarget();
        SetFrontCameraTarget();
        MoveEvent();
        EyeEvent();
        ShotEvent();
    }

    public void OnFixedUpdate() { }
    public void OnLateUpdate() { }
    
    void ShotEvent() {
        if (ShotTrigger)
        {
            var targetVec = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;
            if (Physics.Raycast(targetVec, out hit, 200, ~(1 << 25))) {
                var bullet = Instantiate(bulletPrefab.gameObject);
                Debug.Log("hitName : " + hit.collider.name);
                bullet.transform.position = bulletShotTran.position;
                bullet.transform.GetComponent<BulletController>().targetTran = hit.point; 
            }
            ShotTrigger = false;        
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

            if (RunTrigger)
            {
                ver *= runSpeed;
            }

            if (hor == 0 && ver == 0)
            {
                isRun = false;
            }
            else
            {
                isRun = true;
                Debug.Log("跑步");
            }

            if (!audioSource.isPlaying && isRun) {
                audioSource.Play();
                Debug.Log("跑步音效");
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
                    if (JumpTrigger)
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
