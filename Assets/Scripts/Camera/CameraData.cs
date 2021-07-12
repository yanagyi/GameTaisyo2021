using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraData : MonoBehaviour
{
    // �J�������̂̃|�W�V����
    public Vector3[] pos;

    // �M�~�b�N�Ȃǌ������I�u�W�F�N�g��ݒ肷��
    public GameObject[] lookObject;

    public bool[] enable;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPos(int nowLevel)
    {
        gameObject.transform.position = pos[nowLevel];
    }

    public Vector3 GetPos(int nowLevel)
    {
        return pos[nowLevel];
    }

    public bool GetEnable(int nowLevel)
    {
        return enable[nowLevel];
    }

    public GameObject GetLookObject(int nowLevel)
    {
        return lookObject[nowLevel];
    }
}
