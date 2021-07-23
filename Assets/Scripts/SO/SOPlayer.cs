using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SOPlayer", order = 0)]
public class SOPlayer : ScriptableObject
{
    [SerializeField] [Tooltip("玩家标识")] private string playerSign;
    [SerializeField] [Tooltip("玩家出生点")] private Transform playerBornTran;

    public string PlayerSign => playerSign;
    public Transform PlayerBornTran => playerBornTran;
}
