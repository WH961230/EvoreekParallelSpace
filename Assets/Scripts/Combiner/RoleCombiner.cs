using UnityEngine;

//角色绑定
public class RoleCombiner {
    private RoleControl myControl;
    private int pushId = -1;
    public RoleCombiner(RoleControl control) {
        myControl = control;
    }

    public bool CombineRole(out long outRoleId) {
        if (myControl.myDatas.TryGetRoleInfo(pushId + 1, out var roleInfo)) {
            Debug.LogError($"角色存在 重复创建 [Id：{roleInfo.RoleId}]");
            outRoleId = 0;
            return false;
        } else {
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