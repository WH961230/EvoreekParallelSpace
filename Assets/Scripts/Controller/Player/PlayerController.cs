using Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
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
    [Tooltip("角色控制器")][SerializeField] public CharacterController characterController;
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
    [SerializeField] private bool isAim;
    
    public int hp;
    public int maxHp;
    public float dropForce;
    
    private Vector3 moveDirection = Vector3.zero;//移动方向
    private float h;//水平输入
    private float v;//垂直输入
    private float mouseX;//鼠标X
    private float mouseY;//鼠标Y

    private AnimatorController ac;
    private RaycastHit hit;

    private PlayerOperateWin pow;
    public RigController rc;
    public Transform weaponRoot;
    private Transform tip;
    public Player MyPlayer;
    
    public void OnInit(Player player)
    {
        MyPlayer = player;
        InitController();
        rc.OnInit();
        
        MessageCenter.Instance.Register(MessageCode.Play_Attack, Attack);
        MessageCenter.Instance.Register(MessageCode.Play_PickWeapon, PlayerPickWepaon);
        MessageCenter.Instance.Register(MessageCode.Play_DropWeapon, PlayerDropWeapon);
        MessageCenter.Instance.Register(MessageCode.Play_Aim, Aim);
        
        pow = FindObjectOfType<PlayerOperateWin>();
        InitBaseProperty();
    }

    private void InitBaseProperty() {
        maxHp = ConfigManager.Instance.config.MaxHp;
        hp = maxHp;
    }

    private void InitController()
    {
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
        Move();
        Eye();
        rc.OnUpdate();
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
    /// 挂载武器 - Rig 表现
    /// </summary>
    /// <param name="weaponName"></param>
    public void WeaponNormalHandle(WeaponController wc)
    {
        Destroy(wc.gameObject.GetComponent<Rigidbody>());
        var t = wc.GetComponentInParent<Transform>();
        if (null != t)
        {
            t.SetParent(weaponRoot);
            t.localPosition = Vector3.zero;
            t.localRotation = Quaternion.identity;
            rc.OnSetWeaponAimingTarget(wc.transform);
            rc.OnSetWeaponPoseTarget(wc.transform);
            rc.OnSetHandIKTarget(wc.weaponRightHandGripTran, wc.weaponLeftHandGripTran);
            rc.OnWeaponNormalHandle();
        }
    }

    public void DropWeapon(Transform weaponTran)
    {
        var rb = weaponTran.AddComponent<Rigidbody>();
        var controllerTran = characterController.transform;
        weaponTran.parent = null;//父物体最高级
        weaponTran.position = controllerTran.position + controllerTran.forward * 0.5f;
        weaponTran.rotation = controllerTran.rotation;
        rb.AddForce(controllerTran.forward * dropForce, ForceMode.Impulse);
    }

    void Aim()
    {
        if (!isAim)
        {
            rc.OnWeaponAimHandle();
            isAim = true;
            GameData.GameCamera.isAim = true;
            Debug.Log("瞄准");
        }
        else
        {
            rc.OnWeaponNormalHandle();
            GameData.GameCamera.isAim = false;
            isAim = false;
        }
    }

    void Attack()
    {
        if (!isAim)
        {
            return;
        }
        var wid = PlayerWeaponHandle.Instance.PlayerGetCurWeapon(playerId);
        var weapon = WeaponManager.Instance.GetWeaponById(wid);
        if (null != weapon) {
            //根据攻击类型执行攻击
            AttackByType(weapon.BaseData);   
        }
    }

    void AttackByType(WeaponBaseData baseData)
    {
        switch (baseData.weaponType)
        {
            case WeaponType.近战:
                Debug.Log("近战暂未开发");
                break;
            case WeaponType.枪械:
                MessageCenter.Instance.Dispatcher(MessageCode.Weapon_Shot, playerId);
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
    private void Eye()
    {
        //视角相关事件
        EyeRot();
        EyeRaycase();
    }

    private void EyeRot()
    {
        if (!roleCameraRotObj || !characterController)
        {
            return;
        }
        characterController.transform.Rotate(Vector3.up * mouseX * xSpeed);
        roleCameraRotObj.transform.Rotate(Vector3.left * mouseY * ySpeed);
    }

    private void EyeRaycase()
    {
        var ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out hit, Mathf.Infinity,
            1 << LayerMask.NameToLayer("Item") | 1 << LayerMask.NameToLayer("AI"))) {
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
        } else {
            pow.Tip.text = "";
            if (null != tip && null != tip.gameObject)
            {
                tip.gameObject.SetActive(false);
            }
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
        var w = WeaponManager.Instance.GetWeaponById(wid);
        if (null != w)
        {
            //玩家捡起武器
            PlayerWeaponHandle.Instance.PlayerPickWeapon(playerId, wid);
        }
    }

    /// <summary>
    /// 移动事件
    /// </summary>
    private void Move()
    {
        if (!characterController || !ac.animator)
        {
            return;
        }
        Jump();
        Ground();
        Gravity();
        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void Jump()
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

    private void Input(InputData data)
    {
        mouseY = data.mouseY;
        mouseX = data.mouseX;
        h = data.horizontal;
        v = data.vertical;
    }

    private void Gravity()
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
    private void Ground()
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
        Walk();

        //状态机设定
        ac.animator.SetFloat("Horizontal", h);
        ac.animator.SetFloat("Vertical", v);
    }

    /// <summary>
    /// 行走事件
    /// </summary>
    private void Walk()
    {
        //没有输入前进或者后退
        if (IsZero(h) && IsZero(v))
        {
            moveDirection = default;
            isWalk = false;
            return;
        }
        
        //跑步事件
        Run();

        //角色移动向量
        moveDirection = new Vector3(h, 0, v);
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
    private void Run()
    {
        //垂直输入向量为 0
        if (IsZero(v))
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
        v *= runSpeed; 
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