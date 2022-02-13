using UnityEngine;

//角色绑定
public class RoleCombiner {
    private RoleControl myControl;
    private int pushId = -1;

    public int PushId
    {
        get { return pushId; }
    }

    public RoleCombiner(RoleControl control) {
        myControl = control;
    }

    public bool CombineRole(out long outRoleId) {
        //绑定角色
        if (myControl.myDatas.TryGetRoleInfo(pushId + 1, out var roleInfo)) {
            Debug.LogError($"角色存在 重复创建 [Id：{roleInfo.RoleId}]");
            outRoleId = 0;
            return false;
        }

        var supplier = myControl.AbsWorld.supplier;
        var obj = supplier.CreatGameObj(SUPPLIERTYPE.Role);
        var roleId = ++pushId;
        var comId = supplier.BundleComponent<RoleComponent>(myControl, obj, roleId).ComponentId;
        var tempRoleInfo = new RoleInfo(roleId, comId);
        myControl.myDatas.AddRoleInfo(tempRoleInfo);
        PrintLog();
        outRoleId = roleId;
        return true;
    }

    public bool CombineWeapon(long roleId, out long outWeaponId)
    {
        //找到角色id 绑定新武器
        if(myControl.myDatas.TryGetRoleInfo(roleId, out RoleInfo roleInfo))
        {
            var weaponControl = myControl.mySystem.manager.GetControl<WeaponControl>();
            //绑定新武器 - 单纯绑定
            // if (weaponControl.myCombiner.CombineWeapon(out long tempWId))
            // {
            //     outWeaponId = tempWId;
            // }

            weaponControl.myCombiner.CombineWeaponByRole(roleId, out long weaponId);
            outWeaponId = weaponId;
            return true;
        }
    
        Debug.LogError($"角色不存在 绑定武器失败！");
        outWeaponId = -1;
        return false;
    }

    private void PrintLog() {
        var str = "";
        foreach (var d in myControl.myDatas.AllRoleInfos)
        {
            str += $"当前角色 => roleId:{d.RoleId} roleComponent:{d.ComponentId} \n";
        }
        Debug.LogError(str);
    }
}