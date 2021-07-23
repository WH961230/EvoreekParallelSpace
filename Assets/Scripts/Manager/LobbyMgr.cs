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
        Debug.Log("开始游戏");
        SceneManager.LoadScene(MainSceneName);
        Debug.Log($"加载场景 {MainSceneName}");
    }
}