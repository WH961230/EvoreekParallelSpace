﻿public class RoleSystem : MySystem {
    public RoleData data = new RoleData();
    public override void OnInit(IWorld worldMaster)
    {
        base.OnInit(worldMaster);
        ControlManager.Instance.AddControl<RoleControl>();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
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