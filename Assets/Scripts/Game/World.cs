public class World : AbsWorld{
    public override void OnInit(WorldInfo info) {
        base.OnInit(info);
        systemManager.AddSystem<RoleSystem>();
        systemManager.AddSystem<WeaponSystem>();
    }
}