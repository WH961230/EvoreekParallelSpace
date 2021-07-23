using UnityEngine;

public class AudioMgr : Singleton<AudioMgr>
{
    private SOAudio config;

    public void Play(AudioSource source, AudioClip clip)
    {
        if (null == source)
        {
            Debug.LogError("source not found");
            return;
        }

        source.PlayOneShot(clip);
    }
}