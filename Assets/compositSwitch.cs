using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compositSwitch : UsableObject
{
   public  bool useCoil;
    public bool OnOff;                      // true(点いてる->消える) false(消えてる->点く)
    public GameObject[] ElectricCurrent;    // 電気
    public float max_count;                 // 電気が次に点くまでの時間
    float count;                            // 作業用


    public bool usePiston;
    public GameObject[] pistonObj;
    piston scr;
    public bool controlFlag;//プレイヤーが操作状態（ゼンマイが刺さっている）かどうか
    public GameObject SoundObject;//SE用
    // Start is called before the first frame update
    void Start()
    {
        isZenmai = false;
        if (useCoil) {

        }
        if (usePiston) {

            controlFlag = false;
            SoundObject = GameObject.Find("SoundManager");
        }
        
    }

    // Update is called once per frame
    void Update()
    {





    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            Vector3 pos = collision.gameObject.transform.position;
            pos.z = 0;
            collision.gameObject.transform.position = pos;
        }
    }
}
