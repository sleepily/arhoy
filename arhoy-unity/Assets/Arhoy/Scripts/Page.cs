using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Page : MonoBehaviour
{
    public int Number = 0;
    List<CharacterAnimation> characters;

    [SerializeField]
    List<CharacterFile> inaccessibleCharacters;

    public List<CharacterFile> InaccessibleCharacters => inaccessibleCharacters;

    private void Awake()
    {
        DisplayPageScene(false);
    }

    private void Start()
    {
        characters = GetCharacters();
    }

    public void Found()
    {
        // Display scenery
        DisplayPageScene(true);

        // Notify AR Scene Manager
        GameManager.GM.ARSceneManager.GainFocus(this);

        GameManager.GM.CharacterButtonManager.SetAllButtonsInteractable(true);
    }

    public void PlayCharacter(CharacterFile characterFile)
    {
        foreach (CharacterAnimation c in characters)
            if (c.gameObject.name == characterFile.Name)
            {
                c.gameObject.SetActive(true);
                c.StartAnimation();
                GameManager.GM.ARSceneManager.SetActiveCharacter(characterFile);
                return;
            }
    }

    public void StopAndPlayCharacter(CharacterFile characterFile)
    {
        for (int c = 0; c < characters.Count; c++)
            characters[c].gameObject.SetActive(false);

        PlayCharacter(characterFile);
    }

    List<CharacterAnimation> GetCharacters() => GetComponentsInChildren<CharacterAnimation>().ToList();

    public void Lost()
    {
        // Hide scene and characters
        DisplayPageScene(false);
        GameManager.GM.ARSceneManager.LoseFocus();

        // @todo Stop music and sounds

        GameManager.GM.CharacterButtonManager.SetAllButtonsInteractable(false);
    }

    public void DisplayPageScene(bool isActive) => transform.GetChild(0).gameObject.SetActive(isActive);
}
