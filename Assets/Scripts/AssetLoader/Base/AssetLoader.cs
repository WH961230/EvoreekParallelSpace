using UnityEngine;

public enum AssetType {
    Prefab,
    Scriptable,
}

public enum AssetInfoType {
    Weapon,
    Role,
    Globle,
    UI,
}

public static class AssetLoader {
    private const string PrefabsPath = "Prefabs/";
    private const string ScriptablePath = "Configs/";

    private const string WeaponPath = "Weapon/";
    private const string RolePath = "Role/";
    private const string GloblePath = "Globle/";
    private const string UIPath = "UI/";

    public static Object LoadAsset(AssetType at, AssetInfoType ait, string name) {
        var p = GetLoadAssetPathByType(at, ait);
        return Resources.Load(p + name);
    }

    public static T LoadAsset<T>(string name) where T : Object {
        return Resources.Load<T>(name);
    }
    
    private static string GetLoadAssetPathByType(AssetType at, AssetInfoType ait) {
        var p = "";
        switch (at) {
            case AssetType.Prefab:
                p += PrefabsPath;
                break;
            case AssetType.Scriptable:
                p += ScriptablePath;
                break;
        }

        p += GetAssetPathByAssetInfoType(ait);
        return p;
    }

    private static string GetAssetPathByAssetInfoType(AssetInfoType ait) {
        switch (ait) {
            case AssetInfoType.Weapon:
                return WeaponPath;
            case AssetInfoType.Role:
                return RolePath;
            case AssetInfoType.Globle:
                return GloblePath;
            case AssetInfoType.UI:
                return UIPath;
        }

        return "";
    }
}