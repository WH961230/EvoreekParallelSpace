using Data;
using UnityEngine;

public class PlayerSystem : SystemBase {
    private PlayerData playerData;
    private InputData inputData;
    public override void OnInit(GameEngine gameEngine) {
        base.OnInit(gameEngine);
        MessageCenter.Instance.Register(MessageCode.Game_GameStart, StartGameAction);
        MessageCenter.Instance.Register(MessageCode.Game_GameOver, OverGameAction);
        MessageCenter.Instance.Register<int>(MessageCode.Play_Attack, Attack);
        MessageCenter.Instance.Register<int[]>(MessageCode.Play_Dead, Dead);
        MessageCenter.Instance.Register<InputData>(MessageCode.Game_InputData, GetInput);
    }

    public override void InitData() {
        base.InitData();
        playerData = new PlayerData();
    }

    private void StartGameAction() {
        playerData.InitStartPlayer();
    }

    private void OverGameAction() {
    }

    private void GetInput(InputData data) {
        inputData.mouseY = data.mouseY;
        inputData.mouseX = data.mouseX;
        inputData.horizontal = data.horizontal;
        inputData.vertical = data.vertical;
    }

    private void Attack(int playerId) {
        Debug.Log("PlayerId : " + playerId);
    }

    private void Dead(int[] playerIds) {
        playerData.ClearPlayer(playerIds);
    }

    public override void OnUpdate() {
        base.OnUpdate();
    }

    public override void OnClear() {
        base.OnClear();
    }
}