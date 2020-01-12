using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterButton : MonoBehaviour
{
    [SerializeField] CharacterFile character;

    public void SendCharacterToManager()
    {
        GameManager.GM.ARSceneManager.ActivateCharacter(character);
    }
}
