using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


// ※セーブデータはAppData/LocalLow/GameTaisyo2021フォルダ内に生成される
// 中身を確認したい人はそこ見てね


// セーブデータクラス
[System.Serializable]
public class SaveData
{
    public StageData[] stageData;
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

    void Awake()
    {
        // ファイルパス指定
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

    // ステージ番号とデータ上の配列とのずれを考慮して-1

    // ステージのクリア状態のセッター
    public void StageClearSet(int num, bool clear)
    {
        saveData.stageData[num - 1].clear = clear;
    }

    // ステージのクリア状態のゲッター
    public bool StageClearGet(int num)
    {
        return saveData.stageData[num - 1].clear;
    }

    // ステージのアンロック状態のセッター
    public void StageUnlockSet(int num, bool unlocked)
    {
        saveData.stageData[num - 1].unlocked = unlocked;
    }

    // ステージのアンロック状態のゲッター
    public bool StageUnlockGet(int num)
    {
        return saveData.stageData[num - 1].unlocked;
    }

    // セーブ
    public void Save()
    {
        // JSONに変換
        string jsonString = JsonUtility.ToJson(saveData);

        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(jsonString);
        streamWriter.Flush();
        streamWriter.Close();

        Debug.Log(Application.persistentDataPath);
    }

    // ロード
    public void Load()
    {
        if (File.Exists(filePath))
        {
            StreamReader streamReader;
            streamReader = new StreamReader(filePath);
            string data = streamReader.ReadToEnd();
            streamReader.Close();

            // JSONからSavaDataクラスに変換
            saveData = JsonUtility.FromJson<SaveData>(data);
        }
    }

    // データリセット
    public void Reset()
    {
    }
}
