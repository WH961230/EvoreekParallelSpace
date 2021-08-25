using UnityEngine;

/// <summary>
/// 玩家类型
/// </summary>
public enum PlayerType
{
    AI,
    LocalPlayer,
    OtherPlayer
}

/// <summary>
/// 玩家基础数据
/// </summary>
public struct PlayerBaseData
{
    public int Id;
    public string Name;
    public PlayerType Type;
    public PlayerController PlayerController;
}

/// <summary>
/// 玩家
/// </summary>
public class Player : IBaseEntites
{
    public PlayerBaseData BaseData;

    public Player(int id, string name, PlayerType type, PlayerController pc)
    { 
        this.BaseData.Id = id;
        this.BaseData.Name = name;
        this.BaseData.Type = type;
        this.BaseData.PlayerController = pc;
        Debug.LogFormat("创建角色 ：name {0} id {1}", name, id);
    }

    public void OnInit()
    {
        
    }

    public void OnClear()
    {
    }
}