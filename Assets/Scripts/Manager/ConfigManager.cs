using System.IO;

public class ConfigManager : Singleton<ConfigManager> {
    private GameConfig gameConfig;
    private RoleConfig roleConfig;
    public void OnInit() {
        gameConfig = new GameConfig();
        roleConfig = new RoleConfig();
        GameConfig.Get("1");
    }

    public string[] GetConfigRawData(string fileName) {
        return null;
    }
}