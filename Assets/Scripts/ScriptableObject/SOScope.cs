using System;
using UnityEngine;

[Serializable]
public struct ScopeCreateInfo
{
    public Vector3 scopeBornVec;
    public Quaternion scopeBornQua;
}

[CreateAssetMenu(menuName = "SOScope", order = 0)]
public class SOScope : ScriptableObject
{
    [Header("==== Scope ====")]
    [SerializeField] [Tooltip("标识")] private string scopeSign;
    [SerializeField] [Tooltip("生成点")] private ScopeCreateInfo scopeCreateInfo;

    public string ScopeSign => scopeSign;
    public ScopeCreateInfo ScopeInfo => scopeCreateInfo;
}