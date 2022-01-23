using System;
using UnityEngine;

public class RoleControl : MyControl {
    private RoleSystem mySystem;
    private SUPPLIERTYPE myType;
    private RoleData myData;
    public override void OnInit(MySystem system)
    {
        base.OnInit(system);
        mySystem = (RoleSystem)system;
        myType = SUPPLIERTYPE.Role;
        myData = mySystem.data;
        CreatRole();
    }

    private void CreatRole()
    {
        var tempGameObj = Supplier.Instance.CreatGameObj(myType);
        Supplier.Instance.AddComponent<RoleComponent>(tempGameObj, this, 1);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
    }

    public override void OnLateUpdate()
    {
        base.OnLateUpdate();
    }

    public override void OnClear()
    {
        base.OnClear();
    }
}