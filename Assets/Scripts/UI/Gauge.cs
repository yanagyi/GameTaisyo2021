using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    public Image[] Circles;

    // ループの有効
    public bool valid;

    // ゼンマイ使用フラグ
    public bool zenmai = false;

    // ゼンマイ使用時のゲージ減少(倍)
    public float speedDouble = 2.0f;

    // ゲージがなくなるまでの時間
    public float countTime = 5.0f;

    // ゲージの減少速度
    public float speed = 1.0f;

    private float amount = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if (valid)
        {
            if(zenmai)
            {
                amount -= (1.0f / countTime * Time.deltaTime) * speed * speedDouble;
            }
            else
            {
                amount -= (1.0f / countTime * Time.deltaTime) * speed;
            }

            Circles[0].fillAmount = amount;
            Circles[1].fillAmount = amount;
            Circles[2].fillAmount = amount;

            if (amount < 0.5f)
            {
                Circles[0].enabled = false;
            }
            else
            {
                Circles[0].enabled = true;
            }

            if (amount < 0.25f)
            {
                Circles[1].enabled = false;
            }
            else
            {
                Circles[1].enabled = true;
            }
        }

        if(amount < 0.0f)
        {
            amount = 0;
        }

        // ここでPlayerのステートを確認してフラグを更新
        /*
        if(false)
        {
            zenmai = true;
        }
        else
        {
            zenmai = false;
        }
        */
    }
    
    // ゲージの有効化
    public void GaugeValid()
    {
        valid = true;
    }

    // ゲージ量を取得
    public float GetGauge()
    {
        return amount;
    }

    // ゲージ回復用関数
    public void PlusAmount(float n)
    {
        amount += n;
    }
}
