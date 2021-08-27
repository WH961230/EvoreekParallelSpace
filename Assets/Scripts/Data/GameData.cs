using System.Collections.Generic;
using Controller;



public static class GameData {
    private static Player lockPlayer;
    private static CameraController gameCamera;
    private static CameraFrontController gameFrontCamera;

    public static Player LockPlayer {
        get { return lockPlayer;}
        set { lockPlayer = value; }
    }
    
    public static CameraController GameCamera {
        get { return gameCamera; }
        set { gameCamera = value; }
    }

    public static CameraFrontController GameFrontCamera {
        get { return gameFrontCamera; }
        set { gameFrontCamera = value; }
    }
}
