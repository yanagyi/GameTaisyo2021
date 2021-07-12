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
        // �V�[�����̃v���C���[���擾����
        _player = GameObject.Find("Player");
        playerScript = _player.GetComponent<player>();
    }

    void Update()
    {
        // ��]����(�ڗ������邽��)
        transform.Rotate(new Vector3(0.0f, rotateSpeed, 0.0f));
    }

    // �v���C���[�Ƃ̐ڐG���ɉ񕜁A���g���폜
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // ��
            playerScript.PlusBattery();
            // �폜
            Destroy(gameObject);
        }
    }
}
