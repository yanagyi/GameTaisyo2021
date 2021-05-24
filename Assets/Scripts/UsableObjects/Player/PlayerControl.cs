using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : UsableObject
{
 //   public bool isZenmai;
   public Rigidbody rb;
    public float moveSpeed;//= 0.25f;
    public string button;
    bool onTheWall;
    bool nowFall;

    Animator anim;

    //パーティクル変数
    private ParticleSystem particle;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (isZenmai == false&&nowFall==false)
            return;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0) {
            rb.MovePosition(gameObject.transform.position + new Vector3(0, 0, -moveSpeed));
            anim.SetBool("isWalking", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0)
        {
            rb.MovePosition(gameObject.transform.position + new Vector3(0, 0, moveSpeed));
            anim.SetBool("isWalking", true);
        }
        else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(button)) {
            SetKinematic(false);
            Gravity_Effect();
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
        Gravity_Effect();
        do {
            
            yield return null;
        } while (nowFall == true);
        yield break;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // "floor"タグのオブジェクトと衝突したらパーティクル生成
        if(collision.gameObject.tag == "floor")
        {
            particle.Play();
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