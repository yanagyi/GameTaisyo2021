using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    // 仮ステート
    public enum State
    {
        Title,
        Menu,
        Game,
    }

    // 仮UI用ステート
    public enum MenuState
    {
        Menu,
        Abandoned,
        Retry,
        Config,
    }

    // 仮設定用ステート
    public enum ConfigState
    {
        Volume,
        Aspect,
        KeyConfig,
    }

    private int state;
    private int menuState;
    private int configState;

    public GameObject titleUiInstance;

    public GameObject menuAllUiInstance;
    public GameObject menuUiInstance;
    public GameObject abandonedUiInstance;
    public GameObject retryUiInstance;
    public GameObject configUiInstance;

    public GameObject configVolumeInstance;
    public GameObject configAspectInstance;
    public GameObject configKeyConfigInstance;

    //public GameObject gameUiInstance;
    //public GameObject pauseUiInstance;

    void Start()
    {
        state = (int)State.Title;
        menuState = (int)MenuState.Menu;
        configState = (int)ConfigState.Volume;
    }

    void Update()
    {

        switch(state)
        {
            case (int)State.Title:
                menuAllUiInstance.SetActive(false);
                titleUiInstance.SetActive(true);
                menuState = (int)MenuState.Menu;

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    state = (int)State.Game;
                }
                break;

            case (int)State.Menu:
                titleUiInstance.SetActive(false);
                menuAllUiInstance.SetActive(true);

                if (menuState == (int)MenuState.Menu)
                {
                    menuUiInstance.SetActive(true);

                    abandonedUiInstance.SetActive(false);
                    retryUiInstance.SetActive(false);
                    configUiInstance.SetActive(false);

                    configState = (int)MenuState.Menu;
                }
                if (menuState == (int)MenuState.Abandoned)
                {
                    abandonedUiInstance.SetActive(true);

                    menuUiInstance.SetActive(false);
                    retryUiInstance.SetActive(false);
                    configUiInstance.SetActive(false);
                }
                if (menuState == (int)MenuState.Retry)
                {
                    retryUiInstance.SetActive(true);

                    menuUiInstance.SetActive(false);
                    abandonedUiInstance.SetActive(false);
                    configUiInstance.SetActive(false);
                }
                if (menuState == (int)MenuState.Config)
                {
                    configUiInstance.SetActive(true);

                    menuUiInstance.SetActive(false);
                    abandonedUiInstance.SetActive(false);
                    retryUiInstance.SetActive(false);

                    if (configState == (int)ConfigState.Volume)
                    {
                        configVolumeInstance.SetActive(true);

                        configAspectInstance.SetActive(false);
                        configKeyConfigInstance.SetActive(false);
                    }
                    if (configState == (int)ConfigState.Aspect)
                    {
                        configAspectInstance.SetActive(true);

                        configVolumeInstance.SetActive(false);
                        configKeyConfigInstance.SetActive(false);
                    }
                    if (configState == (int)ConfigState.KeyConfig)
                    {
                        configKeyConfigInstance.SetActive(true);

                        configVolumeInstance.SetActive(false);
                        configAspectInstance.SetActive(false);
                    }
                }
                break;

            case (int)State.Game:
                titleUiInstance.SetActive(false);
                menuAllUiInstance.SetActive(false);
                menuState = (int)MenuState.Menu;

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    state = (int)State.Menu;
                }
                break;
        }
    }

    public int GetState()
    {
        return state;
    }

    public void SetState(int _state)
    {
        state = _state;
    }

    public int GetMenuState()
    {
        return menuState;
    }

    public void SetMenuState(int _state)
    {
        menuState = _state;
    }

    public int GetConfigState()
    {
        return configState;
    }

    public void SetConfigState(int _state)
    {
        configState = _state;
    }
}
