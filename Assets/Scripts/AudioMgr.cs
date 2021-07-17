using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : MonoBehaviour
{
    public AudioSource source;

    public void Play(AudioClip clip)
    {
        if (null == source)
        {
            Debug.LogError("source not found");
            return;
        }

        source.PlayOneShot(clip);
    }
}