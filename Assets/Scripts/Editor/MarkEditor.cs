using UnityEditor;
using UnityEngine;

public class MarkEditor
{
    [MenuItem("工具/保存玩家生成位置信息", priority = 0)]
    public static void SavePlayerInfo()
    {
        UnityEngine.Debug.Log("玩家位置保存");
    }
}
