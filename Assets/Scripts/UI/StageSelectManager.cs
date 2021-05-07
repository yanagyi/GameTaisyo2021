using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StageSelectManager : MonoBehaviour
{
    public GameObject dataObject;
    private DataManager dataManager;

    [SerializeField]
    private EventSystem eventSystem;
    private Button selectButton;

    float time;
    float timeLength;

    int stageNum;
    bool nowMove;

    // trueÇ™ç∂ÅAfalseÇ™âE
    bool directionLR;

    bool setPos;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        timeLength = 50.0f;
        stageNum = 0;
        nowMove = false;
        directionLR = false;

        dataManager = dataObject.GetComponent<DataManager>();

        for (int i = 1; i <= 21; i++)
        {
            if(i == 21)
            {
                stageNum = 20;
                transform.position = new Vector3(-stageNum * 1200.0f + 720.0f, 540.0f, 0);
                break;
            }
            if (!dataManager.GetStageUnlock(i))
            {
                stageNum = i - 2;
                transform.position = new Vector3(-stageNum * 1200.0f + 720.0f, 540.0f, 0);
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        dataManager.SetStageUnlock(2, true);

        if (nowMove)
        {
            if (directionLR)
            {
                transform.position = new Vector3(Easing.CubicInOut(time, timeLength, 0, 1200.0f) + -stageNum * 1200.0f + 720.0f, 540.0f, 0);
            }
            else
            {
                transform.position = new Vector3(-Easing.CubicInOut(time, timeLength, 0, 1200.0f) + -stageNum * 1200.0f + 720.0f, 540.0f, 0);
            }

            time += 1.0f;
        }

        if (timeLength < time)
        {
            time = 0.0f;
            nowMove = false;

            eventSystem.enabled = true;
            selectButton.Select();

            if (directionLR)
            {
                stageNum--;
            }
            else
            {
                stageNum++;
            }
        }

        if (!nowMove && Input.GetAxis("Horizontal") < 0 && stageNum > 0)
        {
            nowMove = true;
            directionLR = true;
            selectButton = this.transform.GetChild(stageNum - 1).gameObject.GetComponent<Button>();
            eventSystem.enabled = false;

        }
        if (!nowMove && Input.GetAxis("Horizontal") > 0 && stageNum < 19 && dataManager.GetStageUnlock(stageNum + 2))
        {
            nowMove = true;
            directionLR = false;
            selectButton = this.transform.GetChild(stageNum + 1).gameObject.GetComponent<Button>();
            eventSystem.enabled = false;

        }

        dataManager.Save();
    }
}
