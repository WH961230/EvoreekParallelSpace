using System;
using UnityEngine;

[Serializable]
public struct WeaponCreateInfo
{
    public Vector3 weaponBornVec;
    public Quaternion weaponBornQua;
}

[CreateAssetMenu(menuName = "SOWeapon", order = 0)]
public class SOWeapon : ScriptableObject
{
    [Header("==== 武器 ====")]
    [SerializeField] [Tooltip("武器标识")] private string weaponSign;
    [SerializeField] [Tooltip("武器生成点")] private WeaponCreateInfo weaponCreateInfo;

    public string WeaponSign => weaponSign;
    public WeaponCreateInfo WeaponInfo => weaponCreateInfo;
}