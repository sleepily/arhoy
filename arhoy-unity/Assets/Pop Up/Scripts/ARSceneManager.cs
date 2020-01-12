using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARSceneManager : MonoBehaviour
{
    [SerializeField] bool restoreAfterLostFocus = true;
    [SerializeField] int currentPageIndex = -1;
    int lastPageIndex = -1;
    [SerializeField] int activeCharacterIndex = -1;
    int lastCharacterIndex = -1;
    bool hasFocus = false;
    
    public void GainFocus(Page page)
    {
        hasFocus = true;
        currentPageIndex = page.Number;

        if (restoreAfterLostFocus)
            if (lastPageIndex == currentPageIndex)
            {
                lastCharacterIndex = activeCharacterIndex;
                ContinueScene();
                return;
            }

        if (restoreAfterLostFocus)
        {
            lastPageIndex = currentPageIndex;
            lastCharacterIndex = activeCharacterIndex;
        }
    }

    public void LoseFocus()
    {
        hasFocus = false;
        currentPageIndex = -1;
    }

    public void ActivateCharacter(CharacterFile characterFile)
    {
        if (!hasFocus)
            return;
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
