using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RigController : MonoBehaviour,IBaseController
{
    public RigBuilder rb;
    [Tooltip("角色权重切换速度")]public float RigWeightChangeSpeed;

    //Rig子层标识
    private const string RightHandIK = "RightHand_IK";
    private const string LeftHandIK = "LeftHand_IK";
    private const string WeaponPose = "WeaponPose";
    private const string WeaponAiming = "WeaponAiming";

    //Rig Layer 标识
    private const string RL_BodyIK = "RigLayer_BodyIK";
    private const string RL_HandIK = "RigLayer_HandIK";
    private const string RL_WeaponPose = "RigLayer_WeaponPose";
    private const string RL_WeaponAiming = "RigLayer_WeaponAiming";
    
    //Rig Layer
    private RigLayer RigLayer_BodyIK;
    private RigLayer RigLayer_HandIK;
    private RigLayer RigLayer_WeaponPose;
    private RigLayer RigLayer_WeaponAiming;
    
    //Rig Layer Weight 期望值
    private float RigLayer_BodyIK_Weight = 0;
    private float RigLayer_HandIK_Weight = 0;
    private float RigLayer_WeaponPose_Weight = 0;
    private float RigLayer_WeaponAiming_Weight = 0;
    public void OnInit()
    {
        SetRigLayer();
        SetRigLayerWeight(RigLayer_BodyIK,0);
        SetRigLayerWeight(RigLayer_HandIK,0);
        SetRigLayerWeight(RigLayer_WeaponPose,0);
        SetRigLayerWeight(RigLayer_WeaponAiming,0);
    }

    /// <summary>
    /// 设置 rig layer 层级
    /// </summary>
    private void SetRigLayer()
    {
        foreach (var l in rb.layers)
        {
            if (l.name.Equals(RL_BodyIK)) { RigLayer_BodyIK = l; }
            if (l.name.Equals(RL_HandIK)) { RigLayer_HandIK = l; }
            if (l.name.Equals(RL_WeaponPose)) { RigLayer_WeaponPose = l; }
            if (l.name.Equals(RL_WeaponAiming)) { RigLayer_WeaponAiming = l; }
        }
    }
    
    /// <summary>
    /// 设置指定层级的 rig 权重
    /// </summary>
    /// <param name="rl"></param>
    /// <param name="weight"></param>
    private void SetRigLayerWeight(RigLayer rl, float weight)
    {
        rl.rig.weight = weight;
    }

    /// <summary>
    /// 普通拿着武器设置 rig 权重
    /// </summary>
    public void OnWeaponNormalHandle()
    {
        RigLayer_BodyIK_Weight = 0;
        RigLayer_HandIK_Weight = 1;
        RigLayer_WeaponPose_Weight = 1;
        RigLayer_WeaponAiming_Weight = 0;
    }

    /// <summary>
    /// 武器瞄准设置 rig 权重
    /// </summary>
    public void OnWeaponAimHandle()
    {
        RigLayer_BodyIK_Weight = 1;
        RigLayer_HandIK_Weight = 1;
        RigLayer_WeaponPose_Weight = 1;
        RigLayer_WeaponAiming_Weight = 1;
    }
    
    /// <summary>
    /// 设置武器瞄准的指定跟随武器
    /// </summary>
    /// <param name="weaponAimingTarget"></param>
    public void OnSetWeaponAimingTarget(Transform weaponAimingTarget)
    {
        var weaponPose = RigLayer_WeaponAiming.rig.transform.Find(WeaponAiming);
        if (null != weaponPose)
        {
            var tbc = weaponPose.GetComponent<MultiParentConstraint>();
            if (null != tbc)
            {
                tbc.data.constrainedObject = weaponAimingTarget;
            }
        }

        rb.Build();
    }
    
    public void OnSetWeaponPoseTarget(Transform weaponPoseTarget)
    {
        var weaponPose = RigLayer_WeaponPose.rig.transform.Find(WeaponPose);
        if (null != weaponPose)
        {
            var tbc = weaponPose.GetComponent<MultiParentConstraint>();
            if (null != tbc)
            {
                tbc.data.constrainedObject = weaponPoseTarget;
            }
        }

        rb.Build();
    }

    public void OnSetHandIKTarget(Transform targetRightHandGripTran, Transform targetLeftHandGripTran)
    {
        //右手
        var rightHandIK = RigLayer_HandIK.rig.transform.Find(RightHandIK);
        if (null != rightHandIK)
        {
            var tbc = rightHandIK.GetComponent<TwoBoneIKConstraint>();
            if (null != tbc)
            {
                tbc.data.target = targetRightHandGripTran;
            }
        }
        //左手
        var leftHandIK = RigLayer_HandIK.rig.transform.Find(LeftHandIK);
        if (null != leftHandIK)
        {
            var tbc = leftHandIK.GetComponent<TwoBoneIKConstraint>();
            if (null != tbc)
            {
                tbc.data.target = targetLeftHandGripTran;
            }
        }

        rb.Build();
    }
    
    public void OnUpdate()
    {
        RigLerpEvent();
    }

    private void RigLerpEvent()
    {
        if (Mathf.Abs(RigLayer_HandIK.rig.weight - RigLayer_HandIK_Weight) > 0.0001f)
        {
            RigLayer_HandIK.rig.weight = Mathf.Lerp(RigLayer_HandIK.rig.weight, RigLayer_HandIK_Weight,
                Time.deltaTime * RigWeightChangeSpeed);
        }

        if (Mathf.Abs(RigLayer_BodyIK.rig.weight - RigLayer_BodyIK_Weight) > 0.0001f)
        {
            RigLayer_BodyIK.rig.weight = Mathf.Lerp(RigLayer_BodyIK.rig.weight, RigLayer_BodyIK_Weight,
                Time.deltaTime * RigWeightChangeSpeed);
        }

        if (Mathf.Abs(RigLayer_WeaponPose.rig.weight - RigLayer_WeaponPose_Weight) > 0.0001f)
        {
            RigLayer_WeaponPose.rig.weight = Mathf.Lerp(RigLayer_WeaponPose.rig.weight, RigLayer_WeaponPose_Weight,
                Time.deltaTime * RigWeightChangeSpeed);
        }

        if (Mathf.Abs(RigLayer_WeaponAiming.rig.weight - RigLayer_WeaponAiming_Weight) > 0.0001f)
        {
            RigLayer_WeaponAiming.rig.weight = Mathf.Lerp(RigLayer_WeaponAiming.rig.weight, RigLayer_WeaponAiming_Weight,
                Time.deltaTime * RigWeightChangeSpeed);
        }
    }

    public void OnFixedUpdate()
    {
    }

    public void OnLateUpdate()
    {
    }

    public void OnClear()
    {
    }
}
