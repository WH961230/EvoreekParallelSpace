using UnityEngine;
using UnityEngine.SceneManagement;

public class World : AbsWorld {
    public WorldData myWorldData;
    public override void OnInit(WorldInfo info) {
        base.OnInit(info);
        if (info.sceneConfig.loadType == 1) {
            SceneManager.LoadSceneByMode(info.sceneConfig.sceneSign, LoadSceneMode.Additive);
        }

        myWorldData = new WorldData(info);
        systemManager.AddSystem<RoleSystem>();
        systemManager.AddSystem<WeaponSystem>();
    }
}