public interface IBaseManager {
    void OnInit(GameEngine gameEngine);
    void OnUpdate();
    void OnClear();
}

public class ManagerBase : IBaseManager {
    private GameEngine gameEngine;
    public GameEngine MyGameEngine {
        get { return gameEngine; }
        set { gameEngine = value; }
    }
    public virtual void OnInit(GameEngine gameEngine) {
        this.gameEngine = gameEngine;
    }

    public virtual void OnUpdate() {
    }

    public virtual void OnClear() {
    }
}