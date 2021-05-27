using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Fade : MonoBehaviour
{
    //�t�F�[�h�p��Image
    public Image fadeImage;

    static Color ChColor = Color.clear;

    //�t�F�[�h�pImage�̓����x
    private static float alpha = 1.0f;

    //�t�F�[�h�C���A�E�g�̃t���O
    public static bool isFadeIn = false;
    public static bool isFadeOut = false;
    public static bool isChangeColor = false;

    //�t�F�[�h���x
    public float fadeSpeed;

    //�t�F�[�h�p��Canvas��Image����
    void Init()
    {
    }

    //�t�F�[�h�C���J�n
    public void FadeIn()
    {
        alpha = 1.0f;
        fadeImage.enabled = true;
        fadeImage.color = Color.black;
        isFadeIn = true;

        //�C�x���g�V�X�e���擾
        var eventSystem = GameObject.FindObjectOfType<EventSystem>();
        eventSystem.enabled = false;
    }

    //�t�F�[�h�A�E�g�J�n
    public void FadeOut()
    {
        alpha = 0.0f;
        fadeImage.enabled = true;
        fadeImage.color = Color.clear;
        isFadeOut = true;

        //�C�x���g�V�X�e���擾
        var eventSystem = GameObject.FindObjectOfType<EventSystem>();
        eventSystem.enabled = false;
    }

    //�t�F�[�h�A�E�g(�F�w��)�J�n
    public void ColorFadeOut(Color nColor)
    {
        alpha = 0.0f;
        fadeImage.enabled = true;
        fadeImage.color = Color.clear;
        ChColor = nColor;
        isFadeOut = true;
        isChangeColor = true;

        //�C�x���g�V�X�e���擾
        var eventSystem = GameObject.FindObjectOfType<EventSystem>();
        eventSystem.enabled = false;
    }

    void Update()
    {
        //�t���O�L���Ȃ疈�t���[���t�F�[�h�C��/�A�E�g����
        if (isFadeIn)
        {
            alpha -= fadeSpeed * Time.deltaTime;

            //�t�F�[�h�C���I������
            if (alpha <= 0.0f)
            {
                isFadeIn = false;
                alpha = 0.0f;
                fadeImage.enabled = false;

                //�C�x���g�V�X�e���擾
                var eventSystem = GameObject.FindObjectOfType<EventSystem>();
                eventSystem.enabled = true;

                if (isChangeColor)
                {
                    isChangeColor = false;
                }
            }

            if (isChangeColor)
            {
                //�t�F�[�h�pImage�̐F�E�����x�ݒ�
                fadeImage.color = new Color(ChColor.r, ChColor.g, ChColor.b, alpha);
            }
            else
            {
                //�t�F�[�h�pImage�̐F�E�����x�ݒ�
                fadeImage.color = new Color(0.0f, 0.0f, 0.0f, alpha);
            }
        }
        else if (isFadeOut)
        {
            alpha += fadeSpeed * Time.deltaTime;

            //�t�F�[�h�A�E�g�I������
            if (alpha >= 1.0f)
            {
                isFadeOut = false;
                alpha = 1.0f;

            }

            if (isChangeColor)
            {
                //�t�F�[�h�pImage�̐F�E�����x�ݒ�
                fadeImage.color = new Color(ChColor.r, ChColor.g, ChColor.b, alpha);
            }
            else
            {
                //�t�F�[�h�pImage�̐F�E�����x�ݒ�
                fadeImage.color = new Color(0.0f, 0.0f, 0.0f, alpha);
            }
        }
    }
}