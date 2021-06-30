using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControl : MonoBehaviour
{
    //�R�s�y(circle.cs)
    public GameObject Robot;
    Rigidbody rb;
    GameObject player;
    PlayerControl playerScript;

    public bool controlFlag;//�v���C���[�������ԁi�[���}�C���h�����Ă���j���ǂ���
    public float moveSpeed;//�ړ����x
    float WmoveSpeed;//��Ɨp�ϐ�
    public float moveTime;//�؂藣���Ă��瓮�������鎞��
    float WmoveTime;//��Ɨp�ϐ�
    bool vecFlag;//�[���}�C�����ꂽ�Ƃ��E�������Ă��邩���������Ă��邩�@�Eture ��false
    public GameObject SoundObject;//SE�p
    float SeTempo;//�J��Ԃ�Se��炷���߂̕ϐ�

    // Start is called before the first frame update
    void Start()
    {
        //�R�s�y(circle.cs)
        rb = gameObject.GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerControl>();

        controlFlag = false;
        SoundObject = GameObject.Find("SoundManager");
    }

    // Update is called once per frame
    void Update()
    {
        SeTempo += Time.deltaTime;//�����p�b�����v��

        //�[���}�C���h�����Ă���Ƃ�
        if (controlFlag)
        {
            Move();//�ړ�
            WmoveSpeed = moveSpeed;//��Ɨp�ϐ��ɒl������
            WmoveTime = moveTime;//��Ɨp�ϐ��ɒl������
        }
        //�[���}�C���h�����Ă��Ȃ��Ƃ�
        else
        {
            
            WmoveSpeed -= moveSpeed / moveTime;//�ړ����x�����X�ɉ�����
           
            WmoveTime--;//�����鎞�ԁi��Ɨp�ϐ��j�����炵�Ă���

            if (WmoveTime>0)//�܂��������Ԃ�����Ƃ�
            {
                //�E�ړ�
                if(vecFlag)
                {
                    rb.MovePosition(gameObject.transform.position + new Vector3(0, 0, WmoveSpeed));
                    //�E�Ɍ���
                    this.transform.rotation = Quaternion.Euler(0.0f, playerScript.rightRotate, 0.0f);
                    //��莞�Ԃ��Ƃɉ���炷
                    if (SeTempo > 1.0f)
                    {
                        SoundObject.GetComponent<SoundManager>().Play_SE_Landing();
                        SeTempo = 0.0f;
                    }
                }
                //���ړ�
                else
                {
                    rb.MovePosition(gameObject.transform.position + new Vector3(0, 0, -WmoveSpeed));
                    //���Ɍ���
                    this.transform.rotation = Quaternion.Euler(0.0f, playerScript.leftRotate, 0.0f);
                    //��莞�Ԃ��Ƃɉ���炷
                    if (SeTempo > 1.0f)
                    {
                        SoundObject.GetComponent<SoundManager>().Play_SE_Landing();
                        SeTempo = 0.0f;
                    }
                }
            }
        }


    }

    //�����蔻��
    void OnCollisionEnter(Collision other)
    {
        //�ǂɓ����������i�s������ύX����
        if (other.gameObject.tag == "Wall")
        {
            if (vecFlag)
                vecFlag = false;
            else
                vecFlag = true;
        }
    }
    //�ړ��֐��i�v���C���[�Ɠ��������j
    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0)
        {
            rb.MovePosition(gameObject.transform.position + new Vector3(0, 0, -moveSpeed));
            //���Ɍ���
            this.transform.rotation = Quaternion.Euler(0.0f, playerScript.leftRotate, 0.0f);
            vecFlag = false;
            //��莞�Ԃ��Ƃɉ���炷
            if (SeTempo > 1.0f)
            {
                SoundObject.GetComponent<SoundManager>().Play_SE_Landing();
                SeTempo = 0.0f;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0)
        {
            rb.MovePosition(gameObject.transform.position + new Vector3(0, 0, moveSpeed));
            //�E�Ɍ���
            this.transform.rotation = Quaternion.Euler(0.0f, playerScript.rightRotate, 0.0f);
            vecFlag = true;
            //��莞�Ԃ��Ƃɉ���炷
            if (SeTempo > 1.0f)
            {
                SoundObject.GetComponent<SoundManager>().Play_SE_Landing();
                SeTempo = 0.0f;
            }
        }
    }

    //�[���}�C���h���������ɌĂ�
    public bool RobotFlagOn()
    {
        return controlFlag = true;
    }

    //�[���}�C�𔲂������ɌĂ�
    public bool RobotFlagOff()
    {
        return controlFlag = false;
    }


}
