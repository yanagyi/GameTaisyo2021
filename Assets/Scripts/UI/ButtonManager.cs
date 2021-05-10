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
        else if ("ButtonStage".Equals(objectName))
        {
            this.ClickButtonStage();
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

        _uiManager.SetConfigState((int)UiManager.ConfigState.Volume);
    }

    private void ClickButtonKeyConfig()
    {
        Debug.Log("ClickButton KeyConfig");

        _uiManager.SetConfigState((int)UiManager.ConfigState.KeyConfig);
    }

    private void ClickButtonYes()
    {
        Debug.Log("ClickButton Yes");

        if(uiMenuState == (int)UiManager.MenuState.Abandoned)
        {
            _uiManager.SetState((int)UiManager.State.Title);
        }
        if (uiMenuState == (int)UiManager.MenuState.Retry)
        {
            _uiManager.SetState((int)UiManager.State.Game);
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

    private void ClickButtonStage()
    {
        Debug.Log("ClickButton Stage");

        // ステージボタンを押したときの個別処理

        if (stageNum == 1)
        {
            
        }
        if (stageNum == 2)
        {

        }
        if (stageNum == 3)
        {

        }
        if (stageNum == 4)
        {

        }
        if (stageNum == 5)
        {

        }
        if (stageNum == 6)
        {

        }
        if (stageNum == 7)
        {

        }
        if (stageNum == 8)
        {

        }
        if (stageNum == 9)
        {

        }
        if (stageNum == 10)
        {

        }
        if (stageNum == 11)
        {

        }
        if (stageNum == 12)
        {

        }
        if (stageNum == 13)
        {

        }
        if (stageNum == 14)
        {

        }
        if (stageNum == 15)
        {

        }
        if (stageNum == 16)
        {

        }
        if (stageNum == 17)
        {

        }
        if (stageNum == 18)
        {

        }
        if (stageNum == 19)
        {

        }
        if (stageNum == 20)
        {

        }

        _uiManager.SetState((int)UiManager.State.Game);
    }
}
