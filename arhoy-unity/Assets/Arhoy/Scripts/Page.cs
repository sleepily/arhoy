using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{
    public int Number = 0;

    private void Awake()
    {
        SetChildActive(false);
    }

    public void Found()
    {
        // Display scenery
        SetChildActive(true);

        // Notify AR Scene Manager
        // Allow implementation of characters
        GameManager.GM.ARSceneManager.GainFocus(this);

        // Play sounds
    }

    public void PlayCharacter(CharacterFile characterFile)
    {
        GameObject.Find(characterFile.Name).gameObject.SetActive(true);
    }

    public void Lost()
    {
        // Hide scene and characters
        // Stop music and sounds
    }

    public void SetChildActive(bool isActive) => transform.GetChild(0).gameObject.SetActive(isActive);
}
