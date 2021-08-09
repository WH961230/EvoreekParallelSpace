using System;
using UnityEngine;

namespace Controller {
    public class CameraFrontController : MonoBehaviour {
        private Transform Target { set; get; }
        private void Start() {
            GameData.GameFrontCamera = this;
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
}