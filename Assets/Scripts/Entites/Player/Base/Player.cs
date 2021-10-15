using UnityEngine;

/// <summary>
/// 玩家基础数据
/// </summary>
public struct PlayerBaseData
{
    public int id;
    public string name;
    public int hp;
    public PlayerController playerController;
}

/// <summary>
/// 玩家
/// </summary>
public class Player : IBaseEntites {
    private GameEngine gameEngine;
    public PlayerBaseData BaseData;

    public GameEngine MyGameEngine {
        get { return gameEngine; }
        set { gameEngine = value; }
    }
    
    public Player(int id, string name, PlayerController pc, int hp)
    { 
        this.BaseData.id = id;
        this.BaseData.name = name;
        this.BaseData.playerController = pc;
        this.BaseData.hp = hp;
        Debug.LogFormat("创建角色 ：name {0} id {1}", name, id);
    }
    public void OnInit()
    {
    }
    public void OnClear()
    {
        var controller = BaseData.playerController;
        if (null != controller)
        {
            controller.OnClear();
        }
    }
}