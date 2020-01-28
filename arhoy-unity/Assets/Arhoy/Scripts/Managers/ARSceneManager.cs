using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARSceneManager : MonoBehaviour
{
    [SerializeField] bool restoreAfterLostFocus = true;
    [SerializeField] Page currentPage = null;
    Page lastPage = null;
    [SerializeField] CharacterFile currentCharacter = null;
    CharacterFile lastCharacter = null;
    public bool hasFocus { get; private set; } = false;
    public bool isPlaying { get; private set; } = false;
    
    public void GainFocus(Page page)
    {
        hasFocus = true;
        currentPage = page;

        /*
        if (restoreAfterLostFocus)
            if (lastPage == currentPage)
            {
                lastCharacter = activeCharacter;
                // ContinueScene();
                return;
            }

        if (restoreAfterLostFocus)
        {
            lastPage = currentPage;
            lastCharacter = activeCharacter;
        }
        */
    }

    public void LoseFocus()
    {
        hasFocus = false;
        currentPage = null;
        currentCharacter = null;
    }

    public void PlayCharacter(CharacterFile characterFile)
    {
        Debug.Log($"Playing Character {characterFile.Name}...");

        if (!GameManager.GM.isPlaytest)
        {
            if (!hasFocus)
                return;

            if (!currentPage)
                return;
        }

        if (isPlaying)
        {
            currentPage.StopAndPlayCharacter(characterFile);
            return;
        }

        currentPage.PlayCharacter(characterFile);
    }

    public void SetActiveCharacter(CharacterFile characterFile)
    {
        currentCharacter = characterFile;
        isPlaying = true;
    }
}
