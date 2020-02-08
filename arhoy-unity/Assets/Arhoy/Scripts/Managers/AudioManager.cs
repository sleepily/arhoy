using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource characterAudioSource;

    [SerializeField]
    bool useAudioClipLength = true;

    public AudioSource CharacterAudioSource => characterAudioSource;

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

    public void PlayAudio(AudioClip audioClip)
    {
        if (characterAudioSource.isPlaying)
            characterAudioSource.Stop();

        CharacterAudioSource.PlayOneShot(audioClip);
    }

    public void StopCharacterVoice()
    {
        CharacterAudioSource.Stop();
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
