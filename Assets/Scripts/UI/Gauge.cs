using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    public Image[] Circles;

    // ループの有効
    public bool valid;

    // ゲージがなくなるか否か
    public float countTime = 5.0f;

    private float amount = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if (valid)
        {
            amount -= 1.0f / countTime * Time.deltaTime;
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
    }

    public void GaugeValid()
    {
        valid = true;
    }

    public float GetGauge()
    {
        return amount;
    }

    public void PlusAmount(float n)
    {
        amount += n;
    }
}
