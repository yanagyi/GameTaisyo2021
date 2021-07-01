using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    public Image[] Circles;

    // ���[�v�̗L��
    public bool valid;

    // �[���}�C�g�p�t���O
    public bool zenmai = false;

    // �[���}�C�g�p���̃Q�[�W����(�{)
    public float speedDouble = 2.0f;

    // �Q�[�W���Ȃ��Ȃ�܂ł̎���
    public float countTime = 5.0f;

    // �Q�[�W�̌������x
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

        // ������Player�̃X�e�[�g���m�F���ăt���O���X�V
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
    
    // �Q�[�W�̗L����
    public void GaugeValid()
    {
        valid = true;
    }

    // �Q�[�W�ʂ��擾
    public float GetGauge()
    {
        return amount;
    }

    // �Q�[�W�񕜗p�֐�
    public void PlusAmount(float n)
    {
        amount += n;
    }
}
