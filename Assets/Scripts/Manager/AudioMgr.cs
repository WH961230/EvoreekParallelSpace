using UnityEngine;

public class AudioMgr : Singleton<AudioMgr> , IBaseMgr
{
    private SOAudio config;
    private bool isOpenBackgroundMusic = false;
    private AudioClip BackgroundClip;
    private AudioSource source;

    private void Play(AudioSource source, AudioClip clip)
    {
        if (null == source)
        {
            Debug.LogError("source not found");
            return;
        }

        source.PlayOneShot(clip);
    }

    public void OnInit(GameEngine engine) {
        engine.managers.Add(this);
        if (isOpenBackgroundMusic == false) return;
        source = new AudioSource();
        Play(source, BackgroundClip);
        if (null == source) {
            Debug.LogError("audioManager or source not find");
        }
    }

    public void OnUpdate() {
    }

    public void OnClear() {
    }
}