using Data;
using Unity.Mathematics;
using UnityEngine;

/// <summary>
/// 武器控制器 - 向 WeaponMgr 注册武器 - 行为
/// </summary>
public class WeaponController : MonoBehaviour, IBaseController
{
    public int weaponId;
    [SerializeField] public string weaponName;
    [Tooltip("子弹发射位置")] [SerializeField] Transform bulletShotTran;
    [Tooltip("弹壳飞出特效位置")] [SerializeField] private Transform bulletFlyOutPointTran;
    [Tooltip("武器枪口特效位置")] [SerializeField] private Transform weaponShotFireTran;
    [Tooltip("武器类型")] [SerializeField] public WeaponType weaponType;
    [Tooltip("子弹类型")] [SerializeField] public BulletType bulletType;
    [Tooltip("音频")] [SerializeField] public AudioSource audioSource;
    [Tooltip("武器配置")] [SerializeField] public WeaponScriptableObject setting;

    [Tooltip("武器右手抓取地方")] [SerializeField] public Transform weaponRightHandGripTran;
    [Tooltip("武器左手抓取地方")] [SerializeField] public Transform weaponLeftHandGripTran;
    private PlayerOperateWin pow;
    private GameObject bulletFlyOutObj;
    private GameObject weaponShotFireObj;
    private GameObject weaponDecalObj;
    private BulletFlyOutController bulletFlyOutController;
    // private WeaponShotFireController weaponShotFireController;
    public Transform weaponTempParent;
    private bool isShoting = false;
    private float nextFireTime;

    public void OnInit() {
        pow = FindObjectOfType<PlayerOperateWin>();
        MessageCenter.Instance.Register<int>(MessageCode.Weapon_Shot, Shot);
        MessageCenter.Instance.Register(MessageCode.Weapon_Reload, Reload);
    }

    public void SetWeaponTempParent(Transform tran) {
        tran.SetParent(weaponTempParent);
    }

    public void OnUpdate() {
        if (null != bulletFlyOutController) {
            var bc = bulletFlyOutController;
            bc.OnUpdate();
            if (isShoting) {
                bc.IsStop = true;
            }
        }

        // if (null != weaponShotFireController) {
        //     var w = weaponShotFireController;
        //     w.OnUpdate();
        // }
    }

    public void OnFixedUpdate() {
    }

    public void OnLateUpdate() {
    }

    public void OnClear() {
        Destroy(this.gameObject);
    }

    /// <summary>
    /// 瞄准事件
    /// </summary>
    public void AimEvent() {
    }

    /// <summary>
    /// 射击事件
    /// </summary>
    private void Shot(int playerId) {
        var target = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        if (Physics.Raycast(target, out hit, 200, ~(1 << 25))) {
            if (Time.time > nextFireTime) {
                var num = WeaponBulletHandle.Instance.GetWeaponBulletNum(weaponId);
                if (num <= 0) {
                    MessageCenter.Instance.Dispatcher(MessageCode.Tip_BulletNull);
                    MessageCenter.Instance.Dispatcher(MessageCode.Weapon_Reload);
                    return;
                }

                //BoxTool.CreateShape("target", PrimitiveType.Sphere, hit.point, Color.green, 5);
                WeaponBulletHandle.Instance.WeaponShotBullet(weaponId, bulletShotTran.position, bulletShotTran.rotation, hit.point);
                
                // weaponDecalObj = Instantiate(AssetLoader.LoadAsset(AssetType.Prefab, AssetInfoType.Weapon, weaponSetting.weaponDecalSign)) as GameObject;
                var t2 = weaponDecalObj.transform;
                t2.position = hit.point;
                t2.LookAt(GameData.LockPlayer.BaseData.playerController.characterController.transform.position);

                //射击火花
                weaponShotFireObj = Instantiate(AssetLoader.LoadAsset(AssetType.Prefab, AssetInfoType.Weapon, setting.weaponShotFireSign)) as GameObject;
                SetWeaponTempParent(weaponShotFireObj.transform);
                
                var t1 = weaponShotFireObj.transform;
                t1.position = weaponShotFireTran.position;
                t1.rotation = weaponShotFireTran.rotation;

                //血量飚出
                // var o = Instantiate(AssetLoader.LoadAsset(AssetType.Prefab, AssetInfoType.UI, ConfigMgr.Instance.uIConfig.BloodNumFlyOutSign)) as GameObject;
                // o.transform.SetParent(pow.transform);
                // var t2 = o.transform;
                // t2.localPosition = Vector3.zero;
                // t2.localRotation = quaternion.identity;
                // pow.BloodEffectController = o.GetComponent<BloodEffectController>();
                // pow.BloodEffectController.OnInit();
                
                audioSource.PlayOneShot(setting.weaponAttackSound);
                nextFireTime = Time.time + setting.weaponAttackRate;
            }
        }
    }

    /// <summary>
    /// 换弹事件
    /// </summary>
    private void Reload()
    {
        Debug.Log("换弹");
        WeaponBulletHandle.Instance.WeaponAddBullet(weaponId, 5);
    }
}