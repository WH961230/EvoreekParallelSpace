using UnityEngine.SceneManagement;

public class World : AbsWorld {
    public override void OnInit(WorldInfo info) {
        base.OnInit(info);
        if (info.sceneConfig.loadType == 1) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(info.sceneConfig.sceneSign, LoadSceneMode.Additive);
        }

        WorldData.worldInfo = info;
        systemManager.AddSystem<RoleSystem>();
        systemManager.AddSystem<WeaponSystem>();
    }
}