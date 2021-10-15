using System.Collections.Generic;
using Data;
using UnityEngine;

public enum SystemType {
    None = 0,
    PlayerSystem = 1,
    InputSystem = 2,
}

public class GameEngine : MonoBehaviour {
    [SerializeField] private List<SystemType> systemTypeSet;
    [SerializeField] private bool openSystemUpdate;

    private readonly List<SystemBase> systems = new List<SystemBase>();
    public List<SystemBase> Systems => systems;

    private void Start() {
        foreach (var systemType in systemTypeSet) {
            if (systemType == 0) {
                return;
            }

            SystemBase systemBase = null;
            switch (systemType) {
                case SystemType.PlayerSystem: 
                    systemBase = new PlayerSystem();
                    break;
                case SystemType.InputSystem: 
                    systemBase = new InputSystem();
                    break;
            }

            if (null != systemBase) {
                systemBase.OnInit(this);
                systems.Add(systemBase);
            } else {
                Debug.LogError("Error with type : " + systemType);
            }
        }
        MessageCenter.Instance.Dispatcher(MessageCode.Game_GameStart);
    }

    private void MgrInit() {
        ConfigManager.Instance.OnInit(this);
        SceneManager.Instance.OnInit(this);
        // InputMgr.Instance.OnInit(this);
        // PlayerMgr.Instance.OnInit(this);
        AudioManager.Instance.OnInit(this);
        WeaponManager.Instance.OnInit(this);
        BulletManager.Instance.OnInit(this);
        AIManager.Instance.OnInit(this);
        UIManager.Instance.OnInit(this);
    }

    private void Update() {
        if (openSystemUpdate) {
            if (null != systems && systems.Count > 0) {
                foreach (var system in systems) {
                    system.OnUpdate();
                }
            }
        }
    }

    public void GameOver() {
        MessageCenter.Instance.Dispatcher(MessageCode.Game_GameOver);
        Clear();
    }

    private void Clear() {
        foreach (var system in systems) {
            system.OnClear();
            systems.Remove(system);
        }
    }
}