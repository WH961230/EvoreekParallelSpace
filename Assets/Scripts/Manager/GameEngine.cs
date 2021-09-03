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
        GameModeInit();
    }

    /// <summary>
    /// 管理器初始化
    /// </summary>
    private void MgrInit() {
        ConfigMgr.Instance.OnInit(this);
        SceneMgr.Instance.OnInit(this);
        InputMgr.Instance.OnInit(this);
        PlayerMgr.Instance.OnInit(this);
        AudioMgr.Instance.OnInit(this);
        WeaponMgr.Instance.OnInit(this);
        AIMgr.Instance.OnInit(this);
        UIMgr.Instance.OnInit(this);
    }

    /// <summary>
    /// 游戏模式初始化
    /// </summary>
    private void GameModeInit() {
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

    /// <summary>
    /// 游戏结束
    /// </summary>
    public void GameOver() {
        MessageCenter.Instance.Dispatcher(MessageCode.Game_GameOver);
        Clear();
    }

    #endregion
    
    #region Clear

    void Clear()
    {
        foreach (var m in managers)
        {
            m.OnClear();
        }
    }

    #endregion
}