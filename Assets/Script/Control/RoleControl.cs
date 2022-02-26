using UnityEngine;

public class RoleControl : AbsControl {
    public override void OnInit(AbsSystem system) {
        base.OnInit((RoleSystem)system);
        myDatas = new RoleData();
        myDatas.OnInit(this);
        myType = SUPPLIERTYPE.Role;
    }

    public override void OnUpdate() {
        base.OnUpdate();
        if (Input.GetKeyDown(KeyCode.Space)) {
            myDatas.Create("SM_Chr_Bombsuit_Male_01");;
        }
    }

    public override void OnFixedUpdate() {
        base.OnFixedUpdate();
    }

    public override void OnLateUpdate() {
        base.OnLateUpdate();
    }

    public override void OnClear() {
        base.OnClear();
    }
}