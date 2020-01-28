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

    [Space]

    GameObject characterParent;
    GameObject sceneParent;
    GameObject tracker;

    public GameObject Tracker => tracker;

    public List<CharacterFile> InaccessibleCharacters => inaccessibleCharacters;

    [Space]

    public AudioClip backgroundMusic;

    private void Awake()
    {
        GetParentObjects();
    }

    private void Start()
    {
        DisplayPageScene(false);

        characters = GetCharacters();
    }

    public void Found()
    {
        if (!GameManager.GM.ARSceneManager.AllowARTracking)
            return;

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
        Debug.Log($"Finding Character {characterFile.Name} in Page {Number}...");

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

    List<CharacterAnimation> GetCharacters()
    {
        if (!characterParent)
            GetParentObjects();

        if (characterParent)
            return characterParent.GetComponentsInChildren<CharacterAnimation>().ToList();

        return new List<CharacterAnimation>();
    }

    public void Lost()
    {
        // Hide scene and characters
        DisplayPageScene(false);
        GameManager.GM.ARSceneManager.LoseFocus();

        // @todo Stop music and sounds

        GameManager.GM.CharacterButtonManager.SetAllButtonsInteractable(false);
    }

    GameObject GetPageSceneParent()
    {
        foreach (var child in transform.GetComponentsInChildren<Transform>())
            if (child.CompareTag("PageScene"))
                return child.gameObject;

        Debug.LogWarning($"Page Scene not found for page {Number}.");

        return null;
    }

    void GetParentObjects()
    {
        foreach (var child in transform.GetComponentsInChildren<Transform>())
        {
            if (child.CompareTag("PageScene"))
                sceneParent = child.gameObject;

            if (child.CompareTag("CharacterParent"))
                characterParent = child.gameObject;

            if (child.CompareTag("Tracker"))
                tracker = child.gameObject;
        }
    }

    public void DisplayPageScene(bool isActive)
    {
        if (sceneParent)
            sceneParent.SetActive(isActive);
    }
}
