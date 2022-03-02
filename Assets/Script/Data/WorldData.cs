using UnityEngine;

public static class WorldData {
    public static WorldInfo worldInfo; //基础配置
    public static Role role;
}

public struct WorldInfo {
    public GameConfig gameConfig; //游戏配置
    public SceneConfig sceneConfig; //场景配置

    public string WorldSign {
        get {
            if (null == gameConfig) {
                return "";
            }

            return gameConfig.worldSign;
        }
    }

    public long WorldId {
        get {
            if (null == gameConfig) {
                return -1;
            }

            return long.Parse(gameConfig.id);
        }
    }

    public override string ToString() {
        return $"[worldId:{gameConfig.id}]+" +
               $"[worldSign:{gameConfig.worldSign}]+" +
               $"[sceneSign:{sceneConfig.sceneSign}]+";
    }
}