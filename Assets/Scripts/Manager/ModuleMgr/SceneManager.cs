using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : Singleton<SceneManager>, IBaseManager {
    public void OnInit(GameEngine engine) {
        engine.managers.Add(this);
        LoadScene(ConfigManager.Instance.sceneConfig.SceneSign, LoadSceneMode.Additive);
    }

    private void LoadScene(string sceneSign, LoadSceneMode mode) {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneSign, mode);
        if (mode == LoadSceneMode.Additive) {
            Debug.Log($"加载子场景 {ConfigManager.Instance.sceneConfig.SceneSign}");
        } else {
            Debug.Log($"切换场景 {ConfigManager.Instance.sceneConfig.SceneSign}");
        }
    }

    public void OnUpdate() {
    }

    public void OnClear() {
    }
}