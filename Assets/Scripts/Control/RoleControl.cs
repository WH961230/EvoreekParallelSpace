using UnityEngine;

public class RoleControl : MyControl {
    private RoleSystem mySystem;
    private SUPPLIERTYPE myType;
    public RoleData myDatas;
    private RoleCombiner myCombiner;
    public override void OnInit(MySystem system)
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
            myCombiner.CombineRole();
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