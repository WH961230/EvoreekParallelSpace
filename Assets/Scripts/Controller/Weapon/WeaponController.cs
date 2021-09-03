using UnityEngine;

/// <summary>
/// 武器控制器 - 向 WeaponMgr 注册武器 - 行为
/// </summary>
public class WeaponController : MonoBehaviour, IBaseController
{
	public int weaponId;
	[SerializeField] public string weaponName;
	[Tooltip("子弹发射位置")][SerializeField] Transform bulletShotTran;
	[Tooltip("弹壳飞出特效位置")][SerializeField] Transform bulletFlyOutPointTran;
	[Tooltip("武器类型")][SerializeField] public WeaponType weaponType;
	[Tooltip("子弹类型")][SerializeField] public BulletType bulletType;
	[Tooltip("音频")][SerializeField] public AudioSource audioSource;
	[Tooltip("武器配置")][SerializeField] public SOWeapon weaponSetting;
	
	[Tooltip("武器右手抓取地方")][SerializeField] public Transform weaponRightHandGripTran;
	[Tooltip("武器左手抓取地方")][SerializeField] public Transform weaponLeftHandGripTran;

	private GameObject bulletFlyOutObj;
	public void OnInit()
	{
		InitWeaponFX();
	}

	private void InitWeaponFX()
	{
		bulletFlyOutObj = Instantiate(AssetLoader.LoadAsset(AssetType.Prefab, weaponSetting.WeaponBulletFlyOutSign)) as GameObject;
		bulletFlyOutObj.SetActive(false);
	}

	public void OnUpdate()
	{
	}

	public void OnFixedUpdate()
	{
	}

	public void OnLateUpdate()
	{
	}

	public void OnClear()
	{
		Destroy(this.gameObject);
	}

	/// <summary>
	/// 瞄准事件
	/// </summary>
	public void AimEvent() {
		
	}

	private float nextFireTime;
	/// <summary>
	/// 射击事件
	/// </summary>
	public void ShotEvent()
	{
		var targetVec = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
		RaycastHit hit;
		if (Physics.Raycast(targetVec, out hit, 200, ~(1 << 25)))
		{
			if (!bulletFlyOutObj.gameObject.activeSelf)
			{
				var tran = bulletFlyOutObj.transform;
				tran.position = bulletFlyOutPointTran.position;
				bulletFlyOutObj.gameObject.SetActive(true);
			}
			if (Time.time > nextFireTime)
			{
				var b = Instantiate(AssetLoader.LoadAsset(AssetType.Prefab, ConfigMgr.Instance.bulletConfig.BulletSign)) as GameObject;
				b.transform.position = bulletShotTran.position;
				b.transform.GetComponent<BulletController>().targetTran = hit.point;
				audioSource.PlayOneShot(weaponSetting.weaponAttackSound);
				nextFireTime = Time.time + weaponSetting.weaponAttackRate;
			}
		}
	}

	/// <summary>
	/// 换弹事件
	/// </summary>
	public void ReloadEvent()
	{
		Debug.Log("换弹");
	}
}
