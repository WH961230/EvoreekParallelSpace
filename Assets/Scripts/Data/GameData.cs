using Controller;
using UnityEngine;

public static class GameData {
    public static PlayerController player;
    private static CameraController gameCamera;
    private static CameraFrontController gameFrontCamera;

    public static CameraController GameCamera {
        get {
            return gameCamera;
        }
        set {
            gameCamera = value;
        }
    }
    
    public static CameraFrontController GameFrontCamera {
        get {
            return gameFrontCamera;
        }
        set {
            gameFrontCamera = value;
        }
    }
}
