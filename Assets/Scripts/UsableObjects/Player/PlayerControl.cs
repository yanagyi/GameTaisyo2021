using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : UsableObject
{
 //   public bool isZenmai;
   public Rigidbody rb;
    public float moveSpeed;//= 0.25f;
    public string button;
    public float rotateSpeed;//3.0くらいがよいっぽい
    public float GVOn;
    public bool isActive;
    Animator anim;

    //パーティクル変数
    private ParticleSystem particle;

    public GameObject SoundObject;

    // Start is called before the first frame update
    void Start()
    {
      //プレイヤーのリジッドボディ取得
      rb = gameObject.GetComponent<Rigidbody>();

      //パーティクルシステムの取得
      particle = GetComponentInChildren<ParticleSystem>();

        // 重力の初期化
        Physics.gravity = new Vector3(0.0f, -9.81f, 0.0f);
       // Init anim
       this.anim = GetComponent<Animator>();

        isActive = false;

        SoundObject = GameObject.Find("SoundManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (isZenmai == false)
            return;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0)
        {
            rb.MovePosition(gameObject.transform.position + new Vector3(0, 0, -moveSpeed));
            anim.SetBool("isWalking", true);
            //足音SoundObject.GetComponent<SoundManager>().Play_SE_Landing();
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0)
        {
            rb.MovePosition(gameObject.transform.position + new Vector3(0, 0, moveSpeed));
            anim.SetBool("isWalking", true);
            //足音SoundObject.GetComponent<SoundManager>().Play_SE_Landing();
        }
        else if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(button)) && isActive == false)
        {
            StartCoroutine("GravityEffect");
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    //重力反転処理
    public void Gravity_Effect()
    {
        Physics.gravity *= -1.0f;
    }

    IEnumerator GravityEffect()
    {
        isActive = true;

        // Transform値を取得する
        Vector3 position = this.transform.localPosition;
        Quaternion rotation = this.transform.localRotation;

        // クォータニオン → オイラー角への変換
        Vector3 rotationAngles = rotation.eulerAngles;

        rb.isKinematic = true;//重力の影響をうけなくする
       
        for (float i = 0; i < 180.0f; i+=rotateSpeed) {
            transform.localPosition += new Vector3(0.0f, -GVOn * (Physics.gravity.y)*0.01f, 0.0f);//重力の反対方向(=プレイ屋の頭の方向）
                                                                                      //にいったんプレイヤーの位置位置を上にあげている

            rotationAngles.z += rotateSpeed;
            rotation = Quaternion.Euler(rotationAngles);
            transform.localRotation = rotation;
            yield return null;
        }
        rb.isKinematic = false;
        Gravity_Effect();
        isActive = false;

        yield break;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // "floor"タグのオブジェクトと衝突したらパーティクル生成
        if(collision.gameObject.tag == "floor")
        {
            particle.Play();
            //着地音SoundObject.GetComponent<SoundManager>().Play_SE_Landing();
        }
    }

    public void SetKinematic(bool flag)
    {
        rb.isKinematic = flag;
    }

    public bool GetKinematic()
    {
        if(rb.isKinematic)
        {
            return true;
        }

        return false;
    }

    public void playerGrasp()
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX |
                                                           RigidbodyConstraints.FreezeRotationY |
                                                           RigidbodyConstraints.FreezeRotationZ |
                                                           RigidbodyConstraints.FreezePositionX |
                                                           RigidbodyConstraints.FreezePositionY |
                                                           RigidbodyConstraints.FreezePositionZ;
    }

    public void playerGraspOff()
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX |
                                                           RigidbodyConstraints.FreezeRotationY |
                                                           RigidbodyConstraints.FreezeRotationZ |
                                                           RigidbodyConstraints.FreezePositionX;
    }

}