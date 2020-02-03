using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARSceneManager : MonoBehaviour
{
    bool allowARTracking = false;
    public bool AllowARTracking => allowARTracking;

    [SerializeField] bool restoreAfterLostFocus = true;
    [SerializeField] Page currentPage = null;
    Page lastPage = null;
    [SerializeField] CharacterFile currentCharacter = null;
    CharacterFile lastCharacter = null;
    public bool hasFocus { get; private set; } = false;
    public bool isPlaying { get; private set; } = false;

    private void Awake()
    {
        StartCoroutine(LoadARPageScene());
    }

    IEnumerator LoadARPageScene()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

        yield return null;
    }

    public void GainFocus(Page page)
    {
        if (!allowARTracking)
        {
            LoseFocus();
            return;
        }

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

    public void AllowTracking(bool isAllowed)
    {
        allowARTracking = isAllowed;

        if (!isAllowed)
            LoseFocus();
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
