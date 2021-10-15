using System;
using UnityEngine;

[Serializable]
public class WeaponCreateInfo
{
    public Vector3 weaponBornVec;
    public Quaternion weaponBornQua;
}

[CreateAssetMenu(menuName = "SOWeapon", order = 0)]
public class WeaponScriptableObject : ScriptableObjectBase
{
    [Header("==== 武器生成信息 ====")]
    [SerializeField] [Tooltip("武器标识")] private string weaponSign;
    [SerializeField] [Tooltip("武器生成点")] private WeaponCreateInfo weaponCreateInfo;

    [Header("==== 武器音效 ====")]
    [SerializeField] [Tooltip("武器射击音效")] public AudioClip weaponAttackSound;
    
    [Header("==== 武器参数 ====")]
    [SerializeField] [Tooltip("武器射击速率")] public float weaponAttackRate;
    
    [Header("==== 武器特效 ====")]
    [SerializeField] [Tooltip("武器弹壳飞出特效")] public string weaponBulletFlyOutSign;
    [SerializeField] [Tooltip("武器开火枪口火花特效")] public string weaponShotFireSign;

    public string WeaponSign => weaponSign;
    public WeaponCreateInfo WeaponInfo => weaponCreateInfo;
    public string WeaponBulletFlyOutSign => weaponBulletFlyOutSign;
    public string WeaponShotFireSign => weaponShotFireSign;

}