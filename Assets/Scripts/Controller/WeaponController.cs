using UnityEngine;

/// <summary>
/// 武器控制器 - 向 WeaponMgr 注册武器 - 行为
/// </summary>
public class WeaponController : MonoBehaviour, IBaseController
{
	public int weaponId;
	[SerializeField] public string weaponName;
	[Tooltip("子弹预制体")][SerializeField] Transform bulletPrefab;
	[Tooltip("子弹发射位置")][SerializeField] Transform bulletShotTran;

	[Tooltip("武器类型")][SerializeField] public WeaponType weaponType;

	public void OnInit()
	{
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
	/// 射击事件
	/// </summary>
	public void ShotEvent()
	{
		var targetVec = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
		RaycastHit hit;
		if (Physics.Raycast(targetVec, out hit, 200, ~(1 << 25)))
		{
			var bullet = Instantiate(bulletPrefab.gameObject);
			bullet.transform.position = bulletShotTran.position;
			bullet.transform.GetComponent<BulletController>().targetTran = hit.point;
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
