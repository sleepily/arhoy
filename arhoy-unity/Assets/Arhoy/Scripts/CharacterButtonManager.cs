using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterButtonManager : MonoBehaviour
{
    public void Click(CharacterFile characterFile)
    {
        if (!GameManager.GM.ARSceneManager.hasFocus)
            return;

        GameManager.GM.ARSceneManager.ActivateCharacter(characterFile);
    }
}
