using UnityEngine;

public class Lobby : MonoBehaviour
{
    public void OnStartGame()
    {
        SceneManager.LoadScene("Battle");
    }
}
