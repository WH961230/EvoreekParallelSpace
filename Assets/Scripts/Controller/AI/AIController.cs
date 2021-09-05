using UnityEngine;
using UnityEngine.UI;

public class AIController : MonoBehaviour, IBaseController
{
    public int AIId = -1;
    public string AIName;
    
    [Header("==== 移动参数 ====")]
    [Tooltip("重力系数")][SerializeField] float gravity;
    
    [Tooltip("角色")][SerializeField] Transform body;

    private Vector3 moveDirection = Vector3.zero;//移动方向

    public CharacterController cc;
    public AnimatorController ac;
    public Transform Tip;
    public Text text;
    public int hp;
    public int maxHp;
    public void OnInit()
    {
        InitController();
        InitBaseProperty();
        InitTipName();
    }
    
    private void InitBaseProperty() {
        //血量
        maxHp = ConfigMgr.Instance.AIConfig.MaxHp;
        hp = maxHp;
    }

    private void InitTipName()
    {
        text.text = AIName;
        Tip.gameObject.SetActive(false);
    }
    
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

    public void OnUpdate() {
        MoveEvent();
    }

    /// <summary>
    /// 移动事件
    /// </summary>
    private void MoveEvent()
    {
        if (!cc || !ac.animator)
        {
            return;
        }
        GravityEvent();
        cc.Move(moveDirection * Time.deltaTime);

        // InputsEvent();
        // JumpEvent();
        // GroundEvent();
    }
    
    private void GravityEvent()
    {
        if (cc.isGrounded)
        {
            return;
        }
        moveDirection.y -= gravity * Time.deltaTime;
    }

    public void OnFixedUpdate() {
    }

    public void OnLateUpdate() {
    }

    public void OnClear() {
    }
}