public class ScopeMgr : Singleton<ScopeMgr>, IBaseMgr{
    public void OnInit(GameEngine gameEngine) {
        gameEngine.managers.Add(this);
    }

    public void OnUpdate() {
    }

    public void OnClear() {
    }
}