using Data;
using UnityEngine;

public class PlayerSystem : SystemBase
{
    private PlayerData playerData;

    public override void OnInit(GameEngine gameEngine)
    {
        playerData = new PlayerData();
        MyData = playerData;
        MessageCenter.Instance.Register(MessageCode.Game_GameStart, MsgGameStart);
        MessageCenter.Instance.Register(MessageCode.Game_GameOver, MsgGameOver);
        MessageCenter.Instance.Register<int>(MessageCode.Play_Attack, MsgAttack);
        MessageCenter.Instance.Register<int[]>(MessageCode.Play_Dead, MsgDead);
        MessageCenter.Instance.Register<InputData>(MessageCode.Game_InputData, MsgInput);
    }

    private void MsgGameStart()
    {
        playerData.InitPlayer();
    }

    private void MsgGameOver()
    {
    }

    private void MsgInput(InputData data)
    {
    }

    private void MsgAttack(int playerId)
    {
        Debug.Log("PlayerId : " + playerId);
    }

    private void MsgDead(int[] playerIds)
    {
        playerData.ClearPlayers(playerIds);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        playerData.OnUpdate();
    }

    public override void OnClear()
    {
        base.OnClear();
    }
}