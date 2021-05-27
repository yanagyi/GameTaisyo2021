using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Fade : MonoBehaviour
{
    //フェード用のImage
    public Image fadeImage;

    static Color ChColor = Color.clear;

    //フェード用Imageの透明度
    private static float alpha = 1.0f;

    //フェードインアウトのフラグ
    public static bool isFadeIn = false;
    public static bool isFadeOut = false;
    public static bool isChangeColor = false;

    //フェード速度
    public float fadeSpeed;

    //フェード用のCanvasとImage生成
    void Init()
    {
    }

    //フェードイン開始
    public void FadeIn()
    {
        alpha = 1.0f;
        fadeImage.enabled = true;
        fadeImage.color = Color.black;
        isFadeIn = true;

        //イベントシステム取得
        var eventSystem = GameObject.FindObjectOfType<EventSystem>();
        eventSystem.enabled = false;
    }

    //フェードアウト開始
    public void FadeOut()
    {
        alpha = 0.0f;
        fadeImage.enabled = true;
        fadeImage.color = Color.clear;
        isFadeOut = true;

        //イベントシステム取得
        var eventSystem = GameObject.FindObjectOfType<EventSystem>();
        eventSystem.enabled = false;
    }

    //フェードアウト(色指定)開始
    public void ColorFadeOut(Color nColor)
    {
        alpha = 0.0f;
        fadeImage.enabled = true;
        fadeImage.color = Color.clear;
        ChColor = nColor;
        isFadeOut = true;
        isChangeColor = true;

        //イベントシステム取得
        var eventSystem = GameObject.FindObjectOfType<EventSystem>();
        eventSystem.enabled = false;
    }

    void Update()
    {
        //フラグ有効なら毎フレームフェードイン/アウト処理
        if (isFadeIn)
        {
            alpha -= fadeSpeed * Time.deltaTime;

            //フェードイン終了判定
            if (alpha <= 0.0f)
            {
                isFadeIn = false;
                alpha = 0.0f;
                fadeImage.enabled = false;

                //イベントシステム取得
                var eventSystem = GameObject.FindObjectOfType<EventSystem>();
                eventSystem.enabled = true;

                if (isChangeColor)
                {
                    isChangeColor = false;
                }
            }

            if (isChangeColor)
            {
                //フェード用Imageの色・透明度設定
                fadeImage.color = new Color(ChColor.r, ChColor.g, ChColor.b, alpha);
            }
            else
            {
                //フェード用Imageの色・透明度設定
                fadeImage.color = new Color(0.0f, 0.0f, 0.0f, alpha);
            }
        }
        else if (isFadeOut)
        {
            alpha += fadeSpeed * Time.deltaTime;

            //フェードアウト終了判定
            if (alpha >= 1.0f)
            {
                isFadeOut = false;
                alpha = 1.0f;

            }

            if (isChangeColor)
            {
                //フェード用Imageの色・透明度設定
                fadeImage.color = new Color(ChColor.r, ChColor.g, ChColor.b, alpha);
            }
            else
            {
                //フェード用Imageの色・透明度設定
                fadeImage.color = new Color(0.0f, 0.0f, 0.0f, alpha);
            }
        }
    }
}