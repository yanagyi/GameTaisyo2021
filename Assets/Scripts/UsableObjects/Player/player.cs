using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //�[���}�C�ƃv���C���[�Ƃ��ẴX�e�[�g�p
    public int state;
    public enum player_state
    {
        Idle=0,
        Robot,
        Zenmine,
        Controll,

        State_Max
    }
    //�W�����v�p�ϐ�--------
    public float JumpPower;
    Rigidbody rb;
    public Vector3 moveSpeed;
    //-----------------------------------
    //�����蔻��p�̃��C
    Ray downRay;//��΂����C�̕���
    RaycastHit hit;//�����蔻����擾����|�C���^�B
    public float RayLength;//���C�̒�����ݒ肷��悤
    public bool OnGround { get; set; }//�ǋL
    //----------------------------------
    GameObject target;//�e�q�֌W�ɂȂ�I�u�W�F�N�g�B(=����I�u�W�F�N�g


    //---------------- �Q�[�W(�o�b�e���[)�֘A --------------------

    // �o�b�e���[
    public float maxBattery = 180.0f;
    public float nowBattery;

    // �o�b�e���[�������x
    public float batterySpeed = 1.0f;
    public float batteryDouble = 1.2f;

    // �o�b�e���[�񕜗�
    public float batteryCharge = 90.0f;

    public float RotateSpeed;//�v���C���[�̉�]���鑬��
    // Start is called before the first frame update
    void Start()
    {
        OnGround = false;
        rb = GetComponent<Rigidbody>();
            //���C�̃T�C�Y������
        downRay = new Ray(transform.position, Vector3.down * RayLength);
        state = (int)player_state.Robot;
        target = null;

        nowBattery = maxBattery;

        // FPS60�Œ�
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
            //�[���}�C���[�h�B�����ɑΏۂ̃I�u�W�F�N�g������΃A�N�V�����N�����B
            case (int)player_state.Zenmine:
                ZenmaiAct();
                nowBattery -= batterySpeed * batteryDouble;
                break;
            case (int)player_state.Controll:
                ControllAct();
                nowBattery -= batterySpeed * batteryDouble;
                break;
            //�v���C���[���[�h�B�W�����v�Ƃ��ړ��Ƃ��B
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
        //�v���C���[�̓��͂�����
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

        //�ڒn���Ă���΃W�����v�ł���
        if (Input.GetButtonDown("Jump") && OnGround)//�ǋL
        {
            rb.velocity = transform.up * JumpPower;
            //�W�����v�����u�Ԑڒn���������
            OnGround = false;//�ǋL
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            state = (int)player_state.Zenmine;
        }
    }

    //���C���g���������蔻��B
    void ZenmaiAct()
    {
        //�[���}�C�̏�������
        //���C�̕`��
        downRay = new Ray(transform.position, Vector3.down);//�g�����C�̍X�V�B�厖�B
        Debug.DrawRay(transform.position, Vector3.down * RayLength, Color.blue, 2.0f, false);//�f�o�O�p�\�����C�B
        if (Physics.Raycast(downRay, out hit, RayLength)) {
            target = hit.collider.gameObject;//�e�q�֌W�ɂȂ�I�u�W�F�N�g���X�V����B(Controlled��state�Ŏg���̂�)
            Debug.Log("Hit:downRay"+target.name);
            if (target.tag == "zenmaiObj") {
                UsableObject scr = target.GetComponent<UsableObject>();
                transform.parent = target.transform;//�e�q�֌W����������B
                //�h���������ɃI�u�W�F�N�g�̒��S�ʒu�Ɏh����悤�ɂ��Ă������������B�C���T�[�g�������ꂼ��قȂ邩������Ȃ��̂ŁB
                scr.isZenmai = true;                
 //               scr.FreezeOff();

                FreezeOn();
                state = (int)player_state.Controll;
                return;
            }

        }
        //�����Ȃ������烍�{�b�g�ɖ߂�
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
        //�ό`����A�j���[�V�����̃X�N���v�g�����
    }


    // �Q�b�^�[ Gauge�ɓn���p�ɕϊ�����
    public float GetBattery()
    {
        float n;
        n = nowBattery / maxBattery;
        return n;
    }

    // �Z�b�^�[
    public void SetBattery(float n)
    {
        nowBattery = n;
    }

    // �o�b�e���񕜗p
    public void PlusBattery()
    {
        nowBattery += batteryCharge;
    }

}
