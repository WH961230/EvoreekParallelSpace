using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform Target { set; get; }

    private void Start() 
    {
        GameData.GameCamera = this;
    }

    private void Update()
    {
        TargetMoveEvent();
    }

    public void SetTarget(Transform target) {
        Target = target;
    }

    public Transform GetTarget() {
        return Target;
    }

    private void TargetMoveEvent()
    {
        if (null == Target)
        {
            return;
        }

        var myTransform = transform;
        myTransform.position = Target.position;
        myTransform.rotation = Target.rotation;
    }
}
