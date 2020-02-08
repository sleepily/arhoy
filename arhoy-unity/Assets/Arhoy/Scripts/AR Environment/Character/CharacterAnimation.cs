using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    List<AnimationKey> animationKeys;
    int currentKey = 0;
    float lastKeyTime = 0f;

    [SerializeField] public AudioClip audioClip;

    private void Start()
    {
        animationKeys = GetAnimationKeys();
        // Debug.Log($"Found {animationKeys.Count} animation keys in {name}.");

        StopAnimation();
    }

    List<AnimationKey> GetAnimationKeys() => GetComponentsInChildren<AnimationKey>().OrderBy(key => key.name).ToList();

    public void StartAnimation()
    {
        if (animationKeys.Count != 0)
            StartCoroutine(AnimationCoroutine());

        GameManager.GM.AudioManager.PlayAudio(audioClip);
    }

    IEnumerator AnimationCoroutine()
    {
        lastKeyTime = Time.time;
        currentKey = 0;

        // Show first key
        animationKeys[currentKey].gameObject.SetActive(true);

        while (currentKey < animationKeys.Count)
        {
            if (Time.time >= lastKeyTime + animationKeys[currentKey].time)
            {
                lastKeyTime += animationKeys[currentKey].time;

                // Hide last and show next key if possible
                animationKeys[currentKey].gameObject.SetActive(false);

                if (++currentKey < animationKeys.Count)
                    animationKeys[currentKey].gameObject.SetActive(true);
            }

            yield return new WaitForSeconds(.08f);
        }

        // Wait for the last key duration
        yield return new WaitForSeconds(animationKeys[animationKeys.Count - 1].time);

        StopAnimation();
    }

    public void StopAnimation()
    {
        currentKey = 0;

        for (int k = 0; k < animationKeys.Count; k++)
            animationKeys[k].gameObject.SetActive(false);
    }
}
