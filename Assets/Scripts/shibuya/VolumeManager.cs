using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    //�I�[�f�B�I�~�L�T�[�Q��
    public AudioMixer audioMixer;

    //�X���C�_�[�Q��
    public Slider MasterVolumeSlider;
    public Slider BgmVolumeSlider;
    public Slider SeVolumeSlider;

    //�X���C�_�[�I��p�ϐ�
    int select;

    // Start is called before the first frame update
    void Start()
    {
        //�I��p�ϐ�������  
        select = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //�X���C�_�[�̑I��
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

        //�{�����[�����グ��
        if (Input.GetKeyDown(KeyCode.D) || Input.GetAxis("Horizontal") > 0)
        {
            switch (select)
            {
                //MASTER�I����
                case 0:
                    MasterVolumeSlider.value += 0.1f;
                    break;
                //BGM�I����
                case 1:
                    BgmVolumeSlider.value += 0.1f;
                    break;
                //SE�I����
                case 2:
                    SeVolumeSlider.value += 0.1f;
                    break;
            }
        }

        //�{�����[����������
        if (Input.GetKeyDown(KeyCode.A)|| Input.GetAxis("Horizontal") < 0)
        {
            switch (select)
            {
                //MASTER�I����
                case 0:
                    MasterVolumeSlider.value -= 0.1f;
                    break;
                //BGM�I����
                case 1:
                    BgmVolumeSlider.value -= 0.1f;
                    break;
                //SE�I����
                case 2:
                    SeVolumeSlider.value -= 0.1f;
                    break;
            }
        }

    }

    //���ʁi�f�V�x���j��0~1�ŊȒP�ɕ\����悤�ɂ���֐�
    public float ConvertVolumeToDb(float volume)
    {
        return Mathf.Clamp(Mathf.Log10(Mathf.Clamp(volume, 0f, 1f)) * 20f, -80f, 0f);
    }

    //���ʂ��X���C�_�[�̃{�����[���ɍ��킹�ĕύX����֐�
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