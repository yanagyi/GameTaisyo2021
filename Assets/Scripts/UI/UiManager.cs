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
    private static bool isBgmOn;

    void Awake()
    {
        if(nowFade == null)
        {
            nowFade = false;
        }

	if(isBgmOn == null)
	{
            isBgmOn = false;
	}

        stageManagerObject = GameObject.Find("StageManager");
        stageManager = stageManagerObject.GetComponent<StageManager>();

        pauseManagerObject = GameObject.Find("PauseManager");
        pauseManager = pauseManagerObject.GetComponent<PauseManager>();

        dataManagerObject = GameObject.Find("DataManager");
        dataManager = dataManagerObject.GetComponent<DataManager>();

        dataManager.Load();
        dataManager.AllUnlock();

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
            isBgmOn = false;
            if (nextState == (int)State.Game)
            {
                stageManager.GoStageAny(stageNum);
            }
        }

        switch (state)
        {
            case (int)State.Title:
                pauseManager.Pause();

                if (!isBgmOn)
                {
                    SoundObject.GetComponent<SoundManager>().Play_BGM_TITLE();
                    isBgmOn = true;
                }

                titleUiInstance.SetActive(true);

                stageSelectInstance.SetActive(false);
                menuAllUiInstance.SetActive(false);
                menuUiInstance.SetActive(false);
                backgroundNoise.SetActive(false);
                resultInstance.SetActive(false);

                if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKey(KeyCode.JoystickButton1)) && !Fade.isFadeOut && !Fade.isFadeIn)
                {
                    nextState = (int)State.StageSelect;
                }

                break;

            case (int)State.StageSelect:
                pauseManager.Pause();

                if (!isBgmOn)
                {
                    SoundObject.GetComponent<SoundManager>().Play_BGM_SELECT();
                    isBgmOn = true;
                }


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

                if (!isBgmOn)
                {
                    SoundObject.GetComponent<SoundManager>().Play_BGM_CLEAR();
                    isBgmOn = true;
                }

                break;

            case (int)State.Game:
                if(nextState != (int)State.Game)
                {
                    pauseManager.Pause();
                }

                if(!isBgmOn)
                {
                    SoundObject.GetComponent<SoundManager>().Play_BGM_GAME();
                    isBgmOn = true;
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
        /*
        if (Input.GetKey(KeyCode.R))
        {
            dataManager.Reset();
        }
        */
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
