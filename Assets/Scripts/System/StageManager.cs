using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageManager : MonoBehaviour
{
    static int NowLevel;//���݂̃��x���B���g���C�������ŎQ��
    static int NextLevel;//Start�œǂݍ��ރ��x���B���[�h�V�[���O�Ƀ��x���ύX����
    public GameObject[] Stages;//�X�e�[�W�I�u�W�F�N�g���i�[����z��
    bool isStageClear;
    bool isStageFault;
    // Start is called before the first frame update
    void Start()
    {
        NowLevel = NextLevel;

        ShowStage();

    }

    // Update is called once per frame
    void Update()
    {

    }
    int LevelToStageDataIndex(int level)
    {
        if (level <= 0)//�}�C�i�X�ɂȂ��Ă��܂�Ȃ��悤��
            return 0;
        var stageLevel = level;//���݂̃X�e�[�W���x��
        var max = Stages.Length;//�X�e�[�W�̌�
        if (stageLevel <= max - 1)//���݃X�e�[�W���ŏI�X�e�[�W�C�R�[�����Ȃ�ł����
            return stageLevel - 1;//�������X�e�[�W���x���Ƃ��ĕԂ�
        //��������Ȃ񂾂������ȁB�킩���
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
    }//NowLevel�ȊO�̃X�e�[�W�A�N�e�B�u��false�ɂ���
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

    //�f�o�b�O�p------------------------------------------------------------------------------------------------------------|

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
}