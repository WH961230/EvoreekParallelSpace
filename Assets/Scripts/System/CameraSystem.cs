public class CameraSystem : SystemBase
{
    public CameraData data;
    public override void OnInit(GameEngine gameEngine) {
        base.OnInit(gameEngine);
    }

    public override void InitData() {
        base.InitData();
        data = new CameraData();
    }

    public override void OnFixedUpdate() {
        base.OnFixedUpdate();
    }

    public override void OnUpdate() {
        base.OnUpdate();
    }

    public override void OnClear() {
        base.OnClear();
    }
}