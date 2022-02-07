using System.Collections.Generic;

public partial class RoleData {
    //所有玩家信息
    private List<RoleInfo> allRoleInfos = new List<RoleInfo>();
    public List<RoleInfo> AllRoleInfos {
        get { return allRoleInfos; }
    }
    
    private long pushId = -1;
}

public class RoleInfo {
    private long roleId;
    public long RoleId {
        get => roleId;
    }

    private long componentId;
    public long ComponentId {
        get => componentId;
    }

    public RoleInfo(long roleId, long componentId) {
        this.roleId = roleId;
        this.componentId = componentId;
    }
}