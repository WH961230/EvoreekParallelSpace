using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour
{
    public string EnvironmentScene;
    public AudioClip BackgroundClip;
    public string AudioMainName;
    private AudioMgr AudioMgr;

    private void Awake()
    {
        MonoMgr.GetInstance().OnInit();
        InputMgr.GetInstance().OnInit();
    }

    void Start()
    {
        var loadAsset = Instantiate(AssetLoader.LoadAsset(AssetType.Prefab, AudioMainName) as GameObject);
        AudioMgr = loadAsset.GetComponent<AudioMgr>();

        SceneManager.LoadScene(EnvironmentScene, LoadSceneMode.Additive);
        Debug.Log($"加载子场景 {EnvironmentScene}");

        if (null != AudioMgr)
        {
            AudioMgr.Play(BackgroundClip);
        }
        else
        {
            Debug.LogError("audioManager not find");
        }
    }
}