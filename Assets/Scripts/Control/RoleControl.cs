using System.Collections.Generic;
using UnityEngine;

public class RoleControl : MyControl {
    private RoleSystem mySystem;
    private SUPPLIERTYPE myType;
    private List<RoleData> myDatas = new List<RoleData>();
    private long indexId = -1;
    public override void OnInit(MySystem system)
    {
        base.OnInit(system);
        mySystem = (RoleSystem)system;
        myType = SUPPLIERTYPE.Role;
    }

    //创建新角色
    private void CreatRole()
    {
        var data = GetRoleDataById(indexId + 1);
        if (null != data)
        {
            Debug.LogError($"角色存在 重复创建 [Id：{data.roleId}]");
            return;
        }

        var tempObj = Supplier.Instance.CreatGameObj(myType);
        ++indexId;
        var component = Supplier.Instance.AddComponent<RoleComponent>(tempObj, indexId);
        var tempData = new RoleData()
        {
            roleId = indexId,
            roleComponent = component,
        };
        myDatas.Add(tempData);
        var str = "";
        foreach (var d in myDatas)
        {
            str += $"当前角色 => roleId:{d.roleId} roleComponent:{d.roleComponent.name} \n";
        }
        Debug.LogError(str);
    }

    //根据角色 id 获取角色数据
    private RoleData GetRoleDataById(long roleId)
    {
        if (null != myDatas)
        {
            for (var i = 0; i < myDatas.Count; i++)
            {
                var data = myDatas[i];
                if (roleId == data.roleId)
                {
                    return data;
                }
            }
        }

        return null;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreatRole();
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