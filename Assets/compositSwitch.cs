using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compositSwitch : UsableObject
{
   public  bool useCoil;
    public bool OnOff;                      // true(�_���Ă�->������) false(�����Ă�->�_��)
    public GameObject[] ElectricCurrent;    // �d�C
    public float max_count;                 // �d�C�����ɓ_���܂ł̎���
    float count;                            // ��Ɨp


    public bool usePiston;
    public GameObject[] pistonObj;
    piston scr;
    public bool controlFlag;//�v���C���[�������ԁi�[���}�C���h�����Ă���j���ǂ���
    public GameObject SoundObject;//SE�p
    // Start is called before the first frame update
    void Start()
    {
        isZenmai = false;
        if (useCoil) {

        }
        if (usePiston) {

            controlFlag = false;
            SoundObject = GameObject.Find("SoundManager");
        }
        
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
