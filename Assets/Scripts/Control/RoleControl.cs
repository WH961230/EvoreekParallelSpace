using UnityEngine;

public class RoleControl : AbsControl {
    public RoleSystem mySystem;
    private SUPPLIERTYPE myType;
    public RoleData myDatas;
    private RoleCombiner myCombiner;
    public override void OnInit(AbsSystem system)
    {
        base.OnInit(system);
        mySystem = (RoleSystem)system;
        myType = SUPPLIERTYPE.Role;
        myDatas = new RoleData();
        myCombiner = new RoleCombiner(this);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (myCombiner.CombineRole(out long roleId))
            {
                Debug.LogError(manager.GetComponent<RoleComponent>(roleId).ComponentId);
                if (myCombiner.CombineWeapon(roleId, out long weaponId))
                {
                    
                }
            }
        }
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
    }

    public override void OnLateUpdate()
    {
        base.OnLateUpdate();
    }

    public override void OnClear() {
        base.OnClear();
    }
}