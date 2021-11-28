using UnityEngine;

public class GameEngine : MonoBehaviour
{
    private GameMaster gameMaster;
    void Start()
    {
        gameMaster = new GameMaster(this);
        gameMaster.Start();
    }

    void Update()
    {
        gameMaster?.Update();
    }

    private void FixedUpdate()
    {
        gameMaster?.FixedUpdate();
    }

    private void LateUpdate()
    {
        gameMaster?.LateUpdate();
    }
}
