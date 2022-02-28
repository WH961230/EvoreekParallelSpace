using System.Collections.Generic;
using UnityEngine;

public class InputManager {
    private List<KeyCode> keyCodes;
    private Engine myEngine;

    public void OnInit(Engine engine) {
        myEngine = engine;
        RegisterMessage();
    }

    private void RegisterMessage() {
        // myEngine.MyMessageCenter.RegisterMessage();
    }

    private void UnRegisterMessage() {
        // myEngine.MyMessageCenter.UnRegisterMessage();
    }

    public void OnClear() {
        UnRegisterMessage();
    }

    public void Update() {
        for (int i = 0; i < keyCodes.Count; i++) {
            if (Input.GetKeyDown(keyCodes[i])) {
            }
        }
    }
}