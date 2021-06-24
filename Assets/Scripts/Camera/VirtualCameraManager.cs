using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCameraManager : MonoBehaviour
{
    public GameObject[] virtualCameras;
    public GameObject[] lookAt;

    public GameObject gaugeObject;
    private Gauge gaugeScript;

    // �X�e�[�W�i���o�[�̎擾
    private int stageNum;

    // �t���[���J�E���^�[
    private float timeCount;

    private GameObject pauseManagerObject;
    private PauseManager pauseManager;

    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        pauseManagerObject = GameObject.Find("PauseManager");
        pauseManager = pauseManagerObject.GetComponent<PauseManager>();

        gaugeScript = gaugeObject.GetComponent<Gauge>();

        stageNum = StageManager.GetNowLevel();
        Debug.Log(stageNum);

        for (int i = 0; i < virtualCameras.Length; i++)
        {
            if (virtualCameras[i].name == "StageCamera")
            {
                virtualCameras[i].transform.position = virtualCameras[i].GetComponent<CameraData>().GetPos(stageNum);
                virtualCameras[i].SetActive(true);
            }
            else if (virtualCameras[i].name == "GoalCamera")
            {
                virtualCameras[i].transform.position = virtualCameras[i].GetComponent<CameraData>().GetPos(stageNum);
                virtualCameras[i].SetActive(true);
            }
            else if (virtualCameras[i].name == "PlayerBehindCamera")
            {
                virtualCameras[i].transform.position = virtualCameras[i].GetComponent<CameraData>().GetPos(stageNum);
                virtualCameras[i].SetActive(true);
            }
            else if (virtualCameras[i].name == "PlayerCamera")
            {
                virtualCameras[i].SetActive(true);
            }
            else
            {
                // �M�~�b�N�͑��݂��Ȃ��\�������邽��bool�Ŋm�F������
                if (virtualCameras[i].GetComponent<CameraData>().GetEnable(stageNum))
                {
                    virtualCameras[i].transform.position = virtualCameras[i].GetComponent<CameraData>().GetPos(stageNum);
                    virtualCameras[i].SetActive(true);
                }
                else
                {
                    virtualCameras[i].SetActive(false);
                }
            }
        }

        for (int i = 0; i < lookAt.Length; i++)
        {
            if (lookAt[i].name == "LookAtStage")
            {
                lookAt[i].transform.position = lookAt[i].GetComponent<CameraData>().GetPos(stageNum);
                lookAt[i].SetActive(true);
            }
            else if (lookAt[i].name == "LookAtGoal")
            {
                lookAt[i].transform.position = lookAt[i].GetComponent<CameraData>().GetPos(stageNum);
                lookAt[i].SetActive(true);
            }
            else if (lookAt[i].name == "LookAtPlayerBehind")
            {
                lookAt[i].transform.position = lookAt[i].GetComponent<CameraData>().GetPos(stageNum);
                lookAt[i].SetActive(true);
            }
            else
            {
                // �M�~�b�N�͑��݂��Ȃ��\�������邽��bool�Ŋm�F������
                if (lookAt[i].GetComponent<CameraData>().GetEnable(stageNum))
                {
                    lookAt[i].transform.position = lookAt[i].GetComponent<CameraData>().GetPos(stageNum);
                    lookAt[i].SetActive(true);
                }
                else
                {
                    lookAt[i].SetActive(false);
                }
            }
        }

        pauseManager.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        // ����t���[����0���珇��VirtualCamera���I�t�ɂ���(��A�N�e�B�u�ɂ���)���̃J�����Ɏ����ňړ�����

        if (timeCount > 2)
        {
            for (int i = 0; i < virtualCameras.Length - 1; i++)
            {
                if (virtualCameras[i].activeSelf)
                {
                    virtualCameras[i].SetActive(false);

                    if (i == virtualCameras.Length - 2)
                    {
                        pauseManager.Resume();
                        gaugeScript.GaugeValid();
                    }
                    break;
                }
            }

            timeCount = 0;
        }

        timeCount += Time.deltaTime;
        //Debug.Log(timeCount);
    }
}
