using UnityEngine;

public class WorldData {
    //基础配置
    public WorldInfo worldInfo;
    //运行数据
    public RunInfo worldRunInfo;
    public WorldData(WorldInfo info) {
        worldInfo = info;
        Debug.Log($"Init=>{worldInfo.ToString()}");
    }
}

public struct RunInfo {
    public bool isSceneActive;
}

public struct WorldInfo {
    public long worldId;
    public string worldSign;
    public string sceneSign;
    public override string ToString() {
        return $"[worldId:{worldId}][worldSign:{worldSign}[sceneSign:{sceneSign}]]";
    }
}