using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public enum State
    {
        Title,
        Menu,
        StageSelect,
        Game,
        Result,
    }

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

    static int state;
    static int nextState;
    static int menuState;
    static int configState;

    static int stageNum;

    public GameObject titleUiInstance;

    public GameObject menuAllUiInstance;
    public GameObject menuUiInstance;
    public GameObject abandonedUiInstance;
    public GameObject retryUiInstance;
    public GameObject configUiInstance;

    public GameObject configVolumeInstance;

    public GameObject stageSelectInstance;

    public GameObject resultInstance;

    public GameObject backgroundNoise;

    private GameObject stageManagerObject;
    private StageManager stageManager;

    private GameObject pauseManagerObject;
    private PauseManager pauseManager;

    private GameObject dataManagerObject;
    private DataManager dataManager;

    private GameObject fadeManagerObject;
    private Fade fadeManager;

    private static bool nowFade;

    public GameObject SoundObject;

    void Awake()
    {
        if(nowFade == null)
        {
            nowFade = false;
        }

        stageManagerObject = GameObject.Find("StageManager");
        stageManager = stageManagerObject.GetComponent<StageManager>();

        pauseManagerObject = GameObject.Find("PauseManager");
        pauseManager = pauseManagerObject.GetComponent<PauseManager>();

        dataManagerObject = GameObject.Find("DataManager");
        dataManager = dataManagerObject.GetComponent<DataManager>();

        dataManager.Load();

        fadeManagerObject = GameObject.Find("FadeManager");
        fadeManager = fadeManagerObject.GetComponent<Fade>();

        SoundObject = GameObject.Find("SoundManager");
        if (state == null)
        {
            state = (int)State.Title;
            fadeManager.FadeIn();
        }
        if (nextState == null)
        {
            nextState = state;
        }
        if (menuState == null)
        {
            menuState = (int)MenuState.Menu;
        }
        if (configState == null)
        {
            configState = (int)ConfigState.Volume;
        }

    }

    void Update()
    {
        if(state != nextState && !Fade.isFadeOut && !nowFade)
        {
            fadeManager.FadeOut();
            nowFade = true;
        }

        if(state != nextState && !Fade.isFadeOut && !Fade.isFadeIn && nowFade)
        {
            fadeManager.FadeIn();
            nowFade = false;
            state = nextState;
            if (nextState == (int)State.Game)
            {
                stageManager.GoStageAny(stageNum);
                SoundObject.GetComponent<SoundManager>().Play_BGM_GAME();
            }
        }

        switch (state)
        {
            case (int)State.Title:
                pauseManager.Pause();

                titleUiInstance.SetActive(true);

                stageSelectInstance.SetActive(false);
                menuAllUiInstance.SetActive(false);
                menuUiInstance.SetActive(false);
                backgroundNoise.SetActive(false);
                resultInstance.SetActive(false);

                if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKey(KeyCode.JoystickButton1)) && !Fade.isFadeOut && !Fade.isFadeIn)
                {
                    nextState = (int)State.StageSelect;
                    SoundObject.GetComponent<SoundManager>().Play_BGM_SELECT();
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
                resultInstance.SetActive(false);

                stageSelectInstance.SetActive(true);

                
                break;

            case (int)State.Menu:
                pauseManager.Pause();

                menuAllUiInstance.SetActive(true);
                backgroundNoise.SetActive(true);

                stageSelectInstance.SetActive(false);
                resultInstance.SetActive(false);

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
            case (int)State.Result:
                pauseManager.Pause();

                menuAllUiInstance.SetActive(false);
                titleUiInstance.SetActive(false);
                menuUiInstance.SetActive(false);
                backgroundNoise.SetActive(false);
                abandonedUiInstance.SetActive(false);
                retryUiInstance.SetActive(false);
                configUiInstance.SetActive(false);

                resultInstance.SetActive(true);

                dataManager.Save();

                break;

            case (int)State.Game:
                if(nextState != (int)State.Game)
                {
                    pauseManager.Pause();
                }

                stageSelectInstance.SetActive(false);
                titleUiInstance.SetActive(false);
                menuAllUiInstance.SetActive(false);
                menuUiInstance.SetActive(false);
                backgroundNoise.SetActive(false);
                resultInstance.SetActive(false);

                if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton15)) && !Fade.isFadeOut && !Fade.isFadeIn)
                {
                    state = (int)State.Menu;
                    nextState = (int)State.Menu;
                    menuState = (int)MenuState.Menu;
                }
                break;
        }

        // ゲーム終了
        if (Input.GetKey(KeyCode.Q))
        {
            Application.Quit();
        }

        // データリセット
        if (Input.GetKey(KeyCode.R))
        {
            dataManager.Reset();
        }
        if(Input.GetKey(KeyCode.JoystickButton0))
        Debug.Log("0");
        if (Input.GetKey(KeyCode.JoystickButton1))
            Debug.Log("1");
        if (Input.GetKey(KeyCode.JoystickButton2))
            Debug.Log("2");
        if (Input.GetKey(KeyCode.JoystickButton3))
            Debug.Log("3");
        if (Input.GetKey(KeyCode.JoystickButton4))
            Debug.Log("4");
        if (Input.GetKey(KeyCode.JoystickButton5))
            Debug.Log("5");
        if (Input.GetKey(KeyCode.JoystickButton6))
            Debug.Log("6");
        if (Input.GetKey(KeyCode.JoystickButton7))
            Debug.Log("7");
        if (Input.GetKey(KeyCode.JoystickButton8))
            Debug.Log("8");
        if (Input.GetKey(KeyCode.JoystickButton9))
            Debug.Log("9");
        if (Input.GetKey(KeyCode.JoystickButton10))
            Debug.Log("10");
        if (Input.GetKey(KeyCode.JoystickButton11))
            Debug.Log("11");
        if (Input.GetKey(KeyCode.JoystickButton12))
            Debug.Log("12");
        if (Input.GetKey(KeyCode.JoystickButton13))
            Debug.Log("13");
        if (Input.GetKey(KeyCode.JoystickButton14))
            Debug.Log("14");
        if (Input.GetKey(KeyCode.JoystickButton15))
            Debug.Log("15");
        if (Input.GetKey(KeyCode.JoystickButton16))
            Debug.Log("16");
        if (Input.GetKey(KeyCode.JoystickButton17))
            Debug.Log("17");
        if (Input.GetKey(KeyCode.JoystickButton18))
            Debug.Log("18");
        if (Input.GetKey(KeyCode.JoystickButton19))
            Debug.Log("19");
    }

    public int GetState()
    {
        return state;
    }

    public void SetState(int _state)
    {
        state = _state;
    }

    public int GetNextState()
    {
        return nextState;
    }

    public void SetNextState(int _state)
    {
        nextState = _state;
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

    public void SetStageNum(int num)
    {
        stageNum = num;
    }
}
