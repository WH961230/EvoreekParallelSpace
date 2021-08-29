using UnityEngine;

/// <summary>
/// 玩家基础数据
/// </summary>
public struct PlayerBaseData
{
    public int id;
    public string name;
    public PlayerController playerController;
}

/// <summary>
/// 玩家
/// </summary>
public class Player : IBaseEntites
{
    public PlayerBaseData BaseData;
    public Player(int id, string name, PlayerController pc)
    { 
        this.BaseData.id = id;
        this.BaseData.name = name;
        this.BaseData.playerController = pc;
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