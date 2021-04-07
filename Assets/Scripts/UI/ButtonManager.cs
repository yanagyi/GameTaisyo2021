using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ButtonBaseクラスから継承しここで処理
public class ButtonManager : ButtonBase
{
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
        else if ("ButtonBack".Equals(objectName))
        {
            this.ClickButtonBack();
        }
        else if ("ButtonTitleBack".Equals(objectName))
        {
            this.ClickButtonTitleBack();
        }
        else if ("ButtonRetry".Equals(objectName))
        {
            this.ClickButtonRetry();
        }
        else if ("ButtonConfig".Equals(objectName))
        {
            this.ClickButtonConfig();
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

    private void ClickButtonBack()
    {
        Debug.Log("ClickButton Back");
    }

    private void ClickButtonTitleBack()
    {
        Debug.Log("ClickButton TitleBack");
    }

    private void ClickButtonRetry()
    {
        Debug.Log("ClickButton Retry");
    }

    private void ClickButtonConfig()
    {
        Debug.Log("ClickButton Config");
    }

    private void ClickButtonYes()
    {
        Debug.Log("ClickButton Yes");
    }

    private void ClickButtonNo()
    {
        Debug.Log("ClickButton No");
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
