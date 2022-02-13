using UnityEngine;

public class WeaponCombiner
{
    private WeaponControl myControl;
    private int pushId = -1;

    public int PushId
    {
        get { return pushId; }
    }

    public WeaponCombiner(WeaponControl control) {
        myControl = control;
    }

    public bool CombineWeapon(out long outWeaponId) {
        //绑定角色
        if (myControl.myDatas.TryGetWeaponInfo(pushId + 1, out var weaponInfo)) {
            Debug.LogError($"武器存在 重复创建 [Id：{weaponInfo.WeaponId}]");
            outWeaponId = 0;
            return false;
        }

        var supplier = myControl.AbsWorld.supplier;
        var obj = supplier.CreatGameObj(SUPPLIERTYPE.Weapon);
        var weaponId = ++pushId;
        var comId = supplier.BundleComponent<WeaponComponent>(myControl, obj, weaponId).ComponentId;
        var tempRoleInfo = new WeaponInfo(weaponId, comId);
        myControl.myDatas.AddWeaponInfo(tempRoleInfo);
        outWeaponId = weaponId;
        return true;
    }

    //武器绑定角色
    public bool CombineWeaponByRole(long roleId, out long outWeaponId)
    {
        outWeaponId = -1;
        return true;
    }
}