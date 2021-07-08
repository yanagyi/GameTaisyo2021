using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressManager : UsableObject
{
    public GameObject[] press;
    piston[] pistonScript;

    // Start is called before the first frame update
    void Start()
    {
        isZenmai = false;

        //プレス機(プレスする部分)、スクリプトを取得　
        pistonScript = new piston[press.Length];
        for (int i = 0; i < press.Length; i++)
        {
            pistonScript[i] = press[i].GetComponent<piston>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ゼンマイが刺さっていれば対応しているプレス機を稼働させる
        for (int i = 0; i < press.Length; i++)
        {
            pistonScript[i].PressFlag(isZenmai);
        }
    }

    
    
}
