using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationKey : MonoBehaviour
{
    [Tooltip("Time this key is visible in seconds.")]
    [Range(.4f, 10f)] public float time = 1f;

    [SerializeField]
    AudioClip audioClip;

    CharacterFile activeCharacter;

    private void Start()
    {
        AdjustTime();
    }

    void AdjustTime()
    {
        if (!GameManager.GM.AudioManager.UseAudioClipLength)
            return;

        if (audioClip.length > time)
            time = audioClip.length;
    }

    public void PlayKey()
    {
        if (!audioClip)
            return;

        // Play Narrator Voice
        if (!activeCharacter)
        {
            GameManager.GM.AudioManager.PlayNarrator(audioClip);

        }
    }
}
