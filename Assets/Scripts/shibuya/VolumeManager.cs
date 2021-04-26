using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    //オーディオミキサー参照
    public AudioMixer audioMixer;

    //スライダー参照
    public Slider MasterVolumeSlider;
    public Slider BgmVolumeSlider;
    public Slider SeVolumeSlider;

    //スライダー選択用変数
    int select;

    // Start is called before the first frame update
    void Start()
    {
        //選択用変数初期化  
        select = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //スライダーの選択
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetAxis("Vertical") > 0)
                select--;
            if (Input.GetKeyDown(KeyCode.S) || Input.GetAxis("Vertical") < 0)
                select++;
            if (select < 0)
                select = 0;
            if (select > 2)
                select = 2;
        }

        //ボリュームを上げる
        if (Input.GetKeyDown(KeyCode.D) || Input.GetAxis("Horizontal") > 0)
        {
            switch (select)
            {
                //MASTER選択時
                case 0:
                    MasterVolumeSlider.value += 0.1f;
                    break;
                //BGM選択時
                case 1:
                    BgmVolumeSlider.value += 0.1f;
                    break;
                //SE選択時
                case 2:
                    SeVolumeSlider.value += 0.1f;
                    break;
            }
        }

        //ボリュームを下げる
        if (Input.GetKeyDown(KeyCode.A)|| Input.GetAxis("Horizontal") < 0)
        {
            switch (select)
            {
                //MASTER選択時
                case 0:
                    MasterVolumeSlider.value -= 0.1f;
                    break;
                //BGM選択時
                case 1:
                    BgmVolumeSlider.value -= 0.1f;
                    break;
                //SE選択時
                case 2:
                    SeVolumeSlider.value -= 0.1f;
                    break;
            }
        }

    }

    //音量（デシベル）を0~1で簡単に表せるようにする関数
    public float ConvertVolumeToDb(float volume)
    {
        return Mathf.Clamp(Mathf.Log10(Mathf.Clamp(volume, 0f, 1f)) * 20f, -80f, 0f);
    }

    //音量をスライダーのボリュームに合わせて変更する関数
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MASTER", ConvertVolumeToDb(MasterVolumeSlider.value));
    }
    public void SetBgmVolume(float volume)
    {
        audioMixer.SetFloat("BGM", ConvertVolumeToDb(BgmVolumeSlider.value));
    }
    public void SetSeVolume(float volume)
    {
        audioMixer.SetFloat("SE", ConvertVolumeToDb(SeVolumeSlider.value));
    }
}