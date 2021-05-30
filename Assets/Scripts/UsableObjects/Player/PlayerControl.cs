using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : UsableObject
{
 //   public bool isZenmai;
   public Rigidbody rb;
    public float moveSpeed;//= 0.25f;
    public string button;
    public float rotateSpeed;//3.0���炢���悢���ۂ�
    public float GVOn;
    public bool isActive;
    Animator anim;

    //�p�[�e�B�N���ϐ�
    private ParticleSystem particle;

    public GameObject SoundObject;

    // Start is called before the first frame update
    void Start()
    {
      //�v���C���[�̃��W�b�h�{�f�B�擾
      rb = gameObject.GetComponent<Rigidbody>();

      //�p�[�e�B�N���V�X�e���̎擾
      particle = GetComponentInChildren<ParticleSystem>();

        // �d�͂̏�����
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
            //����SoundObject.GetComponent<SoundManager>().Play_SE_Landing();
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0)
        {
            rb.MovePosition(gameObject.transform.position + new Vector3(0, 0, moveSpeed));
            anim.SetBool("isWalking", true);
            //����SoundObject.GetComponent<SoundManager>().Play_SE_Landing();
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

    //�d�͔��]����
    public void Gravity_Effect()
    {
        Physics.gravity *= -1.0f;
    }

    IEnumerator GravityEffect()
    {
        isActive = true;

        // Transform�l���擾����
        Vector3 position = this.transform.localPosition;
        Quaternion rotation = this.transform.localRotation;

        // �N�H�[�^�j�I�� �� �I�C���[�p�ւ̕ϊ�
        Vector3 rotationAngles = rotation.eulerAngles;

        rb.isKinematic = true;//�d�͂̉e���������Ȃ�����
       
        for (float i = 0; i < 180.0f; i+=rotateSpeed) {
            transform.localPosition += new Vector3(0.0f, -GVOn * (Physics.gravity.y)*0.01f, 0.0f);//�d�͂̔��Ε���(=�v���C���̓��̕����j
                                                                                      //�ɂ�������v���C���[�̈ʒu�ʒu����ɂ����Ă���

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
        // "floor"�^�O�̃I�u�W�F�N�g�ƏՓ˂�����p�[�e�B�N������
        if(collision.gameObject.tag == "floor")
        {
            particle.Play();
            //���n��SoundObject.GetComponent<SoundManager>().Play_SE_Landing();
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