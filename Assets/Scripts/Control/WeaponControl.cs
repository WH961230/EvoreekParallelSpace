using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : AbsControl
{
    private WeaponSystem mySystem;
    private List<WeaponData> myDatas = new List<WeaponData>();
    private SUPPLIERTYPE myType;
    private long indexId = -1;
    public override void OnInit(AbsSystem system) {
        base.OnInit(system);
        mySystem = (WeaponSystem)system;
        myType = SUPPLIERTYPE.Weapon;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (Input.GetKeyDown(KeyCode.W))
        {
            CreateWeapon();
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

    private void CreateWeapon()
    {
        var data = GetWeaponDataById(indexId + 1);
        if (null != data) {
            Debug.LogError($"武器存在 重复创建 [Id：{data.weaponId}]");
            return;
        }

        var supplier = mySystem.MyAbsWorld.supplier;
        var tempObj = supplier.CreatGameObj(myType);
        ++indexId;
        var wId = indexId;
        var component = supplier.BundleComponent<WeaponComponent>(this, tempObj, wId);
        var tempData = new WeaponData() {
            weaponId = wId,
            WeaponComponent = component,
        };

        myDatas.Add(tempData);
        var str = "";
        foreach (var d in myDatas) {
            str += $"当前角色 => weaponId:{d.weaponId} weaponComponent:{d.WeaponComponent.ComponentId} \n";
        }
        Debug.LogError(str);
    }

    private WeaponData GetWeaponDataById(long weaponId)
    {
        if (null != myDatas)
        {
            for (int i = 0; i < myDatas.Count; i++)
            {
                var data = myDatas[i];
                if (weaponId == data.weaponId)
                {
                    return data;
                }
            }
        }

        return null;
    }
}