using System;

public partial class WeaponData {
    public override void OnInit(AbsControl control) {
        base.OnInit((WeaponControl)control);
    }

    public override void Create(String prefabName) {
        Supplier.Instance.CreatInstance<WeaponComponent>(myControl, prefabName, out int comInstanceId);
        AddInfo(new WeaponInfo() {
            Id = ++myCode,
            ComInstanceId = comInstanceId,
        });
    }
}