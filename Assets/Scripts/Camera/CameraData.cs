using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraData : MonoBehaviour
{
    // カメラ自体のポジション
    public Vector3[] pos;

    // ギミックなど見たいオブジェクトを設定する
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
