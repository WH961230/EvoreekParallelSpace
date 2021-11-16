public interface IBaseData : IBaseSystem{
}

public class DataBase : IBaseData
{
    protected ManagerBase MyManagerBase;
    protected GameEngine gameEngine;
    public virtual void OnInit(GameEngine gameEngine) {
    }

    public virtual void OnUpdate() {
    }

    public virtual void OnClear() {
    }
}