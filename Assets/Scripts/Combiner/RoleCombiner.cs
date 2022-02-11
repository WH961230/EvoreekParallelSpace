using UnityEngine;

public class RoleCombiner {
    private RoleControl myControl;
    private long pushId = -1;
    public RoleCombiner(RoleControl control) {
        myControl = control;
    }

    public bool CombineRole() {
        if (myControl.myDatas.TryGetRoleInfo(pushId + 1, out var roleInfo)) {
            Debug.LogError($"角色存在 重复创建 [Id：{roleInfo.RoleId}]");
            return false;
        } else {
            //get creator
            var supplier = myControl.AbsWorld.supplier;
            //create obj by type
            var obj = supplier.CreatGameObj(SUPPLIERTYPE.Role);
            //info prepare
            ++pushId;
            var comId = supplier.BundleComponent<RoleComponent>(myControl, obj, pushId).ComponentId;
            var tempRoleInfo = new RoleInfo(pushId, comId);
            //add to datas
            myControl.myDatas.AddRoleInfo(tempRoleInfo);
            PrintLog();
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