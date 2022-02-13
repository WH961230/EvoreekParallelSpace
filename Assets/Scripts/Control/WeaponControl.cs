using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : AbsControl
{
    private WeaponSystem mySystem;
    public WeaponData myDatas;
    private SUPPLIERTYPE myType;
    public WeaponCombiner myCombiner;
    private long indexId = -1;

    public long IndexId
    {
        get { return indexId; }
    }
    public override void OnInit(AbsSystem system) {
        base.OnInit(system);
        mySystem = (WeaponSystem)system;
        myType = SUPPLIERTYPE.Weapon;
        myDatas = new WeaponData();
        myCombiner = new WeaponCombiner(this);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (myCombiner.CombineWeapon(out long weaponId))
            {
                Debug.LogError($"创建武器 [id:{weaponId}]");
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

    public override void OnClear()
    {
        base.OnClear();
    }
}