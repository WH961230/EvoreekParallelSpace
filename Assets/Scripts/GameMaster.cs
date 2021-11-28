using System.Collections.Generic;
using UnityEngine;

interface IGameBase
{
    void Start();
    void Update();
    void FixedUpdate();
    void LateUpdate();
    void Clear();
}

public class GameBase : IGameBase
{
    private List<ISystemBase> loop = new List<ISystemBase>();

    public void Register(ISystemBase systemBase)
    {
        Debug.Log("ISystemBase 注册成功");
        loop.Add(systemBase);
    }

    public void UnRegister(ISystemBase systemBase)
    {
        if (loop.Contains(systemBase))
        {
            Debug.Log("ISystemBase 移除成功");
            loop.Remove(systemBase);
        }
    }

    public virtual void Start()
    {
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
    }
}

public class GameMaster : GameBase
{
    private GameEngine gameEngine;
    public GameMaster(GameEngine gameEngine)
    {
        this.gameEngine = gameEngine;
    }

    public override void Start()
    {
        base.Start();
        Debug.Log("Init GameMaster.");
        new PlayerSystem().Init(this);
    }
}