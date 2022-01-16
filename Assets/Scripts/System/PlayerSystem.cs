using UnityEngine;

public class PlayerSystem : MySystem
{
    public override void OnInit(IGameWorld gameWorldMaster)
    {
        base.OnInit(gameWorldMaster);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        Debug.LogError("player");
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