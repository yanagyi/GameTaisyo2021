using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageManager : MonoBehaviour
{
    static int NowLevel;//現在のレベル。リトライ処理等で参照
    static int NextLevel;//Startで読み込むレベル。ロードシーン前にレベル変更処理
    public GameObject[] Stages;//ステージオブジェクトを格納する配列
    bool isStageClear;
    bool isStageFault;

    private GameObject fadeManagerObject;
    private Fade fadeManager;

    // Start is called before the first frame update
    void Awake()
    {
        fadeManagerObject = GameObject.Find("FadeManager");
        fadeManager = fadeManagerObject.GetComponent<Fade>();

        NowLevel = NextLevel;
        Debug.Log(NowLevel);
        //GameObject.Find("Main Camera").GetComponent<CameraControl>().SetCameraPos(NowLevel);
        Debug.Log("NowLevel::" + NowLevel+"@StageManager");
        ShowStage();

        fadeManager.FadeIn();
    }

    // Update is called once per frame
    void Update()
    {

    }
    int LevelToStageDataIndex(int level)
    {
        if (level <= 0)//マイナスになってしまわないように
            return 0;
        var stageLevel = level;//現在のステージレベル
        var max = Stages.Length;//ステージの個数
        if (stageLevel <= max - 1)//現在ステージが最終ステージイコール小なりであれば
            return stageLevel - 1;//引数をステージレベルとして返す
        //こっからなんだっけかな。わからん
        var tutorialStageNum = 1;
        var temp = (stageLevel - max) % (max - tutorialStageNum);
        if (temp == 0)
            temp = max - tutorialStageNum;
        stageLevel = (temp) + tutorialStageNum;

        return stageLevel - 1;
    }

    void ShowStage()
    {
     for(int i = 0; i < Stages.Length; i++) {
            Stages[i].SetActive(false);
        }
        Stages[NowLevel].SetActive(true);
    }//NowLevel以外のステージアクティブをfalseにする
    public void AdvanceGame()
    {
        if(NowLevel<Stages.Length)
        NextLevel += 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void BackGame()
    {
        if (NowLevel > 0)
            NextLevel -= 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 任意のステージを読み込む
    public void GoStageAny(int stageNum)
    {
        NextLevel = LevelToStageDataIndex(stageNum);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static int GetNowLevel()
    {
        return NowLevel;
    }

    public GameObject GetStageObject()
    {
        return Stages[NowLevel];
    }

    //デバッグ用------------------------------------------------------------------------------------------------------------|

    public void GoStage1()
    {
        NextLevel = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GoStage2()
    {
        NextLevel = 2;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GoStage3()
    {
        NextLevel = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public int GetStageIndex()
    {
        return (int)Stages.Length;
    }

}
