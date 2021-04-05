using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject zenmai;
    public GameObject player;
    public Vector3 pos;
    public Vector3 OnRot;
    public Vector3 OffRot;
    public Vector3 posOfPlayerParent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //  transform.position = pos + zenmai.transform.position;
    }
    public void ZenmaiOff() {
        transform.localEulerAngles = OffRot;
        //ゼンマイ操作時のカメラ位置
        transform.position = posOfPlayerParent + player.transform.position;
    }
    public void ZenmaiOn() {
        transform.localEulerAngles = OnRot;
        //ゼンマイがプレイヤーに刺さっている時のカメラ位置
        transform.position = pos + zenmai.transform.position;
    }
}
