using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager gm;
    public static GameManager GM => gm;

    public ARSceneManager ARSceneManager;

    public bool isPlaytest = false;

    private void Awake()
    {
        gm = this;
    }

}
