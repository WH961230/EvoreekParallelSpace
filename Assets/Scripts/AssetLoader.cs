using UnityEngine;

public enum AssetType
{
    Prefab,
    Scriptable,
}

public static class AssetLoader
{
    private const string PrefabsPath = "Prefabs/";
    private const string ScriptablePath = "Configs/";

    public static Object LoadAsset(AssetType type, string name)
    {
        var path = GetLoadAssetPathByType(type);
        return Resources.Load(path + name);
    }

    public static T LoadAsset<T>(string name) where T : Object
    {
        return Resources.Load<T>(name);
    }
    
    private static string GetLoadAssetPathByType(AssetType type) {
        switch (type)
        {
            case AssetType.Prefab:
                return PrefabsPath;
                break;
            case AssetType.Scriptable:
                return ScriptablePath;
                break;
        }

        return "";
    }
}