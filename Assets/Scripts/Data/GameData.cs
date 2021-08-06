using UnityEngine;

public static class GameData {
    public static PlayerController player;
    private static CameraController gameCamera;

    public static CameraController GameCamera {
        get {
            return gameCamera;
        }
        set {
            gameCamera = value;
        }
    }
}
