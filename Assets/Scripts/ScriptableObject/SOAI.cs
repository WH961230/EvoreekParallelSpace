using System;
using UnityEngine;

[Serializable]
public struct AIBornInfo
{
    public Vector3 AIBornVec;
    public Quaternion AIBornQua;
}

[CreateAssetMenu(menuName = "SOAI", order = 0)]
public class SOAI : ScriptableObject
{
    [Header("==== AI ====")]
    [SerializeField] [Tooltip("AI标识")] private string aISign;
    [SerializeField] [Tooltip("AI出生点")] private AIBornInfo aIBornInfo;

    public string AISign => aISign;
    public AIBornInfo AIBornInfo=> aIBornInfo;
}
