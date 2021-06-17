using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


// Debug.Log�ŃZ�[�u�f�[�^�̕ۑ��ꏊ��\�����Ă���̂ł݂������͂ǂ���


// �Z�[�u�f�[�^�N���X
[System.Serializable]
public class SaveData
{
    public StageData[] stageData;

    public float volumeMaster;
    public float volumeBgm;
    public float volumeSe;
}

// �X�e�[�W�̃N���A��ԊǗ�
[System.Serializable]
public class StageData
{
    // �X�e�[�W�ԍ�
    public int stageNum;
    // �N���A�������ǂ���
    public bool clear;
    // �A�����b�N����Ă��邩�ǂ���
    public bool unlocked;
}

public class DataManager : MonoBehaviour
{
    private string filePath;
    private SaveData saveData;

    private GameObject volumeManagerObject;
    private VolumeManager volumeManager;

    void Awake()
    {
        //fps�Œ�������ł�点�Ă��炢�܂����Bby kameyama
        //Application.targetFrameRate = 30;
        // �t�@�C���p�X�w��
        filePath = Application.persistentDataPath + "/savedata.json";
        saveData = new SaveData();
        saveData.stageData = new StageData[22];

        volumeManagerObject = GameObject.Find("VolumeManager");
        volumeManager = volumeManagerObject.GetComponent<VolumeManager>();

        saveData.volumeMaster = 0.5f;
        saveData.volumeBgm = 0.5f;
        saveData.volumeSe = 0.5f;

        for (int i = 0; i < saveData.stageData.Length; i++)
        {
            saveData.stageData[i] = new StageData();
            saveData.stageData[i].stageNum = i + 1;
            saveData.stageData[i].clear = false;

            if(i == 0)
            {
                saveData.stageData[i].unlocked = true;
            }
            else
            {
                saveData.stageData[i].unlocked = false;
            }
        }
    }

    // �X�e�[�W�̃N���A��Ԃ̃Z�b�^�[
    public void SetStageClear(int num, bool clear)
    {
        for(int i = 0; i < saveData.stageData.Length; i++)
        {
            if(saveData.stageData[i].stageNum == num)
            {
                saveData.stageData[i].clear = clear;
                break;
            }
        }
    }

    // �X�e�[�W�̃N���A��Ԃ̃Q�b�^�[
    public bool GetStageClear(int num)
    {
        for (int i = 0; i < saveData.stageData.Length; i++)
        {
            if (saveData.stageData[i].stageNum == num)
            {
                return saveData.stageData[i].clear;
            }
        }

        return false;
    }

    // �X�e�[�W�̃A�����b�N��Ԃ̃Z�b�^�[
    public void SetStageUnlock(int num, bool unlocked)
    {
        for (int i = 0; i < saveData.stageData.Length; i++)
        {
            if (saveData.stageData[i].stageNum == num)
            {
                saveData.stageData[i].unlocked = unlocked;
                break;
            }
        }
    }

    // �X�e�[�W�̃A�����b�N��Ԃ̃Q�b�^�[
    public bool GetStageUnlock(int num)
    {
        for (int i = 0; i < saveData.stageData.Length; i++)
        {
            if (saveData.stageData[i].stageNum == num)
            {
                return saveData.stageData[i].unlocked;
            }
        }

        return false;
    }

    // �Z�[�u
    public void Save()
    {
        // �X���C�_�[���特�ʂ��Q�b�g
        saveData.volumeMaster = volumeManager.GetMasterVolume();
        saveData.volumeBgm = volumeManager.GetBgmVolume();
        saveData.volumeSe = volumeManager.GetSeVolume();

        // JSON�ɕϊ�
        string jsonString = JsonUtility.ToJson(saveData);

        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(jsonString);
        streamWriter.Flush();
        streamWriter.Close();

        //Debug.Log("�u" + Application.persistentDataPath + "�v�ɃZ�[�u���܂���");
    }

    // ���[�h
    public void Load()
    {
        // �f�[�^�����݂��Ȃ��ꍇ���[�h���Ȃ�
        if (File.Exists(filePath))
        {
            StreamReader streamReader;
            streamReader = new StreamReader(filePath);
            string data = streamReader.ReadToEnd();
            streamReader.Close();

            // JSON����SavaData�N���X�ɕϊ�
            saveData = JsonUtility.FromJson<SaveData>(data);

            // �X���C�_�[�ɉ��ʂ��Z�b�g
            volumeManager.SetMasterVolumeSliderValue(saveData.volumeMaster);
            volumeManager.SetBgmVolumeSliderValue(saveData.volumeBgm);
            volumeManager.SetSeVolumeSliderValue(saveData.volumeSe);
        }
    }

    // �f�[�^���Z�b�g
    public void Reset()
    {
        // ���ׂĂ̐��l��������
        saveData.volumeMaster = 0.5f;
        saveData.volumeBgm = 0.5f;
        saveData.volumeSe = 0.5f;

        for (int i = 0; i < saveData.stageData.Length; i++)
        {
            saveData.stageData[i].clear = false;

            if (i == 0)
            {
                saveData.stageData[i].unlocked = true;
            }
            else
            {
                saveData.stageData[i].unlocked = false;
            }
        }

        // �����ŏ㏑�����ď�����
        Save();
    }

    // �f�o�b�O�p
    public void AllUnlock()
    {
        for (int i = 0; i < saveData.stageData.Length; i++)
        {
            saveData.stageData[i].clear = true;
            saveData.stageData[i].unlocked = true;
        }

        Save();
    }
}
