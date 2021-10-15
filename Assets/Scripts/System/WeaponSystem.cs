public class WeaponSystem : SystemBase{
    public override void OnInit(GameEngine gameEngine) {
        base.OnInit(gameEngine);
    }

    public override void OnUpdate() {
        base.OnUpdate();
    }

    public override void OnClear() {
        base.OnClear();
    }

    protected override void InitMgr() {
        base.InitMgr();
        if (null == MyManager) {
            MyManager = new WeaponManager();
        }
    }
}