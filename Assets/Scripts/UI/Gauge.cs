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
        if (SceneManager.GetActiveScene().name == "Brush_Up" /*|| SceneManager.GetActiveScene().name == "�v���C���[���e�X�g���Ă���V�[����" */)
        {
            playerScript = player_.GetComponent<player>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "master" || SceneManager.GetActiveScene().name == "Uchiike")
        {
            amount -= (1.0f / 180.0f * Time.deltaTime) * 1.0f;
        }
        if (SceneManager.GetActiveScene().name == "Brush_Up" /*|| SceneManager.GetActiveScene().name == "�v���C���[���e�X�g���Ă���V�[����" */)
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
