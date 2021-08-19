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

    public void OnStartGame()
    {
        SceneManager.LoadScene(MainSceneName);
    }
}