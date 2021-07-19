using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle_Root : UsableObject
{
    // Start is called before the first frame update
    public GameObject circleObj;
    circle circleScript;

    public bool controlFlag;//プレイヤーが操作状態（ゼンマイが刺さっている）かどうか
    public GameObject SoundObject;//SE用
    float SeTempo;//繰り返しSeを鳴らすための変数
    void Start()
    {
        isZenmai = false;
        circleScript = circleObj.GetComponent<circle>();


        controlFlag = false;
        isZenmai = false;
        SoundObject = GameObject.Find("SoundManager");
    }

    // Update is called once per frame
    void Update()
    {

        if (isZenmai == false)
            return;
      
        circleScript.MoveOn();
    }
}
