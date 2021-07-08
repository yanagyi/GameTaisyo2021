using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piston : MonoBehaviour
{
    public bool Zenmai;
    public float pressTime;//�[���}�C�𔲂��Ă��牽�b�ԓ��������邩
    float WpressTime;//��Ɨp�ϐ�

    public float pressTempo;//�v���X�������
    float WpressTempo;//�����v�Z�p

    public float pressSpeed;//�v���X���鑬��(�ォ�牺�܂�
    public float pressPos;//�ǂꂾ���v���X���邩�i����

    public bool pressFlag;//�v���X���Ă��邩�ǂ���

    Vector3 startPos, targetPos;//�������W�ƖڕW�̍��W�@���̓����������

    // Start is called before the first frame update
    void Start()
    {
        Zenmai = false;

        //��Ɨp�ϐ��ɑ��
        WpressTempo = pressTempo;

        //������Ԃ��ォ�������ʂ��ď������W�ƖڕW���W��ݒ肷��
        if (pressFlag)
        {
            startPos = transform.position;
            targetPos = startPos + new Vector3(0.0f, -pressPos, 0.0f);
        }
        else
        {
            targetPos = transform.position;
            startPos = targetPos + new Vector3(0.0f, pressPos, 0.0f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Zenmai)
        {
            WpressTime = pressTime;
            WpressTempo--;

            //�v���X�����Ȃ��
            if (WpressTempo < 0)
            {
                if (transform.position == startPos)//�������W�ɂȂ�����v���X���Ă��Ȃ����
                {
                    pressFlag = false;
                }
                if (transform.position == targetPos)//�ڕW���W�ɂȂ�����v���X���Ă�����
                {
                    pressFlag = true;
                }
                WpressTempo = pressTempo;
            }

            if (pressFlag)//�������W��ڎw���ē���
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos, pressSpeed);
            }
            else//�ڕW���W��ڎw���ē���
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, pressSpeed);
            }
        }
        else//�[���}�C�𔲂��Ă��c�莞�Ԃ�����Γ���������
        {
            if(WpressTime>0)
            {
                WpressTime--;
                WpressTempo--;

                //�v���X�����Ȃ��
                if (WpressTempo < 0)
                {
                    if (transform.position == startPos)//�������W�ɂȂ�����v���X���Ă��Ȃ����
                    {
                        pressFlag = false;
                    }
                    if (transform.position == targetPos)//�ڕW���W�ɂȂ�����v���X���Ă�����
                    {
                        pressFlag = true;
                    }
                    WpressTempo = pressTempo;
                }

                if (pressFlag)//�������W��ڎw���ē���
                {
                    transform.position = Vector3.MoveTowards(transform.position, startPos, pressSpeed);
                }
                else//�ڕW���W��ڎw���ē���
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPos, pressSpeed);
                }
            }
        }
    }

    public void PressFlag(bool isZenmai)//�I���I�t�𑼂̃X�N���v�g(PressManager.cs)���炢�����悤��
    {
        Zenmai=isZenmai;
    }
}
