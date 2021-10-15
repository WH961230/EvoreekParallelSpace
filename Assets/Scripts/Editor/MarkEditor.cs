using UnityEditor;
using UnityEngine;

public class MarkEditor
{
    [MenuItem("工具/保存玩家生成位置信息", priority = 0)]
    public static void SavePlayerInfo()
    {
        Debug.Log("玩家位置保存");
    }
    
    [MenuItem("工具/武器生成初始位置保存", priority = 0)]
    public static void SaveWeaponBornInfoToConfig() {
        if (Selection.objects.Length <= 0) {
            Debug.Log("武器生成初始位置保存失败 -> 未选中物体");
            return;
        }
        var t = Selection.objects[0] as GameObject;
        var o = AssetLoader.LoadAsset(AssetType.Scriptable, AssetInfoType.Weapon, "M4") as WeaponScriptableObject;
        o.WeaponInfo.weaponBornVec = t.transform.position;
        o.WeaponInfo.weaponBornQua = t.transform.rotation;
        Debug.Log("武器生成初始位置保存成功");
    }
}
