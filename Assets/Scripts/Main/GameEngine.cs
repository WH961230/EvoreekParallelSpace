using System.Collections.Generic;
using Data;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    [SerializeField] private bool openSystemUpdate;
    private readonly List<SystemBase> systems;
    public List<SystemBase> Systems => systems;

    private void Start()
    {
        Init();
        MessageCenter.Instance.Dispatcher(MessageCode.Game_GameStart);
    }

    private void Init()
    {
        1111
    }

    public void RegisterSystem(SystemBase systemBase)
    {
        var system = GetSystem(systemBase);
        if (null == system)
        {
            Debug.Log("注册成功 + " + systemBase.GetType().Name);
            systems.Add(systemBase);
        }
    }

    public void UnRegisterSystem(SystemBase systemBase)
    {
        var system = GetSystem(systemBase);
        if (null != system)
        {
            systems.Remove(systemBase);
        }
    }

    private SystemBase GetSystem(SystemBase systemBase)
    {
        if (!HasSystem(systemBase))
        {
            return null;
        }

        SystemBase ret = null;
        foreach (var system in systems)
        {
            if (system == systemBase)
            {
                ret = system;
                break;
            }
        }

        return ret;
    }

    private bool HasSystem(SystemBase systemBase)
    {
        foreach (var system in systems)
        {
            if (system == systemBase)
            {
                return true;
            }
        }

        return false;
    }

    /*private void MgrInit() {
        ConfigManager.Instance.OnInit(this);
        SceneManager.Instance.OnInit(this);
        // InputMgr.Instance.OnInit(this);
        // PlayerMgr.Instance.OnInit(this);
        AudioManager.Instance.OnInit(this);
        WeaponManager.Instance.OnInit(this);
        BulletManager.Instance.OnInit(this);
        AIManager.Instance.OnInit(this);
        UIManager.Instance.OnInit(this);
    }*/

    private void Update()
    {
        if (openSystemUpdate)
        {
            if (null != systems && systems.Count > 0)
            {
                foreach (var system in systems)
                {
                    system.OnUpdate();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (openSystemUpdate)
        {
            if (null != systems && systems.Count > 0)
            {
                foreach (var system in systems)
                {
                    system.OnFixedUpdate();
                }
            }
        }
    }

    public void GameOver()
    {
        MessageCenter.Instance.Dispatcher(MessageCode.Game_GameOver);
        Clear();
    }

    private void Clear()
    {
        foreach (var system in systems)
        {
            system.OnClear();
            systems.Remove(system);
        }
    }
}