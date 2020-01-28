using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    RectTransform rectTransform;

    public enum Screens
    {
        ARScreen,
        MainMenu,
        Help,
        Credits
    }

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
        Vector3 newPosition = rectTransform.localPosition;
        newPosition.x = (int)destination * ReferenceScreenWidth * -1;
        rectTransform.localPosition = newPosition;
    }

    public void MoveToScreen(int destination) => MoveScreens((Screens)destination);
}
