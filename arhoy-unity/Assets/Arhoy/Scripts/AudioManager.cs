using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource narratorAudioSource;

    [SerializeField]
    bool useAudioClipLength = true;

    public AudioSource NarratorAudioSource => narratorAudioSource;

    public bool UseAudioClipLength => useAudioClipLength;

    public void PlayNarrator(AudioClip audioClip)
    {
        NarratorAudioSource.PlayOneShot(audioClip);
    }
}
