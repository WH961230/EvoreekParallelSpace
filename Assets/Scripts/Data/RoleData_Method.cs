public partial class RoleData {
    public long PushId() {
        return ++pushId;
    }

    public void AddRoleInfo(RoleInfo info) {
        AllRoleInfos?.Add(info);
    }

    public bool TryGetRoleInfo(long roleId, out RoleInfo roleInfo) {
        for (var i = 0; i < AllRoleInfos.Count; i++) {
            var info = AllRoleInfos[i];
            if (roleId == info.RoleId) {
                roleInfo = info;
                return true;
            }
        }

        roleInfo = null;
        return false;
    }
}