using System;
using UnityEngine;

[Serializable]
public struct PlayerBornInfo
{
    public Vector3 playerBornVec;
    public Quaternion playerBornQua;
}

[CreateAssetMenu(menuName = "SOPlayer", order = 0)]
public class PlayerScriptableObject : ScriptableObjectBase
{
    [Header("==== 玩家出生点信息 ====")]
    [SerializeField] [Tooltip("玩家标识")] private string playerSign;
    [SerializeField] [Tooltip("玩家出生点")] private PlayerBornInfo playerBornInfo;

    [Header("==== 玩家基础参数信息 ====")]
    [SerializeField] [Tooltip("玩家最大血量")] private int maxHp;
    public string PlayerSign => playerSign;
    public PlayerBornInfo PlayerInfo => playerBornInfo;
    public int MaxHp => maxHp;
}
