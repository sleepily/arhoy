using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Page : MonoBehaviour
{
    public int Number = 0;
    List<CharacterAnimation> characters;

    [Tooltip("Drag all INACCESIBLE Characters here so they cannot be selected.")]
    [SerializeField]
    List<CharacterFile> inaccessibleCharacters;

    GameObject pageScene;

    public List<CharacterFile> InaccessibleCharacters => inaccessibleCharacters;

    private void Awake()
    {
        pageScene = GetPageScene();
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
        DisableInaccessibleCharacters();
    }

    void DisableInaccessibleCharacters()
    {
        foreach (var inaccessibleCharacter in inaccessibleCharacters)
            GameManager.GM.CharacterButtonManager.SetButtonInteractable(inaccessibleCharacter, false);
    }

    public void PlayCharacter(CharacterFile characterFile)
    {
        foreach (CharacterAnimation characterAnimation in characters)
            if (characterAnimation.gameObject.name == characterFile.Name)
            {
                characterAnimation.gameObject.SetActive(true);
                characterAnimation.StartAnimation();
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

    GameObject GetPageScene()
    {
        foreach (var child in transform.GetComponentsInChildren<Transform>())
            if (child.CompareTag("PageScene"))
                return child.gameObject;

        Debug.LogWarning($"Page Scene not found for page {Number}.");

        return null;
    }

    public void DisplayPageScene(bool isActive)
    {
        if (pageScene)
            pageScene.SetActive(isActive);
    }
}
