using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //ゼンマイとプレイヤーとしてのステート用
    public int state;
    public enum player_state
    {
        Idle=0,
        Robot,
        Zenmine,
        Controll,

        State_Max
    }
    //ジャンプ用変数--------
    public float JumpPower;
    Rigidbody rb;
    public Vector3 moveSpeed;
    //-----------------------------------
    //当たり判定用のレイ
    Ray downRay;//飛ばすレイの方向
    RaycastHit hit;//当たり判定を取得するポインタ。
    public float RayLength;//レイの長さを設定するよう
    public bool OnGround { get; set; }//追記
    //----------------------------------
    GameObject target;//親子関係になるオブジェクト。(=操るオブジェクト


    //---------------- ゲージ(バッテリー)関連 --------------------

    // バッテリー
    public float maxBattery = 180.0f;
    public float nowBattery;

    // バッテリー減少速度
    public float batterySpeed = 1.0f;
    public float batteryDouble = 1.2f;

    // バッテリー回復量
    public float batteryCharge = 90.0f;

    public float RotateSpeed;//プレイヤーの回転する速さ
    // Start is called before the first frame update
    void Start()
    {
        OnGround = false;
        rb = GetComponent<Rigidbody>();
            //レイのサイズ初期化
        downRay = new Ray(transform.position, Vector3.down * RayLength);
        state = (int)player_state.Robot;
        target = null;

        nowBattery = maxBattery;

        // FPS60固定
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    private void FixedUpdate()
    {
        switch (state) {
            case (int)player_state.Robot:
                RobotAction();
                nowBattery -= batterySpeed;
                break;
            //ゼンマイモード。足元に対象のオブジェクトがあればアクション起こす。
            case (int)player_state.Zenmine:
                ZenmaiAct();
                nowBattery -= batterySpeed * batteryDouble;
                break;
            case (int)player_state.Controll:
                ControllAct();
                nowBattery -= batterySpeed * batteryDouble;
                break;
            //プレイヤーモード。ジャンプとか移動とか。
            case (int)player_state.Idle:
                nowBattery -= batterySpeed;
                break;
            default:
                break;
        }

        if(nowBattery < 0.0f)
        {
            nowBattery = 0.0f;
        }
    }


    void RobotAction()
    {
        //プレイヤーの入力を書く
        if (OnGround == true) {
            if (Input.GetAxis("Horizontal") < 0) {
                rb.MovePosition(transform.position - moveSpeed);
            }
            if (Input.GetAxis("Horizontal") > 0) {
                rb.MovePosition(transform.position + moveSpeed);
            }
        } 
        else {
            if (Input.GetAxis("Horizontal") < 0) {
                rb.MovePosition(transform.position - (moveSpeed / 2.0f));
            }
            if (Input.GetAxis("Horizontal") > 0) {
                rb.MovePosition(transform.position + (moveSpeed / 2.0f));
            }
        }

        //接地していればジャンプできる
        if (Input.GetButtonDown("Jump") && OnGround)//追記
        {
            rb.velocity = transform.up * JumpPower;
            //ジャンプした瞬間接地判定を解除
            OnGround = false;//追記
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            state = (int)player_state.Zenmine;
        }
    }

    //レイを使った当たり判定。
    void ZenmaiAct()
    {
        //ゼンマイの処理書く
        //レイの描画
        downRay = new Ray(transform.position, Vector3.down);//使うレイの更新。大事。
        Debug.DrawRay(transform.position, Vector3.down * RayLength, Color.blue, 2.0f, false);//デバグ用表示レイ。
        if (Physics.Raycast(downRay, out hit, RayLength)) {
            target = hit.collider.gameObject;//親子関係になるオブジェクトを更新する。(Controlledのstateで使うので)
            Debug.Log("Hit:downRay"+target.name);
            if (target.tag == "zenmaiObj") {
                UsableObject scr = target.GetComponent<UsableObject>();
                transform.parent = target.transform;//親子関係を持たせる。
                //刺さった時にオブジェクトの中心位置に刺さるようにしていただきたい。インサート口がそれぞれ異なるかもしれないので。
                scr.isZenmai = true;                
 //               scr.FreezeOff();

                FreezeOn();
                state = (int)player_state.Controll;
                return;
            }

        }
        //何もなかったらロボットに戻る
        state = (int)player_state.Robot;
    }
    void ControllAct()
    {
        transform.Rotate(new Vector3(0, RotateSpeed, 0));
        if (Input.GetKeyUp(KeyCode.LeftShift)) {

            UsableObject scr = target.GetComponent<UsableObject>();
            scr.isZenmai = false;
      //      scr.FreezeOn();
            transform.parent = null;
            target = null;

            FreezeOff();
            state = (int)player_state.Robot;
        }
    }
    void FreezeOn()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
    void FreezeOff()
    {
        rb.constraints = RigidbodyConstraints.None;

        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
    void Transformation()
    {
        //変形するアニメーションのスクリプト入れる
    }


    // ゲッター Gaugeに渡す用に変換する
    public float GetBattery()
    {
        float n;
        n = nowBattery / maxBattery;
        return n;
    }

    // セッター
    public void SetBattery(float n)
    {
        nowBattery = n;
    }

    // バッテリ回復用
    public void PlusBattery()
    {
        nowBattery += batteryCharge;
    }

}
