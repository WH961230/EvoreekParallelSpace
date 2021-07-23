using System;
using UnityEngine;

public class BaseController : MonoBehaviour {
    void Update() {
        FaceTargetEvent();
    }

    void FaceTargetEvent() {
        var target = GlobalData.globalCamera;
        if (null == target) {
            return;
        }
        transform.LookAt(target.transform);
    }
}
