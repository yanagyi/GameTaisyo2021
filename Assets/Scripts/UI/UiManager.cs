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

    public enum ConfigState
    {
        Volume,
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
    public GameObject configKeyConfigInstance;

    private GameObject pauseManagerObject;
    private PauseManager pauseManager;

    //public GameObject gameUiInstance;
    //public GameObject pauseUiInstance;

    void Start()
    {

        pauseManagerObject = GameObject.Find("PauseManager");
        pauseManager = pauseManagerObject.GetComponent<PauseManager>();

        state = (int)State.Title;
        menuState = (int)MenuState.Menu;
        configState = (int)ConfigState.Volume;
    }

    void Update()
    {
        switch (state)
        {
            case (int)State.Title:
                pauseManager.Pause();

                menuAllUiInstance.SetActive(false);
                titleUiInstance.SetActive(true);
                menuUiInstance.SetActive(false);

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    state = (int)State.Game;
                }
                break;

            case (int)State.Menu:
                pauseManager.Pause();

                menuAllUiInstance.SetActive(true);


                if (menuState == (int)MenuState.Menu)
                {
                    menuUiInstance.SetActive(true);

                    abandonedUiInstance.SetActive(false);
                    retryUiInstance.SetActive(false);
                    configUiInstance.SetActive(false);
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

                        configKeyConfigInstance.SetActive(false);
                    }
                    if (configState == (int)ConfigState.KeyConfig)
                    {
                        configKeyConfigInstance.SetActive(true);

                        configVolumeInstance.SetActive(false);
                    }
                }
                break;

            case (int)State.Game:
                pauseManager.Resume();
                titleUiInstance.SetActive(false);
                menuAllUiInstance.SetActive(false);
                menuUiInstance.SetActive(false);

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    state = (int)State.Menu;
                    menuState = (int)MenuState.Menu;
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
