using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    // 仮置きステート
    public enum TemporaryState
    {
        Title,
        Menu,
        Game,
    }

    private int state;
    public GameObject titleUiInstance;
    public GameObject menuUiInstance;
    //public GameObject gameUiInstance;
    //public GameObject pauseUiInstance;

    void Start()
    {
        state = (int)TemporaryState.Title;
    }

    void Update()
    {
        switch(state)
        {
            case (int)TemporaryState.Title:
                menuUiInstance.SetActive(false);
                titleUiInstance.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Alpha0))
                {
                    state = (int)TemporaryState.Menu;
                }
                break;

            case (int)TemporaryState.Menu:
                titleUiInstance.SetActive(false);
                menuUiInstance.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Alpha0))
                {
                    state = (int)TemporaryState.Game;
                }
                break;

            case (int)TemporaryState.Game:
                titleUiInstance.SetActive(false);
                menuUiInstance.SetActive(false);

                if (Input.GetKeyDown(KeyCode.Alpha0))
                {
                    state = (int)TemporaryState.Title;
                }
                break;
        }
    }
}
