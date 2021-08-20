using System.Collections.Generic;
using Controller;

public class PlayerData {
    public int id;
    public string name;
    public bool isLocalPlayer;
    public PlayerController controller;
}

public static class GameData {
    private static List<PlayerData> allPlayers;
    private static CameraController gameCamera;
    private static CameraFrontController gameFrontCamera;

    public static CameraController GameCamera {
        get { return gameCamera; }
        set { gameCamera = value; }
    }

    public static CameraFrontController GameFrontCamera {
        get { return gameFrontCamera; }
        set { gameFrontCamera = value; }
    }

    public static List<PlayerData> AllPlayers {
        get => allPlayers;
        set => allPlayers = value;
    }

    public static PlayerData GetLocalPlayer {
        get {
            PlayerData data = null;
            if (AllPlayers.Count <= 0) {
                return data;
            }

            foreach (var p in AllPlayers) {
                if (p.isLocalPlayer) {
                    data = p;
                    break;
                }
            }

            return data;
        }
    }
}
