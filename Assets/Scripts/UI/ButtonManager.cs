using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ButtonBaseクラスから継承しここで処理
public class ButtonManager : ButtonBase
{
    GameObject uiManagerObject;
    UiManager _uiManager;

    GameObject stageManagerObject;
    StageManager stageManager;

    void Start()
    {
        uiManagerObject = GameObject.Find("UiManager");
        _uiManager = uiManagerObject.GetComponent<UiManager>();

        stageManagerObject = GameObject.Find("StageManager");
        stageManager = stageManagerObject.GetComponent<StageManager>();
    }

    void Update()
    {
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
        else if ("ButtonNextStage".Equals(objectName))
        {
            this.ClickButtonNextStage();
        }
        else if ("ButtonStageSelect".Equals(objectName))
        {
            this.ClickButtonStageSelect();
        }
        else if ("Retry".Equals(objectName))
        {
            this.ClickRetry();
        }
        else if ("ButtonStage1".Equals(objectName))
        {
            this.ClickButtonStage1();
        }
        else if ("ButtonStage2".Equals(objectName))
        {
            this.ClickButtonStage2();
        }
        else if ("ButtonStage3".Equals(objectName))
        {
            this.ClickButtonStage3();
        }
        else if ("ButtonStage4".Equals(objectName))
        {
            this.ClickButtonStage4();
        }
        else if ("ButtonStage5".Equals(objectName))
        {
            this.ClickButtonStage5();
        }
        else if ("ButtonStage6".Equals(objectName))
        {
            this.ClickButtonStage6();
        }
        else if ("ButtonStage7".Equals(objectName))
        {
            this.ClickButtonStage7();
        }
        else if ("ButtonStage8".Equals(objectName))
        {
            this.ClickButtonStage8();
        }
        else if ("ButtonStage9".Equals(objectName))
        {
            this.ClickButtonStage9();
        }
        else if ("ButtonStage10".Equals(objectName))
        {
            this.ClickButtonStage10();
        }
        else if ("ButtonStage11".Equals(objectName))
        {
            this.ClickButtonStage11();
        }
        else if ("ButtonStage12".Equals(objectName))
        {
            this.ClickButtonStage12();
        }
        else if ("ButtonStage13".Equals(objectName))
        {
            this.ClickButtonStage13();
        }
        else if ("ButtonStage14".Equals(objectName))
        {
            this.ClickButtonStage14();
        }
        else if ("ButtonStage15".Equals(objectName))
        {
            this.ClickButtonStage15();
        }
        else if ("ButtonStage16".Equals(objectName))
        {
            this.ClickButtonStage16();
        }
        else if ("ButtonStage17".Equals(objectName))
        {
            this.ClickButtonStage17();
        }
        else if ("ButtonStage18".Equals(objectName))
        {
            this.ClickButtonStage18();
        }
        else if ("ButtonStage19".Equals(objectName))
        {
            this.ClickButtonStage19();
        }
        else if ("ButtonStage20".Equals(objectName))
        {
            this.ClickButtonStage20();
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

    private void ClickButtonNextStage()
    {
        Debug.Log("ClickButton NextStage");

        stageManager.AdvanceGame();

        _uiManager.SetState((int)UiManager.State.Game);
    }

    private void ClickRetry()
    {
        Debug.Log("Click Retry");

        stageManager.RetryGame();

        _uiManager.SetState((int)UiManager.State.Game);
    }

    private void ClickButtonYes()
    {
        Debug.Log("ClickButton Yes");

        if(_uiManager.GetMenuState() == (int)UiManager.MenuState.Abandoned)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            _uiManager.SetState((int)UiManager.State.Title);
        }
        if (_uiManager.GetMenuState() == (int)UiManager.MenuState.Retry)
        {
            stageManager.RetryGame();
            _uiManager.SetState((int)UiManager.State.Game);
        }
    }

    private void ClickButtonNo()
    {
        Debug.Log("ClickButton No");

        if (_uiManager.GetMenuState() == (int)UiManager.MenuState.Abandoned)
        {
            _uiManager.SetMenuState((int)UiManager.MenuState.Menu);
        }
        if (_uiManager.GetMenuState() == (int)UiManager.MenuState.Retry)
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

    private void ClickButtonStageSelect()
    {
        Debug.Log("ClickButton StageSelect");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        _uiManager.SetState((int)UiManager.State.StageSelect);

    }

    private void ClickButtonStage1()
    {
        Debug.Log("ClickButton Stage1");

        stageManager.GoStageAny(1);

        _uiManager.SetState((int)UiManager.State.Game);
    }

    private void ClickButtonStage2()
    {
        Debug.Log("ClickButton Stage2");

        stageManager.GoStageAny(2);

        _uiManager.SetState((int)UiManager.State.Game);
    }

    private void ClickButtonStage3()
    {
        Debug.Log("ClickButton Stage3");

        stageManager.GoStageAny(3);

        _uiManager.SetState((int)UiManager.State.Game);
    }

    private void ClickButtonStage4()
    {
        Debug.Log("ClickButton Stage4");

        stageManager.GoStageAny(4);

        _uiManager.SetState((int)UiManager.State.Game);
    }

    private void ClickButtonStage5()
    {
        Debug.Log("ClickButton Stage5");

        stageManager.GoStageAny(5);

        _uiManager.SetState((int)UiManager.State.Game);
    }

    private void ClickButtonStage6()
    {
        Debug.Log("ClickButton Stage6");

        stageManager.GoStageAny(6);

        _uiManager.SetState((int)UiManager.State.Game);
    }

    private void ClickButtonStage7()
    {
        Debug.Log("ClickButton Stage7");

        stageManager.GoStageAny(7);

        _uiManager.SetState((int)UiManager.State.Game);
    }

    private void ClickButtonStage8()
    {
        Debug.Log("ClickButton Stage8");

        stageManager.GoStageAny(8);

        _uiManager.SetState((int)UiManager.State.Game);
    }

    private void ClickButtonStage9()
    {
        Debug.Log("ClickButton Stage9");

        stageManager.GoStageAny(9);

        _uiManager.SetState((int)UiManager.State.Game);
    }

    private void ClickButtonStage10()
    {
        Debug.Log("ClickButton Stage10");

        stageManager.GoStageAny(10);

        _uiManager.SetState((int)UiManager.State.Game);
    }

    private void ClickButtonStage11()
    {
        Debug.Log("ClickButton Stage11");

        stageManager.GoStageAny(11);

        _uiManager.SetState((int)UiManager.State.Game);
    }

    private void ClickButtonStage12()
    {
        Debug.Log("ClickButton Stage12");

        stageManager.GoStageAny(12);

        _uiManager.SetState((int)UiManager.State.Game);
    }

    private void ClickButtonStage13()
    {
        Debug.Log("ClickButton Stage13");

        stageManager.GoStageAny(13);

        _uiManager.SetState((int)UiManager.State.Game);
    }

    private void ClickButtonStage14()
    {
        Debug.Log("ClickButton Stage14");

        stageManager.GoStageAny(14);

        _uiManager.SetState((int)UiManager.State.Game);
    }

    private void ClickButtonStage15()
    {
        Debug.Log("ClickButton Stage15");

        stageManager.GoStageAny(15);

        _uiManager.SetState((int)UiManager.State.Game);
    }

    private void ClickButtonStage16()
    {
        Debug.Log("ClickButton Stage16");

        stageManager.GoStageAny(16);

        _uiManager.SetState((int)UiManager.State.Game);
    }

    private void ClickButtonStage17()
    {
        Debug.Log("ClickButton Stage17");

        stageManager.GoStageAny(17);

        _uiManager.SetState((int)UiManager.State.Game);
    }

    private void ClickButtonStage18()
    {
        Debug.Log("ClickButton Stage18");

        stageManager.GoStageAny(18);

        _uiManager.SetState((int)UiManager.State.Game);
    }

    private void ClickButtonStage19()
    {
        Debug.Log("ClickButton Stage19");

        stageManager.GoStageAny(19);

        _uiManager.SetState((int)UiManager.State.Game);
    }

    private void ClickButtonStage20()
    {
        Debug.Log("ClickButton Stage20");

        stageManager.GoStageAny(20);

        _uiManager.SetState((int)UiManager.State.Game);
    }
}
