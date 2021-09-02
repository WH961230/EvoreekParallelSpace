using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RigController : MonoBehaviour,IBaseController
{
    public RigBuilder rb;

    private const string RightHandIK = "RightHand_IK";
    private const string LeftHandIK = "LeftHand_IK";
    
    private const string WeaponPose = "WeaponPose";
    private const string WeaponAiming = "WeaponAiming";

    private const string RL_BodyIK = "RigLayer_BodyIK";
    private const string RL_HandIK = "RigLayer_HandIK";
    private const string RL_WeaponPose = "RigLayer_WeaponPose";
    private const string RL_WeaponAiming = "RigLayer_WeaponAiming";
    
    private RigLayer RigLayer_BodyIK;
    private RigLayer RigLayer_HandIK;
    private RigLayer RigLayer_WeaponPose;
    private RigLayer RigLayer_WeaponAiming;

    public void OnInit()
    {
        SetRigLayer();
        SetRigLayerWeight(RigLayer_BodyIK,0);
        SetRigLayerWeight(RigLayer_HandIK,0);
        SetRigLayerWeight(RigLayer_WeaponPose,0);
        SetRigLayerWeight(RigLayer_WeaponAiming,0);
    }

    private void SetRigLayer()
    {
        foreach (var l in rb.layers)
        {
            if (l.name.Equals(RL_BodyIK))
            {
                RigLayer_BodyIK = l;
            }
            if (l.name.Equals(RL_HandIK))
            {
                RigLayer_HandIK = l;
            }
            if (l.name.Equals(RL_WeaponPose))
            {
                RigLayer_WeaponPose = l;
            }
            if (l.name.Equals(RL_WeaponAiming))
            {
                RigLayer_WeaponAiming = l;
            }
        }
    }
    
    private void SetRigLayerWeight(RigLayer rl, int weight)
    {
        rl.rig.weight = weight;
    }

    /// <summary>
    /// 普通拿着武器
    /// </summary>
    public void OnWeaponNormalHandle()
    {
        SetRigLayerWeight(RigLayer_BodyIK,0);
        SetRigLayerWeight(RigLayer_HandIK, 1);
        SetRigLayerWeight(RigLayer_WeaponPose,1);
        SetRigLayerWeight(RigLayer_WeaponAiming,0);
    }

    /// <summary>
    /// 武器瞄准
    /// </summary>
    public void OnWeaponAimHandle()
    {
        SetRigLayerWeight(RigLayer_BodyIK,1);
        SetRigLayerWeight(RigLayer_HandIK, 1);
        SetRigLayerWeight(RigLayer_WeaponPose,1);
        SetRigLayerWeight(RigLayer_WeaponAiming,1);
    }
    
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
