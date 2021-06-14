using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraData : MonoBehaviour
{
    public Vector3[] PosOnEachStage;
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
        gameObject.transform.position = PosOnEachStage[nowLevel];
    }

    public Vector3 GetPos(int nowLevel)
    {
        return PosOnEachStage[nowLevel];
    }

    public bool GetEnable(int nowLevel)
    {
        return enable[nowLevel];
    }
}
