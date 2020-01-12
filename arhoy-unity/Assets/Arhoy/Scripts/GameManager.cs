using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager gm;

    public static GameManager GM => gm;

    private void Awake()
    {
        gm = this;
    }

    public ARSceneManager ARSceneManager;
}
