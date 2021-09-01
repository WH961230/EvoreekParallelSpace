using System;
using Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// 角色控制 - 行为
/// </summary>
public class PlayerController : MonoBehaviour, IBaseController
{
    [Header("==== 角色ID ====")] 
    [SerializeField] public int playerId = -1;
    [SerializeField] public string playerName;

    [FormerlySerializedAs("controller")]
    [Header("==== 控制器 ====")] 
    [Tooltip("角色控制器")][SerializeField] CharacterController characterController;
    [Tooltip("角色")][SerializeField] Transform body;

    [Tooltip("音频")][SerializeField] AudioSource audioSource;

    [Header("==== 移动参数 ====")]
    [Tooltip("重力系数")][SerializeField] float gravity;

    [Tooltip("行走速度")][SerializeField] float walkSpeed;//行走速度
    [Tooltip("跑步速度系数")][SerializeField] float runSpeed;//跑步速度系数
    [Tooltip("跳跃速度")][SerializeField] float jumpSpeed;//跳跃速度

    [Tooltip("相机左右视角速度")][SerializeField] float ySpeed;//相机左右视角速in
    [Tooltip("相机上下视角速度")][SerializeField] float xSpeed;//相机上下视角速度

    [Header("==== 预制 ====")]
    [Tooltip("挂载在角色身上的相机目标")][SerializeField] Transform roleCameraTarget;

    [Tooltip("角色面相机移动向导")][SerializeField] Transform roleFrontCameraTarget;
    [Tooltip("角色相机旋转物体")][SerializeField] Transform roleCameraRotObj;

    [Tooltip("跑步控制器")][SerializeField] public bool RunInput;//跑步控制器
    [Tooltip("跳跃控制器")][SerializeField] public bool JumpInput;//跑步控制器

    [SerializeField] private bool isWalk;
    [SerializeField] private bool isRun;
    [SerializeField] private bool isJump;
    public float dropForce;
    
    private Vector3 moveDirection = Vector3.zero;//移动方向
    private float hor;//水平输入
    private float ver;//垂直输入
    
    public AnimatorController ac;
    public Transform weaponHandleTran;//武器挂载点
    public Transform weaponTran;
    private RaycastHit hit;

    public PlayerOperateWin pow;
    public AnimatorControl acl;

    public void OnInit()
    {
        InitController();
        acl.OnInit();
        MessageCenter.Instance.Register(MessageCode.Play_Attack, AttackEvent);
        MessageCenter.Instance.Register(MessageCode.Play_Reload, ReloadEvent);
        MessageCenter.Instance.Register(MessageCode.Play_PickWeapon, PlayerPickWepaon);
        MessageCenter.Instance.Register(MessageCode.Play_DropWeapon, PlayerDropWeapon);
        pow = FindObjectOfType<PlayerOperateWin>();
    }

    /// <summary>
    /// 初始化控制器 - 玩家控制器 动画控制器
    /// </summary>
    private void InitController()
    {
        //如果控制器不为空 创建动画控制器 赋值动画控制器
        if (null != body)
        {
            ac = new AnimatorController();
            var ani = body.GetComponent<Animator>();
            if (null != ani)
            {
                ac.animator = ani;
            }
        }
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

    private void PlayerDropWeapon()
    {
        PlayerWeaponHandle.Instance.PlayerDropWeapon(playerId);
    }

    /// <summary>
    /// 挂载武器 - 表现
    /// </summary>
    /// <param name="weaponTran"></param>
    public void HandleWeapon(Transform weaponTran)
    {
        Destroy(weaponTran.GetComponent<Rigidbody>());
        weaponTran.parent = weaponHandleTran;
        weaponTran.localPosition = Vector3.zero;
        weaponTran.localRotation = Quaternion.identity;
    }
    
    /// <summary>
    /// 丢弃武器 - 表现
    /// </summary>
    /// <param name="weaponTran"></param>
    public void DropWeapon(Transform weaponTran)
    {
        var rb = weaponTran.AddComponent<Rigidbody>();
        var controllerTran = characterController.transform;
        weaponTran.parent = null;//父物体最高级
        weaponTran.position = controllerTran.position + controllerTran.forward * 0.5f;
        weaponTran.rotation = controllerTran.rotation;
        rb.AddForce(controllerTran.forward * dropForce, ForceMode.Impulse);
    }

    /// <summary>
    /// 射击事件
    /// </summary>
    void AttackEvent()
    {
        var wid = PlayerWeaponHandle.Instance.PlayerGetCurWeapon(playerId);
        var weapon = WeaponMgr.Instance.GetWeaponById(wid);
        if (null != weapon)
        {
            //根据攻击类型执行攻击
            AttackByType(weapon.BaseData);   
        }
    }

    void ReloadEvent()
    {
        ReloadByType(new WeaponBaseData());
    }

    /// <summary>
    /// 玩家发起 - 装载
    /// </summary>
    /// <param name="baseData"></param>
    void ReloadByType(WeaponBaseData baseData)
    {
        switch (baseData.weaponType)
        {
            case WeaponType.近战:
                Debug.Log("近战暂未开发");
                break;
            case WeaponType.枪械:
                break;
            case WeaponType.投掷:
                Debug.Log("投掷暂未开发");
                break;
        }
    }

    /// <summary>
    /// 玩家发起 - 攻击
    /// </summary>
    /// <param name="baseData"></param>
    void AttackByType(WeaponBaseData baseData)
    {
        switch (baseData.weaponType)
        {
            case WeaponType.近战:
                Debug.Log("近战暂未开发");
                break;
            case WeaponType.枪械:
                baseData.weaponController.ShotEvent();
                break;
            case WeaponType.投掷:
                Debug.Log("投掷暂未开发");
                break;
        }
    }

    /// <summary>
    /// 设置相机目标
    /// </summary>
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

    /// <summary>
    /// 设置面相机目标
    /// </summary>
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

    /// <summary>
    /// 角色视角事件
    /// </summary>
    private void EyeEvent()
    {
        //视角相关事件
        EyeRotEvent();
        EyeRaycaseEvent();
    }

    private void EyeRotEvent()
    {
        if (!roleCameraRotObj || !characterController)
        {
            return;
        }

        var y = Input.GetAxis("Mouse Y");
        var x = Input.GetAxis("Mouse X");
        characterController.transform.Rotate(Vector3.up * x * xSpeed);
        roleCameraRotObj.transform.Rotate(Vector3.left * y * ySpeed);
    }

    private void EyeRaycaseEvent()
    {
        // var playerOperateWin = PlayerOperateController.Instance.PlayerOperateWin;
        var ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Item")))
        {
            var wc = hit.collider.GetComponent<WeaponController>();
            if (null != wc)
            {
                pow.Tip.text = wc.weaponName;
            }

            var bsb = hit.collider.GetComponent<BulletSupplyBox>();
            if (null != bsb)
            {
                pow.Tip.text = bsb.AMMO_TIP;
            }
        }
        else
        {
            pow.Tip.text = "";
        }
    }

    /// <summary>
    /// 拾起武器
    /// </summary>
    private void PlayerPickWepaon()
    {
        if (null == hit.collider)
        {
            return;
        }

        var wc = hit.collider.GetComponent<WeaponController>();
        if (null == wc)
        {
            return;
        }
        var wid = wc.weaponId;
        var w = WeaponMgr.Instance.GetWeaponById(wid);
        if (null != w)
        {
            PlayerWeaponHandle.Instance.PlayerPickWeapon(playerId, wid);
            var p = PlayerMgr.Instance.GetPlayerById(playerId);
            p.BaseData.playerController.weaponTran = hit.collider.transform;
        }
    }

    /// <summary>
    /// 移动事件
    /// </summary>
    private void MoveEvent()
    {
        if (!characterController || !ac.animator)
        {
            return;
        }

        InputsEvent();
        JumpEvent();
        GroundEvent();
        GravityEvent();
        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void JumpEvent()
    {
        //没有跳跃指令返回
        if (!JumpInput)
        {
            return;
        }

        if (isJump)
        {
            return;
        }
        
        if (ac.animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            return;
        }

        //跳跃高度赋值
        moveDirection.y = jumpSpeed;
        isJump = true; 
        ac.animator.SetBool("Jump",true);
    }
    /// <summary>
    /// 获取输入
    /// </summary>
    private void InputsEvent()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
    }

    /// <summary>
    /// 重力系统
    /// </summary>
    private void GravityEvent()
    {
        if (characterController.isGrounded)
        {
            return;
        }
        moveDirection.y -= gravity * Time.deltaTime;
    }

    /// <summary>
    /// 地面事件
    /// </summary>
    private void GroundEvent()
    {
        //不在地面返回
        if (!characterController.isGrounded)
        {
            return;
        }

        //如果还在跳跃状态 - 跳跃重置
        if (isJump)
        {
            isJump = false;
            ac.animator.SetBool("Jump",false);
        }

        //走路事件
        WalkEvent();

        //状态机设定
        ac.animator.SetFloat("Horizontal", hor);
        ac.animator.SetFloat("Vertical", ver);
    }

    /// <summary>
    /// 行走事件
    /// </summary>
    private void WalkEvent()
    {
        //没有输入前进或者后退
        if (IsZero(hor) && IsZero(ver))
        {
            moveDirection = default;
            isWalk = false;
            return;
        }
        
        //跑步事件
        RunEvent();
        
        //角色移动向量
        moveDirection = new Vector3(hor, 0, ver);
        moveDirection = characterController.transform.TransformDirection(moveDirection);
        moveDirection *= walkSpeed;
        isWalk = true;

        //音频
        if (!audioSource.isPlaying && isRun)
        {
            audioSource.Play();
        }
    }

    /// <summary>
    /// float 值是否为0
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    private bool IsZero(float num)
    {
        return Mathf.Abs(num) < 0.00001f;
    }

    /// <summary>
    /// 跑步事件
    /// </summary>
    private void RunEvent()
    {
        //垂直输入向量为 0
        if (IsZero(ver))
        {
            isRun = false;
            return; 
        }

        //没有跑步按键检测
        if (!RunInput)
        {
            isRun = false;
            return;
        }

        //速度
        ver *= runSpeed; 
        isRun = true;
    }

    /// <summary>
    /// 清除角色 - 销毁 GO
    /// </summary>
    public void OnClear()
    {
        Destroy(this.gameObject);
    }
}