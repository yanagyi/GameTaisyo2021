using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class VirtualCameraManager : MonoBehaviour
{
    public GameObject[] virtualCameras;
    private CinemachineVirtualCamera virtualCameraScript;

    // �e�J�����̒����_�Ƃ̃f�t�H���g�I�t�Z�b�g
    public Vector3[] defaultOffset;

    // �X�e�[�W�i���o�[�̎擾
    private int stageNum;

    // �X�e�[�W�擾�p
    private GameObject stageObject;

    // �t���[���J�E���^�[
    private float timeCount;

    // �|�[�Y
    private GameObject pauseManagerObject;
    private PauseManager pauseManager;

    private GameObject stageManagerObject;
    private StageManager stageManager;

    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    { 
        pauseManagerObject = GameObject.Find("PauseManager");
        pauseManager = pauseManagerObject.GetComponent<PauseManager>();

        stageManagerObject = GameObject.Find("StageManager");
        stageManager = stageManagerObject.GetComponent<StageManager>();

        stageNum = StageManager.GetNowLevel();
        Debug.Log(stageNum);

        Debug.Log(virtualCameras.Length);

        for (int i = 0; i < virtualCameras.Length; i++)
        {
            if (virtualCameras[i].name == "StageCamera")
            {
                virtualCameras[i].transform.position = virtualCameras[i].GetComponent<CameraData>().GetPos(stageNum);

                virtualCameraScript = virtualCameras[i].GetComponent<CinemachineVirtualCamera>();
                stageObject = stageManager.GetStageObject();
                virtualCameraScript.Follow = stageObject.transform;

                if (virtualCameras[i].GetComponent<CameraData>().GetEnable(stageNum))
                {
                    virtualCameras[i].transform.position = virtualCameras[i].GetComponent<CameraData>().GetPos(stageNum);
                }
                else
                {
                    virtualCameras[i].transform.position = 
                        new Vector3(stageObject.transform.position.x + defaultOffset[i].x, stageObject.transform.position.y + defaultOffset[i].y, stageObject.transform.position.z + defaultOffset[i].z);
                }

                virtualCameras[i].SetActive(true);
            }
            else if (virtualCameras[i].name == "GoalCamera")
            {

                virtualCameraScript = virtualCameras[i].GetComponent<CinemachineVirtualCamera>();
                stageObject = stageManager.GetStageObject();
                virtualCameraScript.Follow = stageObject.transform.Find("Goal").transform;

                if (virtualCameras[i].GetComponent<CameraData>().GetEnable(stageNum))
                {
                    virtualCameras[i].transform.position = virtualCameras[i].GetComponent<CameraData>().GetPos(stageNum);
                }
                else
                {
                    virtualCameras[i].transform.position = 
                        new Vector3(stageObject.transform.Find("Goal").transform.position.x + defaultOffset[i].x, stageObject.transform.Find("Goal").transform.position.y + defaultOffset[i].y, stageObject.transform.Find("Goal").transform.position.z + defaultOffset[i].z);
                }

                virtualCameras[i].SetActive(true);
            }
            else if (virtualCameras[i].name == "PlayerBehindCamera")
            {
                virtualCameraScript = virtualCameras[i].GetComponent<CinemachineVirtualCamera>();
                virtualCameras[i].transform.position = virtualCameras[i].GetComponent<CameraData>().GetPos(stageNum);

                if (virtualCameras[i].GetComponent<CameraData>().GetEnable(stageNum))
                {
                    virtualCameras[i].transform.position = virtualCameras[i].GetComponent<CameraData>().GetPos(stageNum);
                }
                else
                {
                    virtualCameras[i].transform.position = 
                        new Vector3(GameObject.Find("Player").transform.position.x + defaultOffset[i].x, GameObject.Find("Player").transform.position.y + defaultOffset[i].y, GameObject.Find("Player").transform.position.z + defaultOffset[i].z);
                }

                virtualCameraScript.Follow = GameObject.Find("Player").transform;
                virtualCameras[i].SetActive(true);
            }
            else if (virtualCameras[i].name == "PlayerCamera")
            {
                virtualCameraScript = virtualCameras[i].GetComponent<CinemachineVirtualCamera>();
                virtualCameraScript.Follow = GameObject.Find("Player").transform;
                virtualCameras[i].transform.position = 
                    new Vector3(GameObject.Find("Player").transform.position.x + defaultOffset[i].x, GameObject.Find("Player").transform.position.y + defaultOffset[i].y, GameObject.Find("Player").transform.position.z + defaultOffset[i].z);
                virtualCameras[i].SetActive(true);
            }
            else
            {
                // �M�~�b�N�͑��݂��Ȃ��\�������邽��bool�Ŋm�F������
                if (virtualCameras[i].GetComponent<CameraData>().GetEnable(stageNum))
                {
                    virtualCameras[i].transform.position = virtualCameras[i].GetComponent<CameraData>().GetPos(stageNum);

                    virtualCameraScript = virtualCameras[i].GetComponent<CinemachineVirtualCamera>();
                    virtualCameraScript.Follow = virtualCameras[i].GetComponent<CameraData>().GetLookObject(stageNum).transform;
                    virtualCameras[i].SetActive(true);
                }
                else
                {
                    virtualCameras[i].SetActive(false);
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
