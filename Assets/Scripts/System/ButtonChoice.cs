using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UI�g���Ƃ��ɕK�v
using UnityEngine.UI;

public class ButtonChoice : MonoBehaviour
{
    Button button;

    void Start()
    {

        button = GameObject.Find("ClearCanvas/ButtonSummary/Yes").GetComponent<Button>();
        //�{�^�����I�����ꂽ��ԂɂȂ�
        button.Select();

    }
}