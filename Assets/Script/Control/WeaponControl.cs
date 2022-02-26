using UnityEngine;

public class WeaponControl : AbsControl {
    public override void OnInit(AbsSystem system) {
        base.OnInit(system);
        mySystem = (WeaponSystem) system;
        myDatas = new WeaponData();
        myDatas.OnInit(this);
        myType = SUPPLIERTYPE.Item;
    }

    public override void OnUpdate() {
        base.OnUpdate();
        if (Input.GetKeyDown(KeyCode.W)) {
            myDatas.Create("M4");
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