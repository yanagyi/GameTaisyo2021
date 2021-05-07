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
        StageSelect,
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

    public GameObject stageSelectInstance;

    public GameObject backgroundNoise;

    //public GameObject configKeyConfigInstance;

    private GameObject pauseManagerObject;
    private PauseManager pauseManager;

    private GameObject dataManagerObject;
    private DataManager dataManager;

    //public GameObject gameUiInstance;
    //public GameObject pauseUiInstance;

    void Awake()
    {
        pauseManagerObject = GameObject.Find("PauseManager");
        pauseManager = pauseManagerObject.GetComponent<PauseManager>();

        dataManagerObject = GameObject.Find("DataManager");
        dataManager = dataManagerObject.GetComponent<DataManager>();

        state = (int)State.Title;
        menuState = (int)MenuState.Menu;
        configState = (int)ConfigState.Volume;
    }

    void Update()
    {
        switch (state)
        {
            case (int)State.Title:
                dataManager.Load();
                pauseManager.Pause();

                titleUiInstance.SetActive(true);

                stageSelectInstance.SetActive(false);
                menuAllUiInstance.SetActive(false);
                menuUiInstance.SetActive(false);
                backgroundNoise.SetActive(false);

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    state = (int)State.StageSelect;
                }
                break;

            case (int)State.StageSelect:
                pauseManager.Pause();


                menuAllUiInstance.SetActive(false);
                titleUiInstance.SetActive(false);
                menuUiInstance.SetActive(false);
                backgroundNoise.SetActive(false);
                abandonedUiInstance.SetActive(false);
                retryUiInstance.SetActive(false);
                configUiInstance.SetActive(false);

                stageSelectInstance.SetActive(true);

                break;

            case (int)State.Menu:
                pauseManager.Pause();

                menuAllUiInstance.SetActive(true);
                backgroundNoise.SetActive(true);

                stageSelectInstance.SetActive(false);

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

                        dataManager.Save();
                    }
                    /*
                    if (configState == (int)ConfigState.KeyConfig)
                    {
                        configKeyConfigInstance.SetActive(true);

                        configVolumeInstance.SetActive(false);
                    }
                    */
                }

                break;

            case (int)State.Game:
                pauseManager.Resume();
                stageSelectInstance.SetActive(false);
                titleUiInstance.SetActive(false);
                menuAllUiInstance.SetActive(false);
                menuUiInstance.SetActive(false);
                backgroundNoise.SetActive(false);

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
