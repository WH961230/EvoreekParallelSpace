using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface ISystemBase
{
    void Init(GameMaster gameMaster);
    void Update();
    void FixedUpdate();
    void LateUpdate();
    void Clear();
}

public class SystemBase : ISystemBase
{
    private GameMaster myGameMaster;
    private List<IManagerBase> loop = new List<IManagerBase>();

    private void Register(IManagerBase managerBase)
    {
        Debug.Log("IManagerBase 注册成功");
        loop.Add(managerBase);
    }

    private void UnRegister(IManagerBase managerBase)
    {
        if (loop.Contains(managerBase))
        {
            Debug.Log("IManagerBase 移除成功");
            loop.Remove(managerBase);
        }
    }

    public virtual void Init(GameMaster gameMaster)
    {
        myGameMaster = gameMaster;
        myGameMaster.Register(this);
    }

    public virtual void Update()
    {
        if (loop.Count > 0)
        {
            foreach (var l in loop)
            {
                l.Update();
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (loop.Count > 0)
        {
            foreach (var l in loop)
            {
                l.FixedUpdate();
            }
        }
    }

    public virtual void LateUpdate()
    {
        if (loop.Count > 0)
        {
            foreach (var l in loop)
            {
                l.LateUpdate();
            }
        }
    }

    public virtual void Clear()
    {
        if (loop.Count > 0)
        {
            foreach (var l in loop)
            {
                l.Clear();
            }
        }
        myGameMaster.UnRegister(this);
    }
}