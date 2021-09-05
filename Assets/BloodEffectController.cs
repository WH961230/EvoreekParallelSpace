using UnityEngine;

public class BloodEffectController : MonoBehaviour,IBaseController
{
    public Animation BloodAnimation;

    public void OnInit() {
        BloodAnimation.Play("BloodNumFlyOut");
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
