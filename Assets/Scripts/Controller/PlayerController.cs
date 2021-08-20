using System.ComponentModel;
using Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour, BaseController
{
    [Header("==== 角色ID ====")] [SerializeField]
    private int playerId = -1;

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

    [Header("==== 控制器 ====")] [SerializeField]
    CharacterController controller;

    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;

    [Header("==== 移动参数 ====")] [InspectorLabel("移动向量")] [SerializeField]
    float gravity;

    [FormerlySerializedAs("forwardMoveSpeed")] [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float ySpeed;
    [SerializeField] float xSpeed;
    [SerializeField] float jumpSpeed;

    [Header("==== 预制 ====")] [InspectorLabel("a")] [SerializeField]
    Transform roleCameraTarget;

    [SerializeField] Transform roleFrontCameraTarget;
    [SerializeField] Transform roleCameraRotObj;
    [SerializeField] Transform bulletPrefab;
    [SerializeField] Transform bulletShotTran;
    
    [SerializeField] public bool isRun;
    
    private Vector3 moveDirection = Vector3.zero;

    public void OnInit()
    {
        MessageCenter.Instance.Register(MessageCode.Play_Shot, ShotEvent);
        MessageCenter.Instance.Register(MessageCode.Play_Jump, JumpEvent);
    }

    public void OnUpdate()
    {
        SetCameraTarget();
        SetFrontCameraTarget();
        MoveEvent();
        EyeEvent();
    }

    public void OnFixedUpdate()
    {
    }

    public void OnLateUpdate()
    {
    }
    
   void ShotEvent()
    {
        var targetVec = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        if (Physics.Raycast(targetVec, out hit, 200, ~(1 << 25)))
        {
            var bullet = Instantiate(bulletPrefab.gameObject);
            bullet.transform.position = bulletShotTran.position;
            bullet.transform.GetComponent<BulletController>().targetTran = hit.point;
        }
    }

    private void OnDrawGizmos()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out hit, 200, ~(1 << 25)))
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(bulletShotTran.position, hit.point);
        }

        var rect = new Rect(new Vector2(Screen.width / 2, Screen.height / 2), Vector2.one);
        Gizmos.DrawGUITexture(rect, Texture2D.whiteTexture);
    }

    private void SetCameraTarget()
    {
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

    private void SetFrontCameraTarget()
    {
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

    private void EyeEvent()
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

    private void MoveEvent()
    {
        if (!controller || !animator) { return; }
        InputsEvent();
        GroundEvent();
        GravityEvent();
        controller.Move(moveDirection * Time.deltaTime);
    }

    private float hor;
    private float ver;

    private void InputsEvent()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
    }

    private void JumpEvent()
    {
        moveDirection.y = jumpSpeed;
    }

    private void GravityEvent()
    {
        if (controller.isGrounded) return;
        moveDirection.y -= gravity * Time.deltaTime;
    }

    private void GroundEvent()
    {
        if (!controller.isGrounded) {return;}
        
        WalkEvent();
        
        animator.SetFloat("Horizontal", hor);
        animator.SetFloat("Vertical", ver);
    }

    private void WalkEvent()
    {
        if (IsZero(hor) && IsZero(ver))
        {
            moveDirection = default;
            return;
        }
        
        RunEvent();
        
        moveDirection = new Vector3(hor, 0, ver);
        moveDirection = controller.transform.TransformDirection(moveDirection);
        moveDirection *= walkSpeed;
        
        if (!audioSource.isPlaying && isRun)
        {
            audioSource.Play();
        }
    }

    private bool IsZero(float num)
    {
        return Mathf.Abs(num) < 0.00001f;
    }

    private void RunEvent()
    {
        if(IsZero(ver)) return;//前进为0
        if (!isRun) return;//按键检测
        ver *= runSpeed;//速度
        isRun = true;//跑步中
    }

    public void OnClear()
    {
        Destroy(this.gameObject);
    }
}