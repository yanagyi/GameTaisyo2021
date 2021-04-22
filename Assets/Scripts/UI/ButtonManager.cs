using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ButtonBaseクラスから継承しここで処理
public class ButtonManager : ButtonBase
{
    GameObject uiManagerObject;
    UiManager _uiManager;
    private int uiState;
    private int uiMenuState;

    void Start()
    {
        uiManagerObject = GameObject.Find("UiManager");
        _uiManager = uiManagerObject.GetComponent<UiManager>();
    }

    void Update()
    {
        uiState = _uiManager.GetState();
        uiMenuState = _uiManager.GetMenuState();
    }

    protected override void OnClick(string objectName)
    {
        // ボタンの振り分け
        if ("ButtonYes".Equals(objectName))
        {
            this.ClickButtonYes();
        }
        else if ("ButtonNo".Equals(objectName))
        {
            this.ClickButtonNo();
        }
        else if ("ButtonGameBack".Equals(objectName))
        {
            this.ClickButtonGameBack();
        }
        else if ("ButtonTitleBack".Equals(objectName))
        {
            this.ClickButtonTitleBack();
        }
        else if ("ButtonMenuBack".Equals(objectName))
        {
            this.ClickButtonMenuBack();
        }
        else if ("ButtonRetry".Equals(objectName))
        {
            this.ClickButtonRetry();
        }
        else if ("ButtonConfig".Equals(objectName))
        {
            this.ClickButtonConfig();
        }
        else if ("ButtonVolume".Equals(objectName))
        {
            this.ClickButtonVolume();
        }
        else if ("ButtonAspect".Equals(objectName))
        {
            this.ClickButtonAspect();
        }
        else if ("ButtonAspectDefault".Equals(objectName))
        {
            this.ClickButtonAspectDefault();
        }
        else if ("ButtonAspectFullscreen".Equals(objectName))
        {
            this.ClickButtonAspectFullscreen();
        }
        else if ("ButtonAspectFree".Equals(objectName))
        {
            this.ClickButtonAspectFree();
        }
        else if ("ButtonKeyConfig".Equals(objectName))
        {
            this.ClickButtonKeyConfig();
        }
        else if ("ButtonUp".Equals(objectName))
        {
            this.ClickButtonUp();
        }
        else if ("ButtonDown".Equals(objectName))
        {
            this.ClickButtonDown();
        }
        else if ("ButtonLeft".Equals(objectName))
        {
            this.ClickButtonLeft();
        }
        else if ("ButtonRight".Equals(objectName))
        {
            this.ClickButtonRight();
        }
        else
        {
            // 指定されたボタンが存在しない
            throw new System.Exception("Button Not Exist");
        }
    }


    // 個別ボタン処理

    private void ClickButtonGameBack()
    {
        Debug.Log("ClickButton GameBack");

        _uiManager.SetState((int)UiManager.State.Game);
    }

    private void ClickButtonTitleBack()
    {
        Debug.Log("ClickButton TitleBack");

        _uiManager.SetMenuState((int)UiManager.MenuState.Abandoned);
    }

    private void ClickButtonMenuBack()
    {
        Debug.Log("ClickButton MenuBack");

        _uiManager.SetMenuState((int)UiManager.MenuState.Menu);
    }

    private void ClickButtonRetry()
    {
        Debug.Log("ClickButton Retry");

        _uiManager.SetMenuState((int)UiManager.MenuState.Retry);
    }

    private void ClickButtonConfig()
    {
        Debug.Log("ClickButton Config");

        _uiManager.SetMenuState((int)UiManager.MenuState.Config);
    }

    private void ClickButtonVolume()
    {
        Debug.Log("ClickButton Volume");

        //_uiManager.SetConfigState((int)UiManager.ConfigState.Volume);
    }

    private void ClickButtonAspect()
    {
        Debug.Log("ClickButton Aspect");

        //_uiManager.SetConfigState((int)UiManager.ConfigState.Aspect);
    }

    private void ClickButtonAspectDefault()
    {
        Debug.Log("ClickButton Aspect");
    }

    private void ClickButtonAspectFullscreen()
    {
        Debug.Log("ClickButton AspectFullscreen");
    }

    private void ClickButtonAspectFree()
    {
        Debug.Log("ClickButton AspectFree");
    }

    private void ClickButtonKeyConfig()
    {
        Debug.Log("ClickButton KeyConfig");

        //_uiManager.SetConfigState((int)UiManager.ConfigState.KeyConfig);
    }

    private void ClickButtonYes()
    {
        Debug.Log("ClickButton Yes");

        if(uiMenuState == (int)UiManager.MenuState.Abandoned)
        {
            _uiManager.SetState((int)UiManager.State.Title);
            PauseManager.Pause(false);
        }
        if (uiMenuState == (int)UiManager.MenuState.Retry)
        {
            _uiManager.SetState((int)UiManager.State.Game);
            PauseManager.Pause(true);
        }
    }

    private void ClickButtonNo()
    {
        Debug.Log("ClickButton No");

        if (uiMenuState == (int)UiManager.MenuState.Abandoned)
        {
            _uiManager.SetMenuState((int)UiManager.MenuState.Menu);
        }
        if (uiMenuState == (int)UiManager.MenuState.Retry)
        {
            _uiManager.SetMenuState((int)UiManager.MenuState.Menu);
        }
    }

    private void ClickButtonUp()
    {
        Debug.Log("ClickButton UpArrow");
    }

    private void ClickButtonDown()
    {
        Debug.Log("ClickButton DownArrow");
    }

    private void ClickButtonLeft()
    {
        Debug.Log("ClickButton LeftArrow");
    }

    private void ClickButtonRight()
    {
        Debug.Log("ClickButton RightArrow");
    }
}
