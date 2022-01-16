public interface ISystemBase
{
    void OnInit(IGameWorld gameWorld);
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnClear();
}

public abstract class AbsSystem : ISystemBase
{
    protected GameWorld gameWorld;

    public virtual void OnInit(IGameWorld gameWorldMaster)
    {
        gameWorld = (GameWorld) gameWorldMaster;
    }

    public virtual void OnUpdate() { }

    public virtual void OnFixedUpdate() { }

    public virtual void OnLateUpdate() { }
    public virtual void OnClear() { }
}

public class MySystem : AbsSystem
{
    public override void OnInit(IGameWorld gameWorldMaster)
    {
        base.OnInit(gameWorldMaster);
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