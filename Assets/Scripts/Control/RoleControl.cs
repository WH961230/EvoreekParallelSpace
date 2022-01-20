using UnityEngine;

public class RoleControl : MyControl
{
    private Transform RoleLayer;
    public override void OnInit(ISystemBase systemBase)
    {
        base.OnInit(systemBase);
        RoleLayer = CreatRoleLayer();
        CreatRole().OnInit<RoleComponent>(this, 1);
    }

    private RoleComponent CreatRole()
    {
        var g = Creator.Instance.Creat("Prefabs/Role/Role");
        var go = Object.Instantiate(g, RoleLayer, true);
        return go.AddComponent<RoleComponent>();
    }

    private Transform CreatRoleLayer()
    {
        return new GameObject("RoleLayer").transform;
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