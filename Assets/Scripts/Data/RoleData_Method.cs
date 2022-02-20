using System;

public partial class RoleData {
    public override void OnInit(AbsControl control) {
        base.OnInit((RoleControl)control);
    }

    public override void Create(String prefabName) {
        Supplier.Instance.CreatInstance<RoleComponent>(myControl, prefabName, out int comInstanceId);
        AddInfo(new RoleInfo() {
            Id = ++myCode,
            ComInstanceId = comInstanceId,
        });
    }
}