using UnityEngine;

public class CameraControl : MonoBehaviour
{
    void Start() {
    }

    [SerializeField] private float xRotate = 0.0f;
    [SerializeField] private float yRotate = 0.0f;
    [SerializeField] private float xSpeed = 0.0f;
    [SerializeField] private float ySpeed = 0.0f;
    [SerializeField] private float bodyMoveSpeed = 1f;
    [SerializeField] private float headMaxAngleX = 120f;
    [SerializeField] private float headMaxAngleY = 60f;
    [SerializeField] private float bodyMoveAngleX = 60f;
    [SerializeField] private Transform headRoot;
    [SerializeField] private Transform bodyRoot;
    [SerializeField] private AnimationCurve animatorCurve;

    private Vector3 targetEulerAngle;
    private Vector3 targetVec;
    private float targetEulerAngleY;
    void LateUpdate() {
        var eulerAngles = bodyRoot.eulerAngles;

        xRotate -= Input.GetAxis("Mouse Y") * xSpeed;
        yRotate += Input.GetAxis("Mouse X") * ySpeed;

        xRotate = Mathf.Clamp(xRotate, -headMaxAngleY, headMaxAngleY);
        yRotate = Mathf.Clamp(yRotate, -headMaxAngleX + eulerAngles.y, headMaxAngleX + eulerAngles.y);

        transform.localRotation = Quaternion.Euler(xRotate, yRotate, 0);
        headRoot.transform.localRotation = Quaternion.Euler(xRotate, yRotate, 0);

        var r1 = Vector3.ProjectOnPlane(bodyRoot.forward, Vector3.up);
        var r2 = Vector3.ProjectOnPlane(headRoot.forward, Vector3.up);

        var angleOff = Vector3.Angle(r1, r2);
        Debug.Log(angleOff);

        if (angleOff >= bodyMoveAngleX) {
            targetVec = r2;
        }

        bodyRoot.forward = Vector3.Lerp(bodyRoot.forward, targetVec, bodyMoveSpeed * Time.deltaTime);
    }
}
