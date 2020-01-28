﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    RectTransform rectTransform;
    [SerializeField] Image backgroundDim;
    [SerializeField] [Range(0f, 1f)] float dimAmount;

    public enum Screens
    {
        ARScreen,
        MainMenu,
        Help,
        Credits
    }

    [Space]

    public Screens CurrentScreen;

    [Range(100, 1400)]
    public int ReferenceScreenWidth = 720;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        MoveScreens(CurrentScreen);
    }

    void MoveScreens(Screens destination)
    {
        CurrentScreen = destination;

        Vector3 newPosition = rectTransform.localPosition;
        newPosition.x = (int)destination * ReferenceScreenWidth * -1;
        rectTransform.localPosition = newPosition;

        GameManager.GM.ARSceneManager.AllowTracking(CurrentScreen == Screens.ARScreen);
        backgroundDim.color = (CurrentScreen == Screens.ARScreen) ? Color.clear : Color.Lerp(Color.clear, Color.black, dimAmount);
    }

    public void MoveToScreen(int destination) => MoveScreens((Screens)destination);
}
