using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaytestScript : MonoBehaviour
{
    public CharacterFile jessi, amira, igor, mona;

    [Space]

    public Page testPage;
    bool pageVisible = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            GameManager.GM.ARSceneManager.PlayCharacter(jessi);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            GameManager.GM.ARSceneManager.PlayCharacter(amira);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            GameManager.GM.ARSceneManager.PlayCharacter(igor);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            GameManager.GM.ARSceneManager.PlayCharacter(mona);

        if (Input.GetKeyDown(KeyCode.Space))
            testPage.DisplayPageScene(pageVisible = !pageVisible);
    }
}
