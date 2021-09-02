using System;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraController : MonoBehaviour
{
    private Transform Target { set; get; }
    public Camera mainCamera;

    public float aimValue = 0.3f;
    public float defaultValue = -0.5f;

    public float cameraChangeSpeed;
    public bool isAim = false;
    private void Start()
    {
        mainCamera.transform.position = new Vector3(0, 0, defaultValue);
        GameData.GameCamera = this;
    }

    private void Update()
    {
        CameraEvent();
    }

    private void CameraEvent()
    {
        if (!isAim)
        {
            if (Mathf.Abs(mainCamera.transform.localPosition.z - defaultValue) > 0.0001f)
            {
                mainCamera.transform.localPosition = Vector3.Lerp(mainCamera.transform.localPosition, new Vector3(0,0,defaultValue), Time.deltaTime * cameraChangeSpeed);
            }
        }
        else
        {
            if (Mathf.Abs(mainCamera.transform.localPosition.z - aimValue) > 0.0001f)
            {
                mainCamera.transform.localPosition = Vector3.Lerp(mainCamera.transform.localPosition, new Vector3(0,0,aimValue), Time.deltaTime * cameraChangeSpeed);
            }
        }
    }

    private void LateUpdate() {
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
