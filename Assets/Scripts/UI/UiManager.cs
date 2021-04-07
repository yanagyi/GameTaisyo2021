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

    // 仮置きUI用
    public enum TemporaryMenuState
    {
        Menu,
        Abandoned,
        Retry,
        Config,
    }

    private int state;
    private int menuState;
    public GameObject titleUiInstance;
    public GameObject menuAllUiInstance;
    public GameObject menuUiInstance;
    public GameObject abandonedUiInstance;
    public GameObject retryUiInstance;
    public GameObject configUiInstance;
    //public GameObject gameUiInstance;
    //public GameObject pauseUiInstance;

    void Start()
    {
        state = (int)TemporaryState.Title;
        menuState = (int)TemporaryMenuState.Menu;
    }

    void Update()
    {
        switch(state)
        {
            case (int)TemporaryState.Title:
                menuAllUiInstance.SetActive(false);
                titleUiInstance.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Alpha0))
                {
                    state = (int)TemporaryState.Menu;
                }
                break;

            case (int)TemporaryState.Menu:
                titleUiInstance.SetActive(false);
                menuAllUiInstance.SetActive(true);

                if (menuState == (int)TemporaryMenuState.Menu)
                {
                    menuUiInstance.SetActive(true);
                    abandonedUiInstance.SetActive(false);
                    retryUiInstance.SetActive(false);
                    configUiInstance.SetActive(false);
                }
                if (menuState == (int)TemporaryMenuState.Abandoned)
                {
                    abandonedUiInstance.SetActive(true);
                    menuUiInstance.SetActive(false);
                    retryUiInstance.SetActive(false);
                    configUiInstance.SetActive(false);
                }
                if (menuState == (int)TemporaryMenuState.Retry)
                {
                    retryUiInstance.SetActive(true);
                    menuUiInstance.SetActive(false);
                    abandonedUiInstance.SetActive(false);
                    configUiInstance.SetActive(false);
                }
                if (menuState == (int)TemporaryMenuState.Config)
                {
                    configUiInstance.SetActive(true);
                    menuUiInstance.SetActive(false);
                    abandonedUiInstance.SetActive(false);
                    retryUiInstance.SetActive(false);
                }


                if (Input.GetKeyDown(KeyCode.Return))
                {
                    menuState++;
                }
                if (menuState > (int)TemporaryMenuState.Config)
                {
                    menuState = (int)TemporaryMenuState.Menu;
                }

                if (Input.GetKeyDown(KeyCode.Alpha0))
                {
                    state = (int)TemporaryState.Title;
                    menuState = (int)TemporaryMenuState.Menu;
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
