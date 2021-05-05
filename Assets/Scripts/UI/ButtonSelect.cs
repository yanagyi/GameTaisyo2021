using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 親オブジェクト(UI)を表示したときにボタンを選択するスクリプト

public class ButtonSelect : MonoBehaviour
{
    public GameObject parentObject;
    public Button button;
    public Slider slider;

    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (parentObject.activeSelf && !flag)
        {
            if(button != null)
            {
                button.Select();
            }
            if(slider != null)
            {
                slider.Select();
            }
            flag = true;
        }
        if (!parentObject.activeSelf)
        {
            flag = false;
        }
    }
}
