using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift : MonoBehaviour
{
    bool isZenmai;
    public float posMaximum;
    public float posMinimum;
    Rigidbody rb;
//    const float moveSpeed = 0.125f;
    GameObject player;
   PlayerControl playerScript;
    public GameObject[] Root;
    public lift_Root[] parentsScript;
    private bool firstHit;

    private GameObject pauseManagerObject;

    public float moveSpeed;//移動速度
    float WmoveSpeed;//作業用変数
    public float moveTime;//切り離してから動き続ける時間
    float WmoveTime;//作業用変数
 //   bool vecFlag;//ゼンマイが離れたとき右を向いているか左を向いているか　右ture 左false
    public GameObject SoundObject;//SE用
    float SeTempo;//繰り返しSeを鳴らすための変数
    public int nowActiveRootIndex;
    // Start is called before the first frame update
    void Start()
    {
        firstHit = false;
        player = null;
        playerScript = null;
        rb = gameObject.GetComponent<Rigidbody>();
        
        for(int i = 0; i < Root.Length; i++) {

            parentsScript[i] = Root[i].GetComponent<lift_Root>();
        }
        
        pauseManagerObject = GameObject.Find("PauseManager");
    }

    // Update is called once per frame
    void Update()
    {
        SeTempo += Time.deltaTime;//足音用秒数を計る

        //ゼンマイが刺さっているとき
        for(int i = 0; i < Root.Length; i++) {
            if (parentsScript[i].isZenmai) {
                nowActiveRootIndex=i;
                Move();//移動
                WmoveSpeed = moveSpeed;//作業用変数に値を入れる
                WmoveTime = moveTime;//作業用変数に値を入れる
            }
        }
      

    }
    public void MoveOn()
    {

        if ((transform.localPosition.y < posMaximum) && (Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("Vertical") > 0)) {
            rb.MovePosition(gameObject.transform.position + new Vector3(0, moveSpeed, 0));
        }
        else if ((transform.localPosition.y > posMinimum) && (Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("Vertical") < 0)) {
            rb.MovePosition(gameObject.transform.position + new Vector3(0, -moveSpeed, 0));
        }
        else
        {
        }
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("Vertical") < 0) {
            rb.MovePosition(gameObject.transform.position + new Vector3(0, -moveSpeed, 0));
            //左に向く
            //this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
           // vecFlag = false;
            //一定時間ごとに音を鳴らす
            if (SeTempo > 1.0f) {
                SoundObject.GetComponent<SoundManager>().Play_SE_Landing();
                SeTempo = 0.0f;
            }
        } else if (Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("Vertical") > 0) {
            rb.MovePosition(gameObject.transform.position + new Vector3(0, moveSpeed, 0));
            //右に向く
          //  this.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
       //     vecFlag = true;
            //一定時間ごとに音を鳴らす
            if (SeTempo > 1.0f) {
                SoundObject.GetComponent<SoundManager>().Play_SE_Landing();
                SeTempo = 0.0f;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        ////当たった時に親子関係を決定する
        //if (collision.gameObject.tag != "Player")
        //    return;
        //if (!firstHit)
        //{
        //    player = collision.gameObject;
        //    player.transform.parent = gameObject.transform;
        //    playerScript = player.GetComponent<PlayerControl>();

        //    firstHit = true;
        //}
    }
    private void OnCollisionStay(Collision collision)
    {
        //if (collision.gameObject.tag != "Player")
        //    return;

    }
    private void OnCollisionExit(Collision collision)
    {
        //if (collision.gameObject.tag != "Player")
        //    return;
        //player.transform.parent = pauseManagerObject.transform;
        //player = null;
        //firstHit = false;
    }
}


