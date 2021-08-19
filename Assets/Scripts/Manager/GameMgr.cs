using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour {
    [SerializeField] [Tooltip("SOScene")] private SOScene sceneConfig;
    [SerializeField] [Tooltip("SOAudio")] private SOAudio audioConfig;

    public bool isOpenBackgroundMusic = false;
    public AudioClip BackgroundClip;
    private AudioSource source;
    
    // 组件
    [SerializeField] [Tooltip("InputMgr")] private InputMgr inputMgr;

    private void Awake() {
        inputMgr.OnInit();
        MonoMgr.Instance.OnInit();
        PlayerMgr.Instance.OnInit();
    }

    void Start() {
        source = GetComponent<AudioSource>();

        SceneManager.LoadScene(sceneConfig.SceneSign, LoadSceneMode.Additive);
        Debug.Log($"加载子场景 {sceneConfig.SceneSign}");

        if (null != source)
        {
            if (isOpenBackgroundMusic == false) return;
            AudioMgr.Instance.Play(source, BackgroundClip);
        }
        else
        {
            Debug.LogError("audioManager or source not find");
        }
    }

    void Update()
    {
        MessageCenter.Instance.EventTrigger(MessageCenter.Instance.MGR_UPDATE);//输入
        MessageCenter.Instance.EventTrigger(MessageCenter.Instance.CONTROLLER_UPDATE);
    }

    private void FixedUpdate()
    {
        MessageCenter.Instance.EventTrigger(MessageCenter.Instance.MGR_FIXEDUPDATE);//输入
        MessageCenter.Instance.EventTrigger(MessageCenter.Instance.CONTROLLER_FIXEDUPDATE);//输入
    }

    private void LateUpdate()
    {
        MessageCenter.Instance.EventTrigger(MessageCenter.Instance.MGR_LATEUPDATE);//输入
        MessageCenter.Instance.EventTrigger(MessageCenter.Instance.CONTROLLER_LATEUPDATE);//输入
    }
}