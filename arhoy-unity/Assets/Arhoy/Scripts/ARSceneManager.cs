using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARSceneManager : MonoBehaviour
{
    [SerializeField] bool restoreAfterLostFocus = true;
    [SerializeField] Page currentPage = null;
    Page lastPage = null;
    [SerializeField] CharacterFile activeCharacter = null;
    CharacterFile lastCharacter = null;
    public bool hasFocus { get; private set; } = false;
    
    public void GainFocus(Page page)
    {
        hasFocus = true;
        currentPage = page;

        if (restoreAfterLostFocus)
            if (lastPage == currentPage)
            {
                lastCharacter = activeCharacter;
                ContinueScene();
                return;
            }

        StartScene();

        if (restoreAfterLostFocus)
        {
            lastPage = currentPage;
            lastCharacter = activeCharacter;
        }
    }

    public void LoseFocus()
    {
        hasFocus = false;
        currentPage = null;
    }

    public void ActivateCharacter(CharacterFile characterFile)
    {
        if (!hasFocus)
            return;

        if (!currentPage)
            return;

        currentPage.PlayCharacter(characterFile);
    }

    void StartScene()
    {

    }

    void ContinueScene()
    {
        StartScene();
    }

    void StopScene()
    {

    }
}
