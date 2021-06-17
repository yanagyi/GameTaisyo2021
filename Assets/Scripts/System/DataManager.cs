using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


// Debug.Logでセーブデータの保存場所を表示しているのでみたい方はどうぞ


// セーブデータクラス
[System.Serializable]
public class SaveData
{
    public StageData[] stageData;

    public float volumeMaster;
    public float volumeBgm;
    public float volumeSe;
}

// ステージのクリア状態管理
[System.Serializable]
public class StageData
{
    // ステージ番号
    public int stageNum;
    // クリアしたかどうか
    public bool clear;
    // アンロックされているかどうか
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
        //fps固定をここでやらせてもらいましう。by kameyama
        //Application.targetFrameRate = 30;
        // ファイルパス指定
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

    // ステージのクリア状態のセッター
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

    // ステージのクリア状態のゲッター
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

    // ステージのアンロック状態のセッター
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

    // ステージのアンロック状態のゲッター
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

    // セーブ
    public void Save()
    {
        // スライダーから音量をゲット
        saveData.volumeMaster = volumeManager.GetMasterVolume();
        saveData.volumeBgm = volumeManager.GetBgmVolume();
        saveData.volumeSe = volumeManager.GetSeVolume();

        // JSONに変換
        string jsonString = JsonUtility.ToJson(saveData);

        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(jsonString);
        streamWriter.Flush();
        streamWriter.Close();

        //Debug.Log("「" + Application.persistentDataPath + "」にセーブしました");
    }

    // ロード
    public void Load()
    {
        // データが存在しない場合ロードしない
        if (File.Exists(filePath))
        {
            StreamReader streamReader;
            streamReader = new StreamReader(filePath);
            string data = streamReader.ReadToEnd();
            streamReader.Close();

            // JSONからSavaDataクラスに変換
            saveData = JsonUtility.FromJson<SaveData>(data);

            // スライダーに音量をセット
            volumeManager.SetMasterVolumeSliderValue(saveData.volumeMaster);
            volumeManager.SetBgmVolumeSliderValue(saveData.volumeBgm);
            volumeManager.SetSeVolumeSliderValue(saveData.volumeSe);
        }
    }

    // データリセット
    public void Reset()
    {
        // すべての数値を初期化
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

        // ここで上書きして初期化
        Save();
    }

    // デバッグ用
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
