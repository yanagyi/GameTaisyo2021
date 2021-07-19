using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{
    public GameObject Root;
    circle_Root RootsScript;
    Rigidbody rb;
    GameObject player;
    PlayerControl playerScript;
    public float moveSpeed;


    float WmoveSpeed;//作業用変数
    public float moveTime;//切り離してから動き続ける時間
    float WmoveTime;//作業用変数
                    //   bool vecFlag;//ゼンマイが離れたとき右を向いているか左を向いているか　右ture 左false
    public GameObject SoundObject;//SE用
    float SeTempo;//繰り返しSeを鳴らすための変数
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        RootsScript = Root.GetComponent<circle_Root>();

        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RootsScript.isZenmai) {

            Move();//移動
            WmoveSpeed = moveSpeed;//作業用変数に値を入れる
            WmoveTime = moveTime;//作業用変数に値を入れる
        }
    }
    public void MoveOn() {

        //if ((Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("Horizontal") < 0)) {
        //    rb.angularVelocity = new Vector3(-moveSpeed, 0, 0);
        //}
        //else if ((Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("Horizontal") > 0)) {
        //    rb.angularVelocity = new Vector3(moveSpeed, 0, 0);
        //}
        //else
        //{
        //}

    }
    void Move()
    {
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("Horizontal") < 0)) {
            rb.angularVelocity = new Vector3(0, 0, -moveSpeed);
        } else if ((Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("Horizontal") > 0)) {
            rb.angularVelocity = new Vector3(0, 0, moveSpeed);
        } else {
        }
    }
    public bool GetisZenmai()
    {
        return RootsScript.isZenmai;
    }
}
