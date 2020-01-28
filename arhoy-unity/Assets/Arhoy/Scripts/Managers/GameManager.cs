using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager gm;
    public static GameManager GM => gm;

    public ARSceneManager ARSceneManager;

    public AudioManager AudioManager;

    public CharacterButtonManager CharacterButtonManager;

    public ScreenManager ScreenManager;

    public bool isPlaytest = false;

    private void Awake()
    {
        gm = this;
    }
}
