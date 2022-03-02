using System;

public partial class RoleData {
    public override void OnInit(AbsControl control) {
        base.OnInit((RoleControl)control);
    }

    public override void Create(String prefabName) {
        if (Supplier.Instance.CreatInstance<RoleComponent>(myControl, prefabName, out int comInstanceId)) {
            var tempId = ++myCode;
            AddInfo(new RoleInfo() {
                Id = tempId, ComponentId = comInstanceId,
            });
            if (null == WorldData.role) {
                WorldData.role = new Role() {
                    Id = tempId, ComponentId = comInstanceId,
                };
            }
        }
    }
}