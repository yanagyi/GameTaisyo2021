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
    public GameObject dataObject;
    private DataManager dataManager;
    private StageSelectManager stageSelectManager;

    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        flag = false;

        if (parentObject.name == "Stage")
        {
            dataManager = dataObject.GetComponent<DataManager>();
            stageSelectManager = parentObject.GetComponent<StageSelectManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (parentObject.activeSelf && !flag)
        {
            if(parentObject.name == "Stage")
            {
                for(int i = 1; i <= 21; i++)
                {
                    if (i == 21)
                    {
                        button = parentObject.transform.GetChild(19).gameObject.GetComponent<Button>();
                        button.Select();
                        break;
                    }
                    if (!dataManager.GetStageUnlock(i))
                    {
                        button = parentObject.transform.GetChild(i - 1).gameObject.GetComponent<Button>();
                        button.Select();
                        break;
                    }
                }
            }
            else
            {
                if (button != null)
                {
                    button.Select();
                }
                if (slider != null)
                {
                    slider.Select();
                }
            }
            flag = true;
        }
        if (!parentObject.activeSelf)
        {
            flag = false;
        }
    }
}
