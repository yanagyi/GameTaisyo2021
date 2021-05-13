using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    Text targetText;

    // Start is called before the first frame update
    void Start()
    {
        targetText = this.transform.Find("Text").GetComponent<Text>();

        if ("ButtonStage1".Equals(gameObject.name))
        {
            targetText.text = "ステージ1";
        }
        if ("ButtonStage2".Equals(gameObject.name))
        {
            targetText.text = "ステージ2";
        }
        if ("ButtonStage3".Equals(gameObject.name))
        {
            targetText.text = "ステージ3";
        }
        if ("ButtonStage4".Equals(gameObject.name))
        {
            targetText.text = "ステージ4";
        }
        if ("ButtonStage5".Equals(gameObject.name))
        {
            targetText.text = "ステージ5";
        }
        if ("ButtonStage6".Equals(gameObject.name))
        {
            targetText.text = "ステージ6";
        }
        if ("ButtonStage7".Equals(gameObject.name))
        {
            targetText.text = "ステージ7";
        }
        if ("ButtonStage8".Equals(gameObject.name))
        {
            targetText.text = "ステージ8";
        }
        if ("ButtonStage9".Equals(gameObject.name))
        {
            targetText.text = "ステージ9";
        }
        if ("ButtonStage10".Equals(gameObject.name))
        {
            targetText.text = "ステージ10";
        }
        if ("ButtonStage11".Equals(gameObject.name))
        {
            targetText.text = "ステージ11";
        }
        if ("ButtonStage12".Equals(gameObject.name))
        {
            targetText.text = "ステージ12";
        }
        if ("ButtonStage13".Equals(gameObject.name))
        {
            targetText.text = "ステージ13";
        }
        if ("ButtonStage14".Equals(gameObject.name))
        {
            targetText.text = "ステージ14";
        }
        if ("ButtonStage15".Equals(gameObject.name))
        {
            targetText.text = "ステージ15";
        }
        if ("ButtonStage16".Equals(gameObject.name))
        {
            targetText.text = "ステージ16";
        }
        if ("ButtonStage17".Equals(gameObject.name))
        {
            targetText.text = "ステージ17";
        }
        if ("ButtonStage18".Equals(gameObject.name))
        {
            targetText.text = "ステージ18";
        }
        if ("ButtonStage19".Equals(gameObject.name))
        {
            targetText.text = "ステージ19";
        }
        if ("ButtonStage20".Equals(gameObject.name))
        {
            targetText.text = "ステージ20";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
