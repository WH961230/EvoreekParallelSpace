using UnityEngine;

public class BulletFlyOutController : MonoBehaviour, IBaseController {
    public bool IsStop;
    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnInit() {
    }

    public void OnUpdate() {
        if (IsStop) {
            Hide();
        }
    }

    public void OnFixedUpdate() {
    }

    public void OnLateUpdate() {
    }

    public void OnClear() {
    }
}
