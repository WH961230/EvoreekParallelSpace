using UnityEngine;

public class ConfigMgr : Singleton<ConfigMgr> , IBaseMgr{
    [SerializeField] [Tooltip("SOGameSetting")] public SOGameSetting gameSettingConfig;
    [SerializeField] [Tooltip("SOScene")] public SOScene sceneConfig;
    [SerializeField] [Tooltip("SOAudio")] public SOAudio audioConfig;
    [SerializeField] [Tooltip("SOPlayer")] public SOPlayer playerConfig;
    [SerializeField] [Tooltip("SOAI")] public SOAI AIConfig;
    [SerializeField] [Tooltip("SOBullet")] public SOBullet bulletConfig;
    [SerializeField] [Tooltip("SOWeapon")] public SOWeapon weaponConfig;
    [SerializeField] [Tooltip("SOUI")] public SOUI uIConfig;

    public void OnInit(GameEngine engine) {
        engine.managers.Add(this);

        playerConfig = (SOPlayer) AssetLoader.LoadAsset(AssetType.Scriptable, AssetInfoType.Role, "SOPlayer");
        AIConfig = (SOAI) AssetLoader.LoadAsset(AssetType.Scriptable, AssetInfoType.Role,  "SOAI");
        gameSettingConfig = (SOGameSetting) AssetLoader.LoadAsset(AssetType.Scriptable, AssetInfoType.Globle, "SOGameSetting");
        audioConfig = (SOAudio) AssetLoader.LoadAsset(AssetType.Scriptable, AssetInfoType.Globle, "SOAudio");
        sceneConfig = (SOScene)AssetLoader.LoadAsset(AssetType.Scriptable, AssetInfoType.Globle, "SOScene");
        bulletConfig = (SOBullet)AssetLoader.LoadAsset(AssetType.Scriptable, AssetInfoType.Weapon, "SOBullet");
        weaponConfig = (SOWeapon) AssetLoader.LoadAsset(AssetType.Scriptable, AssetInfoType.Weapon, "M4");
        uIConfig = (SOUI) AssetLoader.LoadAsset(AssetType.Scriptable, AssetInfoType.UI, "SOUI");
    }

    public void OnUpdate() {
    }

    public void OnClear() {
    }
}
