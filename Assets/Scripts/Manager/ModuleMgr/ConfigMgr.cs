using UnityEngine;

public class ConfigMgr : Singleton<ConfigMgr> , IBaseMgr{
    [SerializeField] [Tooltip("SOGameSetting")] public SOGameSetting gameSettingConfig;
    [SerializeField] [Tooltip("SOScene")] public SOScene sceneConfig;
    [SerializeField] [Tooltip("SOAudio")] public SOAudio audioConfig;
    [SerializeField] [Tooltip("SOPlayer")] public SOPlayer playerConfig;
    [SerializeField] [Tooltip("SOAI")] public SOAI AIConfig;
    [SerializeField] [Tooltip("SOBullet")] public SOBullet bulletConfig;
    [SerializeField] [Tooltip("SOWeapon")] public SOWeapon weaponConfig;

    public void OnInit(GameEngine engine) {
        engine.managers.Add(this);

        playerConfig = (SOPlayer) AssetLoader.LoadAsset(AssetType.Scriptable, "SOPlayer");
        AIConfig = (SOAI) AssetLoader.LoadAsset(AssetType.Scriptable, "SOAI");
        gameSettingConfig = (SOGameSetting) AssetLoader.LoadAsset(AssetType.Scriptable, "SOGameSetting");
        audioConfig = (SOAudio) AssetLoader.LoadAsset(AssetType.Scriptable, "SOAudio");
        sceneConfig = (SOScene)AssetLoader.LoadAsset(AssetType.Scriptable, "SOScene");
        bulletConfig = (SOBullet)AssetLoader.LoadAsset(AssetType.Scriptable, "SOBullet");
        weaponConfig = (SOWeapon) AssetLoader.LoadAsset(AssetType.Scriptable, "SOWeapon");
    }

    public void OnUpdate() {
    }

    public void OnClear() {
    }
}
