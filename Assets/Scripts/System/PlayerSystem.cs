using Data;

public class PlayerSystem : SystemBase {
    private PlayerData playerData;
    public override void OnInit(GameEngine gameEngine) {
        base.OnInit(gameEngine);
        MessageCenter.Instance.Register(MessageCode.Game_GameStart, StartGameAction);
        MessageCenter.Instance.Register(MessageCode.Game_GameOver, OverGameAction);
        MessageCenter.Instance.Register<int>(MessageCode.Play_Dead, PlayerDead);
    }

    public override void InitData() {
        base.InitData();
        playerData = new PlayerData();
    }

    private void StartGameAction() {
    }

    private void OverGameAction() {
    }

    private void PlayerDead(int[] playerIds) {
        if (playerIds.Length > 0) {
            foreach (var playerId in playerIds) {
                playerData.ClearPlayer();
            }
        }
    }

    public override void OnUpdate() {
        base.OnUpdate();
    }

    public override void OnClear() {
        base.OnClear();
    }
}