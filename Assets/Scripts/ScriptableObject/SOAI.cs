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
    [Header("==== AI出生信息 ====")]
    [SerializeField] [Tooltip("AI标识")] private string aISign;
    [SerializeField] [Tooltip("AI出生点")] private AIBornInfo aIBornInfo;

    [Header("==== AI战斗相关 ====")]
    [SerializeField] [Tooltip("AI飙血特效")] private string aIBloodSign;

    public string AISign => aISign;
    public AIBornInfo AIBornInfo=> aIBornInfo;
    public string AIBloodSign => aIBloodSign;

}
