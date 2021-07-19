using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coilSwitch : UsableObject
{
    public GameObject[] coilObj;
    coil scr;
    public bool controlFlag;//�v���C���[�������ԁi�[���}�C���h�����Ă���j���ǂ���
    public GameObject SoundObject;//SE�p
    // Start is called before the first frame update
    void Start()
    {
        controlFlag = false;
        isZenmai = false;
        SoundObject = GameObject.Find("SoundManager");
    }

    // Update is called once per frame
    void Update()
    {
        
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
            collision.gameObject.transform.position = pos;
        }
    }
}
