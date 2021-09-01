using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AnimatorControl : MonoBehaviour,IBaseController
{
    public RigBuilder rb;
    public AnimatorController ac;
    
    public void OnInit()
    {
       //"RigLayer_BodyIK"
       SetRigWeight("RigLayer_BodyIK", 0);
       SetRigWeight("RigLayer_HandIK", 0);
       SetRigWeight("RigLayer_WeaponPose", 0);
       SetRigWeight("RigLayer_WeaponAiming", 0);

    }

    public void SetRigWeight(string name, int weight)
    {
        foreach (var l in rb.layers)
        {
            if (string.Equals(name, l.rig.transform.name))
            {
                l.rig.weight = weight;
            }
        }
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
