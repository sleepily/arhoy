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

    public void SetAllButtonsInteractable(bool isInteractable)
    {
        foreach (var characterButton in characterButtons)
            if (characterButton.Button)
                characterButton.Button.interactable = isInteractable;
    }

    public bool SetButtonInteractable(CharacterFile character, bool isInteractable = true)
    {
        foreach (var characterButton in characterButtons)
            if (characterButton.CharacterFile == character)
            {
                if (characterButton.Button)
                    characterButton.Button.interactable = isInteractable;


                Debug.Log($"Setting {character}'s interactablity to {isInteractable}.");

                return true;
            }

        return false;
    }
}
