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
    [Header("==== 武器生成信息 ====")]
    [SerializeField] [Tooltip("武器标识")] private string weaponSign;
    [SerializeField] [Tooltip("武器生成点")] private WeaponCreateInfo weaponCreateInfo;


    [Header("==== 武器音效 ====")]
    [SerializeField] [Tooltip("武器射击音效")] public AudioClip weaponAttackSound;
    
    [SerializeField] [Tooltip("武器射击速率")] public float weaponAttackRate;

    public string WeaponSign => weaponSign;
    public WeaponCreateInfo WeaponInfo => weaponCreateInfo;
}