using UnityEngine;

public class Instance : MonoBehaviour
{
    [SerializeField] private string sceneName;
    void Start()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
