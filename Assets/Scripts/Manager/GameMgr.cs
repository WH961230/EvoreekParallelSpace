using System.Threading;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour {
    [SerializeField] [Tooltip("SOScene")] private SOScene sceneConfig;
    [SerializeField] [Tooltip("SOAudio")] private SOAudio audioConfig;

    public AudioClip BackgroundClip;
    private AudioSource source;

    private void Awake() {
        MonoMgr.GetInstance().OnInit();
        InputMgr.GetInstance().OnInit();
        PlayerMgr.GetInstance().OnInit();
    }

    void Start() {
        source = GetComponent<AudioSource>();

        SceneManager.LoadScene(sceneConfig.SceneSign, LoadSceneMode.Additive);
        Debug.Log($"加载子场景 {sceneConfig.SceneSign}");

        if (null != source)
        {
            AudioMgr.GetInstance().Play(source, BackgroundClip);
        }
        else
        {
            Debug.LogError("audioManager or source not find");
        }
    }
}