using UnityEngine.SceneManagement;

public class SceneManager
{
    public static void LoadSceneByMode(string name, LoadSceneMode mode)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name, mode);
    }
}