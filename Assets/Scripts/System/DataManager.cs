using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


// ���Z�[�u�f�[�^��AppData/LocalLow/GameTaisyo2021�t�H���_���ɐ��������
// ���g���m�F�������l�͂������Ă�


// �Z�[�u�f�[�^�N���X
[System.Serializable]
public class SaveData
{
    public StageData[] stageData;
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

    void Awake()
    {
        // �t�@�C���p�X�w��
        filePath = Application.persistentDataPath + "/savedata.json";
        saveData = new SaveData();
        saveData.stageData = new StageData[20];

        for(int i = 0; i < saveData.stageData.Length; i++)
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

    // �X�e�[�W�ԍ��ƃf�[�^��̔z��Ƃ̂�����l������-1

    // �X�e�[�W�̃N���A��Ԃ̃Z�b�^�[
    public void StageClearSet(int num, bool clear)
    {
        saveData.stageData[num - 1].clear = clear;
    }

    // �X�e�[�W�̃N���A��Ԃ̃Q�b�^�[
    public bool StageClearGet(int num)
    {
        return saveData.stageData[num - 1].clear;
    }

    // �X�e�[�W�̃A�����b�N��Ԃ̃Z�b�^�[
    public void StageUnlockSet(int num, bool unlocked)
    {
        saveData.stageData[num - 1].unlocked = unlocked;
    }

    // �X�e�[�W�̃A�����b�N��Ԃ̃Q�b�^�[
    public bool StageUnlockGet(int num)
    {
        return saveData.stageData[num - 1].unlocked;
    }

    // �Z�[�u
    public void Save()
    {
        // JSON�ɕϊ�
        string jsonString = JsonUtility.ToJson(saveData);

        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(jsonString);
        streamWriter.Flush();
        streamWriter.Close();

        Debug.Log(Application.persistentDataPath);
    }

    // ���[�h
    public void Load()
    {
        if (File.Exists(filePath))
        {
            StreamReader streamReader;
            streamReader = new StreamReader(filePath);
            string data = streamReader.ReadToEnd();
            streamReader.Close();

            // JSON����SavaData�N���X�ɕϊ�
            saveData = JsonUtility.FromJson<SaveData>(data);
        }
    }

    // �f�[�^���Z�b�g
    public void Reset()
    {
    }
}
