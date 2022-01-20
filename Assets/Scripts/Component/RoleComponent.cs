﻿using UnityEngine;

public class RoleComponent : MyComponent {
    private long comId;
    public void OnInit<T> (IControlBase controlBase, long comId){
        base.OnInit<RoleComponent>(controlBase, comId);
    }

    public override void OnUpdate() {
        base.OnUpdate();
    }

    public override void OnFixedUpdate() {
        base.OnFixedUpdate();
    }

    public override void OnLateUpdate() {
        base.OnLateUpdate();
    }

    public override void OnClear() {
        base.OnClear();
    }
}