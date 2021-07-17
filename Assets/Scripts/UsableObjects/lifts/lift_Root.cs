using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift_Root : UsableObject
{
  //  public bool isZenmai;
    public GameObject lift;
    lift liftScript;
    //当たり判定撮るやつ
    GameObject player;
    
    public bool controlFlag;//プレイヤーが操作状態（ゼンマイが刺さっている）かどうか
    public GameObject SoundObject;//SE用
    float SeTempo;//繰り返しSeを鳴らすための変数
    // Start is called before the first frame update
    void Start()
    {
        isZenmai = false;
        liftScript = lift.GetComponent<lift>();

        //
        player = GameObject.Find("Player");


        controlFlag = false;
        isZenmai = false;
        SoundObject = GameObject.Find("SoundManager");

    }

    // Update is called once per frame
    void Update()
    {
        if (isZenmai == false) {
          
            return;
        }
        //いったん全解除
        lift.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        //回転ロック
        lift.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
        lift.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
        lift.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
        //位置ロック
        lift.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
        lift.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
        liftScript.MoveOn();
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
            collision.gameObject.transform.position =pos;
        }
    }
}
