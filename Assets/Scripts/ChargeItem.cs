using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeItem : MonoBehaviour
{
    private GameObject _player;
    private player playerScript;

    private float rotateSpeed = 1.0f;

    void Start()
    {
        // シーン内のプレイヤーを取得する
        _player = GameObject.Find("Player");
        playerScript = _player.GetComponent<player>();
    }

    void Update()
    {
        // 回転する(目立たせるため)
        transform.Rotate(new Vector3(0.0f, rotateSpeed, 0.0f));
    }

    // プレイヤーとの接触時に回復、自身を削除
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // 回復
            playerScript.PlusBattery();
            // 削除
            Destroy(gameObject);
        }
    }
}
