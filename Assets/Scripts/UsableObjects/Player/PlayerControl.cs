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

    //パーティクル変数
    private ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
      //プレイヤーのリジッドボディ取得
      rb = gameObject.GetComponent<Rigidbody>();

      //パーティクルシステムの取得
      particle = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isZenmai == false&&nowFall==false)
            return;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0) {
            rb.MovePosition(gameObject.transform.position + new Vector3(0, 0, -moveSpeed));
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0) {
            rb.MovePosition(gameObject.transform.position + new Vector3(0, 0, moveSpeed));
        }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(button)) {
            Gravity_Effect();
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
}