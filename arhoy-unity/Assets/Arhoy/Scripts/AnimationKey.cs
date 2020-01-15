using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationKey : MonoBehaviour
{
    [Tooltip("Time this key is visible in seconds.")]
    [Range(.4f, 10f)] public float time = 1f;
}
