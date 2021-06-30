using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControl : MonoBehaviour
{
    //コピペ(circle.cs)
    public GameObject Robot;
    Rigidbody rb;
    GameObject player;
    PlayerControl playerScript;

    public bool controlFlag;//プレイヤーが操作状態（ゼンマイが刺さっている）かどうか
    public float moveSpeed;//移動速度
    float WmoveSpeed;//作業用変数
    public float moveTime;//切り離してから動き続ける時間
    float WmoveTime;//作業用変数
    bool vecFlag;//ゼンマイが離れたとき右を向いているか左を向いているか　右ture 左false
    public GameObject SoundObject;//SE用
    float SeTempo;//繰り返しSeを鳴らすための変数

    // Start is called before the first frame update
    void Start()
    {
        //コピペ(circle.cs)
        rb = gameObject.GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerControl>();

        controlFlag = false;
        SoundObject = GameObject.Find("SoundManager");
    }

    // Update is called once per frame
    void Update()
    {
        SeTempo += Time.deltaTime;//足音用秒数を計る

        //ゼンマイが刺さっているとき
        if (controlFlag)
        {
            Move();//移動
            WmoveSpeed = moveSpeed;//作業用変数に値を入れる
            WmoveTime = moveTime;//作業用変数に値を入れる
        }
        //ゼンマイが刺さっていないとき
        else
        {
            
            WmoveSpeed -= moveSpeed / moveTime;//移動速度を徐々に下げる
           
            WmoveTime--;//動ける時間（作業用変数）を減らしていく

            if (WmoveTime>0)//まだ動く時間があるとき
            {
                //右移動
                if(vecFlag)
                {
                    rb.MovePosition(gameObject.transform.position + new Vector3(0, 0, WmoveSpeed));
                    //右に向く
                    this.transform.rotation = Quaternion.Euler(0.0f, playerScript.rightRotate, 0.0f);
                    //一定時間ごとに音を鳴らす
                    if (SeTempo > 1.0f)
                    {
                        SoundObject.GetComponent<SoundManager>().Play_SE_Landing();
                        SeTempo = 0.0f;
                    }
                }
                //左移動
                else
                {
                    rb.MovePosition(gameObject.transform.position + new Vector3(0, 0, -WmoveSpeed));
                    //左に向く
                    this.transform.rotation = Quaternion.Euler(0.0f, playerScript.leftRotate, 0.0f);
                    //一定時間ごとに音を鳴らす
                    if (SeTempo > 1.0f)
                    {
                        SoundObject.GetComponent<SoundManager>().Play_SE_Landing();
                        SeTempo = 0.0f;
                    }
                }
            }
        }


    }

    //当たり判定
    void OnCollisionEnter(Collision other)
    {
        //壁に当たった時進行方向を変更する
        if (other.gameObject.tag == "Wall")
        {
            if (vecFlag)
                vecFlag = false;
            else
                vecFlag = true;
        }
    }
    //移動関数（プレイヤーと同じ挙動）
    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0)
        {
            rb.MovePosition(gameObject.transform.position + new Vector3(0, 0, -moveSpeed));
            //左に向く
            this.transform.rotation = Quaternion.Euler(0.0f, playerScript.leftRotate, 0.0f);
            vecFlag = false;
            //一定時間ごとに音を鳴らす
            if (SeTempo > 1.0f)
            {
                SoundObject.GetComponent<SoundManager>().Play_SE_Landing();
                SeTempo = 0.0f;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0)
        {
            rb.MovePosition(gameObject.transform.position + new Vector3(0, 0, moveSpeed));
            //右に向く
            this.transform.rotation = Quaternion.Euler(0.0f, playerScript.rightRotate, 0.0f);
            vecFlag = true;
            //一定時間ごとに音を鳴らす
            if (SeTempo > 1.0f)
            {
                SoundObject.GetComponent<SoundManager>().Play_SE_Landing();
                SeTempo = 0.0f;
            }
        }
    }

    //ゼンマイが刺さった時に呼ぶ
    public bool RobotFlagOn()
    {
        return controlFlag = true;
    }

    //ゼンマイを抜いた時に呼ぶ
    public bool RobotFlagOff()
    {
        return controlFlag = false;
    }


}
