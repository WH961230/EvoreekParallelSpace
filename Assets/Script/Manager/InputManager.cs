using System.Collections.Generic;
using UnityEngine;

public struct AxisData {
    public float Horizontal;
    public float Vertical;
    public float MouseX;
    public float MouseY;
}

public class InputManager {
    private List<KeyCode> keyCodes = new List<KeyCode>() {
        KeyCode.A,
        KeyCode.W,
        KeyCode.S,
        KeyCode.D
    };

    public void OnInit(Engine engine) {
        engine.AddUpdateAction(OnUpdate);
        engine.AddQuitAction(OnClear);
    }

    public void OnClear() {
    }

    private void OnUpdate() {
        OnKeyCodeEvent();
        OnAxisEvent();
    }

    private void OnKeyCodeEvent() {
        for (var i = 0; i < keyCodes.Count; i++) {
            var code = keyCodes[i];
            if (Input.GetKeyDown(code)) {
                MessageCenter.DispatcherMessage(MessageCode.OnKeyCodeDown, code);
            }

            if (Input.GetKey(code)) {
                MessageCenter.DispatcherMessage(MessageCode.OnKeyCode, code);
            }
        }
    }

    private void OnAxisEvent() {
        MessageCenter.DispatcherMessage(MessageCode.OnAxis, new AxisData() {
            Horizontal = Input.GetAxis("Horizontal"),
            Vertical = Input.GetAxis("Vertical"),
            MouseX = Input.GetAxis("Mouse X"),
            MouseY = Input.GetAxis("Mouse Y"),
        });
    }
}