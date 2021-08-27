using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyMgr : MonoBehaviour
{
    public Button StartGameBtn;
    public string MainSceneName;

    private void Start()
    {
        StartGameBtn.onClick.AddListener(OnStartGame);
    }

    private void OnStartGame()
    {
        SceneManager.LoadScene(MainSceneName);
    }
}