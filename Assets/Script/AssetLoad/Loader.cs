using UnityEngine;
using Object = System.Object;

public class Loader : Singleton<Loader>
{
    //基础配置
    private static readonly string CONFIGPATH = "Configs/SO/";
    private static readonly string TXTPATH = "Configs/Txt/";

    //其他配置
    private static readonly string GAMESETTINGCONFIG = CONFIGPATH + "Global/";
    private static readonly string ROLECONFIG = CONFIGPATH + "Role/";
    private static readonly string WEAPONCONFIG = CONFIGPATH + "Weapon/";
    private static readonly string CAMERACONFIG = CONFIGPATH + "Camera/";

    public Object Load(string path)
    {
        return Resources.Load(path);
    }

    public T LoadGameSettingConfig<T>(string configName) where T : ScriptableObject, new()
    {
        return Resources.Load(GAMESETTINGCONFIG + configName) as T;
    }

    public T LoadRoleConfig<T>(string configName) where T : ScriptableObject, new()
    {
        return Resources.Load(ROLECONFIG + configName) as T;
    }

    public T LoadCameraConfig<T>(string configName) where T : ScriptableObject, new() {
        return Resources.Load(CAMERACONFIG + configName) as T;
    }

    public T LoadWeaponConfig<T>(string configName) where T : ScriptableObject, new()
    {
        return Resources.Load(WEAPONCONFIG + configName) as T;
    }

    public TextAsset LoadTxt(string txtName)
    {
        return Resources.Load(TXTPATH + txtName) as TextAsset;
    }
}