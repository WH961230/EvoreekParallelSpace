using System.Collections.Generic;
using Data;
using Manager;
using UnityEngine;

public class GameEngine : MonoBehaviour {
    public List<IBaseMgr> managers;

    #region Awake

    private void Awake() {
        managers = new List<IBaseMgr>();
    }

    #endregion

    #region Start

    void Start() {
        MgrInit();
        GameModeStart();
    }

    private void MgrInit() {
        ConfigMgr.Instance.OnInit(this);
        SceneMgr.Instance.OnInit(this);
        InputMgr.Instance.OnInit(this);
        PlayerMgr.Instance.OnInit(this);
        AudioMgr.Instance.OnInit(this);
    }

    private void GameModeStart() {
        MessageCenter.Instance.Dispatcher(MessageCode.Game_GameStart);
    }

    #endregion

    #region Update

    private void Update() {
        if (null != managers && managers.Count > 0) {
            foreach (var m in managers) {
                m.OnUpdate();
            }
        }
    }

    #endregion

    #region GameOver

    public void GameOver() {
        MessageCenter.Instance.Dispatcher(MessageCode.Game_GameOver);
    }

    #endregion

}