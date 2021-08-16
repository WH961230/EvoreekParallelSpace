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

    /*#region Action

    public void AddActionEvent(Action action)
    {
        if (actions.Count == 0 || action == null) return;
        if (!actions.Contains(action))
        {
            actions.Add(action);
        }
    }

    public void RemoveActionEvent(Action action)
    {
        if (actions.Count == 0 || action == null) return;
        if (actions.Contains(action))
        {
            actions.Remove(action);
        }
    }

    public bool HasAction(Action action)
    {
        if (actions.Count == 0 || action == null) return false;
        if (actions.Contains(action))
        {
            return true;
        }
        return false;
    }

    #endregion*/


    void Update()
    {
        EventMgr.Instance.EventTrigger(EventMgr.Instance.MGR_UPDATE);//输入
        EventMgr.Instance.EventTrigger(EventMgr.Instance.CONTROLLER_UPDATE);
    }

    private void FixedUpdate()
    {
        EventMgr.Instance.EventTrigger(EventMgr.Instance.MGR_FIXEDUPDATE);//输入
        EventMgr.Instance.EventTrigger(EventMgr.Instance.CONTROLLER_FIXEDUPDATE);//输入
    }

    private void LateUpdate()
    {
        EventMgr.Instance.EventTrigger(EventMgr.Instance.MGR_LATEUPDATE);//输入
        EventMgr.Instance.EventTrigger(EventMgr.Instance.CONTROLLER_LATEUPDATE);//输入
    }
}