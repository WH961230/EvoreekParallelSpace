using System;
using UnityEngine;

[Serializable]
public struct PlayerBornInfo
{
    public Vector3 playerBornVec;
    public Quaternion playerBornQua;
}

[CreateAssetMenu(menuName = "SOPlayer", order = 0)]
public class SOPlayer : ScriptableObject
{
    [Header("==== 玩家 ====")]
    [SerializeField] [Tooltip("玩家标识")] private string playerSign;
    [SerializeField] [Tooltip("玩家出生点")] private PlayerBornInfo playerBornInfo;

    public string PlayerSign => playerSign;
    public PlayerBornInfo PlayerInfo => playerBornInfo;
}
