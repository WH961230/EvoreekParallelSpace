using Data;
using UnityEngine;

public class UIMgr : Singleton<UIMgr>, IBaseMgr {
    private CrossController crossController;
    public void OnInit(GameEngine gameEngine) {
        gameEngine.managers.Add(this);
        MessageCenter.Instance.Register(MessageCode.Game_GameStart, InitController);
    }

    private void InitController() {
        crossController = GameObject.FindObjectOfType<CrossController>();
        crossController.OnInit();
    }
    
    public void OnUpdate() {
        if (null != crossController) {
            crossController.OnUpdate();
        }
    }

    public void OnClear() {
    }
}
