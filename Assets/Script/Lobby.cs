using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    public void OnStartGame()
    {
        SceneManager.LoadScene("Battle", LoadSceneMode.Single);
    }
}
