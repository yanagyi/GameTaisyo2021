using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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

    // ボタン取得用
    [SerializeField] EventSystem eventSystem;
    private GameObject selectedButton;

    // 設定画面で自動的にボタンを選択するための変数
    private Button defaultConfigButton;
    private bool flagSetButton;


    void Start()
    {
        state = (int)State.Title;
        menuState = (int)MenuState.Menu;

        defaultConfigButton = GameObject.Find("Canvas/MenuUI/Config/ConfigButtons/ButtonVolume").GetComponent<Button>();
        flagSetButton = false;
    }

    void Update()
    {
        switch (state)
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

                    flagSetButton = false;
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

                    if(!flagSetButton)
                    {
                        defaultConfigButton.Select();
                        flagSetButton = true;
                    }

                    selectedButton = eventSystem.currentSelectedGameObject.gameObject;

                    if (selectedButton.name == "ButtonVolume")
                    {
                        configVolumeInstance.SetActive(true);

                        configAspectInstance.SetActive(false);
                        configKeyConfigInstance.SetActive(false);
                    }
                    if (selectedButton.name == "ButtonAspect")
                    {
                        configAspectInstance.SetActive(true);

                        configVolumeInstance.SetActive(false);
                        configKeyConfigInstance.SetActive(false);
                    }
                    if (selectedButton.name == "ButtonKeyConfig")
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
}
