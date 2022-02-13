using System.Collections.Generic;

public partial class RoleData {
    //所有玩家信息
    private List<RoleInfo> allRoleInfos = new List<RoleInfo>();
    public List<RoleInfo> AllRoleInfos {
        get { return allRoleInfos; }
    }
}

public class RoleInfo {
    private long roleId;
    public long RoleId {
        get => roleId;
    }

    private int componentId;
    public int ComponentId {
        get => componentId;
    }

    public RoleInfo(long roleId, int componentId) {
        this.roleId = roleId;
        this.componentId = componentId;
    }
}