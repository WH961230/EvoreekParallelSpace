using UnityEngine;

public class WeaponShotFireController : MonoBehaviour, IBaseController
{
    public void OnEnable() {
        Invoke("Hide", 0.5f);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

    public void OnInit() {
    }

    public void OnUpdate() {
    }

    public void OnFixedUpdate() {
    }

    public void OnLateUpdate() {
    }

    public void OnClear() {
    }
}
