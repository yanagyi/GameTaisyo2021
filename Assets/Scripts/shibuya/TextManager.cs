using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    //表示するテキスト,背景画像
    public GameObject[] text;
    public GameObject image;
    //表示するテキストの選択
    public int textNumber;
    //大きさの上限
    public float uiChangeTime;

    public Vector3 textChangeSize, imageChangeSize;

    //今の大きさ
    float uiSize;
    //触れているかの判定
    bool flag;

    void Start()
    {
        uiSize = 0.0f;
    }

    void Update()
    {
        if(flag)
        {
            if(uiSize< uiChangeTime)
            {
                text[textNumber].transform.localScale += textChangeSize;
                image.transform.localScale += imageChangeSize;

                uiSize += 0.5f;
            }
        }
        else
        {
            if(uiSize>0)
            {
                text[textNumber].transform.localScale -= textChangeSize;
                image.transform.localScale -= imageChangeSize;

                uiSize -= 0.5f;
            }
        }
    }
    //オブジェクトが触れている間
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            flag = true;
            //text[textNumber].SetActive(true);
            //image.SetActive(true);

            //text[textNumber].transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            //image.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            //Debug.Log("見える");
        }
    }
    //オブジェクトが離れたら
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            flag = false;
            //text[textNumber].SetActive(false);
            //image.SetActive(false);
            //Debug.Log("見えない");
        }
    }
}