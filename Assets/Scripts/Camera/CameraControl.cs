using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Vector3[] CameraPosOnEachStage;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetCameraPos(int nowLevel)
    {
        gameObject.transform.position = CameraPosOnEachStage[nowLevel];
        Debug.Log("NowLevel::" + nowLevel);
    }

    public Vector3 GetCameraPos(int nowLevel)
    {
        return CameraPosOnEachStage[nowLevel];
    }
}
