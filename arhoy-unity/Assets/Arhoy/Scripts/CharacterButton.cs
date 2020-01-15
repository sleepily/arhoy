using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    [SerializeField] CharacterFile characterFile;
    [SerializeField] public Button button { get; private set; }

    private void Start()
    {
        button = GetComponent<Button>();
    }

    public void Pressed()
    {
        if (!GameManager.GM.isPlaytest)
            if (!GameManager.GM.ARSceneManager.hasFocus)
                return;

        GameManager.GM.ARSceneManager.PlayCharacter(characterFile);
    }
}
