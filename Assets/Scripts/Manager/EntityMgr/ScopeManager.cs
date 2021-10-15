public class ScopeManager : Singleton<ScopeManager>, IBaseManager{
    public void OnInit(GameEngine gameEngine) {
        gameEngine.managers.Add(this);
    }

    public void OnUpdate() {
    }

    public void OnClear() {
    }
}