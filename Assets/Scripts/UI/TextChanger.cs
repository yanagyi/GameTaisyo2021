using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    private ButtonBase script;
    private Text targetText;

    // Start is called before the first frame update
    void Start()
    {
        script = this.GetComponent<ButtonBase>();
        targetText = this.transform.Find("Text").GetComponent<Text>();
        targetText.text = "ステージ" + script.stageNum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
