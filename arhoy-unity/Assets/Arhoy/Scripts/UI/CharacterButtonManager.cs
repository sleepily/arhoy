using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CharacterButtonManager : MonoBehaviour
{
    List<CharacterButton> characterButtons;

    private void Start()
    {
        GetButtons();
    }

    void GetButtons() => characterButtons = GetComponentsInChildren<CharacterButton>().ToList();

    public bool SetAllButtonsInteractable(bool isInteractable)
    {
        foreach (var characterButton in characterButtons)
        {
            characterButton.Button.interactable = isInteractable;
            return true;
        }

        return false;
    }

    public bool SetButtonInteractable(CharacterFile character, bool isInteractable = true)
    {
        foreach (var characterButton in characterButtons)
            if (characterButton.CharacterFile == character)
            {
                characterButton.Button.interactable = isInteractable;
                return true;
            }

        return false;
    }
}
