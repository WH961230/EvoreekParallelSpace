using System.IO;

public class ConfigManager : Singleton<ConfigManager> {
    public void OnInit() {
        ItemConfig.OnInit();
        GameConfig.OnInit();
        RoleConfig.OnInit();
        SceneConfig.OnInit();
    }
}