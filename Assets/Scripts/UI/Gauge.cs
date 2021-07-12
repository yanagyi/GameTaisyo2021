using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gauge : MonoBehaviour
{
    public Image[] Circles;

    public GameObject player_;
    private player playerScript;

    private float amount = 1.0f;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "BrushUp" /*|| SceneManager.GetActiveScene().name == "プレイヤーをテストしているシーン名" */)
        {
            playerScript = player_.GetComponent<player>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ゲージの動きを確認するためにplayer.csを利用していないシーンでも動作する
        if (SceneManager.GetActiveScene().name == "master" || SceneManager.GetActiveScene().name == "Uchiike")
        {
            amount -= (1.0f / 180.0f * Time.deltaTime) * 1.0f;
        }
        if (SceneManager.GetActiveScene().name == "BrushUp" /*|| SceneManager.GetActiveScene().name == "プレイヤーをテストしているシーン名" */)
        {
            amount = playerScript.GetBattery();
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
}
