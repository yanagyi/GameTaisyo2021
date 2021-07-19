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
    public GameObject[] Root;
    public UsableObject[] parentsScript;
    // Start is called before the first frame update
    void Start()
    {
        Zenmai = false;

        //��Ɨp�ϐ��ɑ��
        WpressTempo = pressTempo;

        //������Ԃ��ォ�������ʂ��ď������W�ƖڕW���W��ݒ肷��
        if (pressFlag) {
            startPos = transform.localPosition;
            targetPos = startPos + new Vector3(0.0f, -pressPos, 0.0f);
        } else {
            targetPos = transform.localPosition;
            startPos = targetPos + new Vector3(0.0f, pressPos, 0.0f);
        }
        for (int i = 0; i < Root.Length; i++) {

            parentsScript[i] = Root[i].GetComponent<UsableObject>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {
        for (int i = 0; i < Root.Length; i++) {
            if (parentsScript[i].isZenmai) {
                WpressTime = pressTime;
                WpressTempo--;

                //�v���X�����Ȃ��
                if (WpressTempo < 0) {
                    if (transform.localPosition == startPos)//�������W�ɂȂ�����v���X���Ă��Ȃ����
                    {
                        pressFlag = false;
                    }
                    if (transform.localPosition == targetPos)//�ڕW���W�ɂȂ�����v���X���Ă�����
                    {
                        pressFlag = true;
                    }
                    WpressTempo = pressTempo;
                }

                if (pressFlag)//�������W��ڎw���ē���
                {
                    transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, pressSpeed);
                } else//�ڕW���W��ڎw���ē���
                  {
                    transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, pressSpeed);
                }
            } else//�[���}�C�𔲂��Ă��c�莞�Ԃ�����Γ���������
              {
                if (WpressTime > 0) {
                    WpressTime--;
                    WpressTempo--;

                    //�v���X�����Ȃ��
                    if (WpressTempo < 0) {
                        if (transform.localPosition == startPos)//�������W�ɂȂ�����v���X���Ă��Ȃ����
                        {
                            pressFlag = false;
                        }
                        if (transform.localPosition == targetPos)//�ڕW���W�ɂȂ�����v���X���Ă�����
                        {
                            pressFlag = true;
                        }
                        WpressTempo = pressTempo;
                    }

                    if (pressFlag)//�������W��ڎw���ē���
                    {
                        transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, pressSpeed);
                    } else//�ڕW���W��ڎw���ē���
                      {
                        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, pressSpeed);
                    }
                }
            }
        }

    }
    public void PressFlag(bool isZenmai)//�I���I�t�𑼂̃X�N���v�g(PressManager.cs)���炢�����悤��
    {
        Zenmai=isZenmai;
    }
}
