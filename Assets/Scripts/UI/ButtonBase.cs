using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ボタン共通化用クラス
public class ButtonBase : MonoBehaviour
{
    public ButtonBase button;

    public void OnClick()
    {
        if (button == null)
        {
            throw new System.Exception("Button Instance Null");
        }
        // ボタンの名前を取得
        button.OnClick(this.gameObject.name);
    }

    protected virtual void OnClick(string objectName)
    {
    }
}
