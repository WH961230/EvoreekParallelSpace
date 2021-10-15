public interface IBaseSystem {
    void OnInit(GameEngine gameEngine);
    void OnUpdate();
    void OnClear();
}

public class SystemBase : IBaseSystem {
    private GameEngine gameEngine;
    public GameEngine MyGameEngine => gameEngine;

    public virtual void OnInit(GameEngine gameEngine) {
        this.gameEngine = gameEngine;
        this.gameEngine.Systems.Add(this);
    }

    public virtual void InitData() {
    }

    public virtual void OnUpdate() {
    }

    public virtual void OnClear() {
    }
}