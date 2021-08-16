using Controller;

public static class GameData {
    //玩家
    public static PlayerController player;
    //相机
    private static CameraController gameCamera;
    private static CameraFrontController gameFrontCamera;
    //全局
    public static InputMgr inputMgr;
    public static CameraController GameCamera {
        get { return gameCamera; }
        set { gameCamera = value; }
    }
    
    public static CameraFrontController GameFrontCamera {
        get { return gameFrontCamera; }
        set { gameFrontCamera = value; }
    }
}
