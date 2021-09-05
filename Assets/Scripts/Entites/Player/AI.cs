using UnityEngine;

/// <summary>
/// AI基础数据
/// </summary>
public struct AIBaseData
{
    public int id;
    public string name;
    public int hp;
    public AIController AIController;
}

/// <summary>
/// 机器人
/// </summary>
public class AI
{
    public AIBaseData BaseData;
    
    public AI(int id, string name, AIController ac, int hp)
    { 
        this.BaseData.id = id;
        this.BaseData.name = name;
        this.BaseData.AIController = ac;
        this.BaseData.hp = hp;
        Debug.LogFormat("创建AI ：name {0} id {1}", name, id);
    }
}