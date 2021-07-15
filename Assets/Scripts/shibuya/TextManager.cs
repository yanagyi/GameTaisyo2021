using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    //�\������e�L�X�g,�w�i�摜
    public GameObject[] text;
    public GameObject image;
    //�\������e�L�X�g�̑I��
    public int textNumber;
    //�傫���̏��
    public float uiChangeTime;

    public Vector3 textChangeSize, imageChangeSize;

    //���̑傫��
    float uiSize;
    //�G��Ă��邩�̔���
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
    //�I�u�W�F�N�g���G��Ă����
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            flag = true;
            //text[textNumber].SetActive(true);
            //image.SetActive(true);

            //text[textNumber].transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            //image.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            //Debug.Log("������");
        }
    }
    //�I�u�W�F�N�g�����ꂽ��
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            flag = false;
            //text[textNumber].SetActive(false);
            //image.SetActive(false);
            //Debug.Log("�����Ȃ�");
        }
    }
}