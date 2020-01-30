using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource narratorAudioSource;

    [SerializeField]
    bool useAudioClipLength = true;

    public AudioSource NarratorAudioSource => narratorAudioSource;

    public bool UseAudioClipLength => useAudioClipLength;

    [SerializeField]
    AudioMixer master;

    bool musicIsMuted, soundIsMuted = false;

    [SerializeField]
    AudioMixerSnapshot[] snapshots;

    public enum AudioSnapshots
    {
        All,
        MusicMuted,
        SoundMuted,
        AllMuted
    }

    [HideInInspector]
    public AudioSnapshots CurrentAudioSnapshot;

    public void PlayNarrator(AudioClip audioClip)
    {
        NarratorAudioSource.PlayOneShot(audioClip);
    }

    public void ToggleMusic()
    {
        musicIsMuted = !musicIsMuted;
        TransitionToSnapshot();
    }

    public void ToggleSound()
    {
        soundIsMuted = !soundIsMuted;
        TransitionToSnapshot();
    }

    void TransitionToSnapshot(float t = .6f)
    {
        if (!musicIsMuted && !soundIsMuted)
            CurrentAudioSnapshot = AudioSnapshots.All;

        if (musicIsMuted && !soundIsMuted)
            CurrentAudioSnapshot = AudioSnapshots.MusicMuted;

        if (!musicIsMuted && soundIsMuted)
            CurrentAudioSnapshot = AudioSnapshots.SoundMuted;

        if (musicIsMuted && soundIsMuted)
            CurrentAudioSnapshot = AudioSnapshots.AllMuted;

        snapshots[(int)CurrentAudioSnapshot].TransitionTo(t);
    }
}
