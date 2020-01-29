using System.Collections;
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
    public GameObject[] ScreenObjects;
    public GameObject CurrentScreenObject;

    [Range(600, 2400)]
    public int ReferenceScreenWidth = 1820;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        ScreenObjects = GetScreenGameObjects();

        MoveScreens(CurrentScreen);
    }

    GameObject[] GetScreenGameObjects()
    {
        List<GameObject> objects = new List<GameObject>();

        foreach (Transform t in GetComponentInChildren<Transform>())
        {
            objects.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }

        return objects.ToArray();
    }

    void MoveScreens(Screens destination)
    {
        SetScreenActive(CurrentScreen, false);

        CurrentScreen = destination;

        Vector3 newPosition = rectTransform.localPosition;
        newPosition.x = (int)destination * ReferenceScreenWidth * -1;
        rectTransform.localPosition = newPosition;

        GameManager.GM.ARSceneManager.AllowTracking(CurrentScreen == Screens.ARScreen);
        backgroundDim.color = (CurrentScreen == Screens.ARScreen) ? Color.clear : Color.Lerp(Color.clear, Color.black, dimAmount);

        SetScreenActive(CurrentScreen, true);
    }

    public void MoveToScreen(int destination) => MoveScreens((Screens)destination);

    void SetScreenActive(Screens screen, bool isActive)
    {
        ScreenObjects[(int)screen].SetActive(isActive);
    }
}
