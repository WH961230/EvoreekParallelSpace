public interface IBaseData : IBaseSystem{
}

public class DataBase : IBaseData {
    private GameEngine gameEngine;
    public virtual void OnInit(GameEngine gameEngine) {
    }
    
    protected virtual void InitMgr() {
    }

    protected virtual void InitConfig() {
    }

    public virtual void OnUpdate() {
    }

    public virtual void OnClear() {
    }
}