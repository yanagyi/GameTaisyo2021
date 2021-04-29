using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


// �������������������� �ȈՐ��� ��������������������
// PauseManager�̎q�v�f�ɂ����񂾃I�u�W�F�N�g���~����X�N���v�g
// �~�߂����Ȃ��I�u�W�F�N�g������ꍇ�̓C���X�y�N�^�[����ignoreObject�ɓo�^
// Pause�Œ�~�AResume�ōĊJ


// Rigidbody�̑��x�ۑ��p
// ���ꂪ�Ȃ��ƃ|�[�Y�������̋��������������Ȃ�
public class RigidbodyVelocity
{
    public Vector3 velocity;
    public Vector3 angularVelocity;

    public RigidbodyVelocity(Rigidbody rigidbody)
    {
        velocity = rigidbody.velocity;
        angularVelocity = rigidbody.angularVelocity;
    }
}

public class PauseManager : MonoBehaviour
{
    // �|�[�Y�����ۂ�
    private bool isPause;

    // �O�̃|�[�Y��Ԃ�ۑ�
    private bool prevPause;

    // ��������I�u�W�F�N�g
    public GameObject[] ignoreObjects;


    // �|�[�Y�p�z��
    private RigidbodyVelocity[] pauseRigidbodyVelocitys;
    private Rigidbody[] pauseRigidbodys;
    private MonoBehaviour[] pauseMonoBehaviours;

    void Start()
    {
        isPause = false;
        prevPause = false;
    }

    void Update()
    {
        // ���O�̒�~��ԂƓn���ꂽ�l���r����~/�ĊJ���s��
        if (prevPause != isPause)
        {
            if(isPause)
            {
                onPause();
            }
            else
            {
                onResume();
            }

            prevPause = isPause;
        }
    }

    // ���X�N���v�g����̌Ăяo���p
    public void Pause()
    {
        isPause = true;
    }

    public void Resume()
    {
        isPause = false;
    }

    // �|�[�Y
    void onPause()
    {
        // ��������I�u�W�F�N�g������PauseManager�̎q�v�f��RigidBody���擾
        pauseRigidbodys = Array.FindAll(GetComponentsInChildren<Rigidbody>(), (obj) => { return (!obj.IsSleeping() && Array.FindIndex(ignoreObjects, igObject => igObject == obj.gameObject) < 0); });

        pauseRigidbodyVelocitys = new RigidbodyVelocity[pauseRigidbodys.Length];

        // Rigidbody�̑��x�ȂǕۑ��ASleep
        for (int i = 0; i < pauseRigidbodys.Length; i++)
        {
            pauseRigidbodyVelocitys[i] = new RigidbodyVelocity(pauseRigidbodys[i]);
            pauseRigidbodys[i].Sleep();
        }

        // ��������I�u�W�F�N�g������PauseManager�̎q�v�f��MonoBehaviour���擾
        pauseMonoBehaviours = Array.FindAll(GetComponentsInChildren<MonoBehaviour>(), (obj) => { return (obj.enabled && obj != this &&Array.FindIndex(ignoreObjects, igObject => igObject == obj.gameObject) < 0); });

        // MonoBehaviour���~
        foreach (var monoBehaviour in pauseMonoBehaviours)
        {
            monoBehaviour.enabled = false;
        }
    }

    // �|�[�Y����
    void onResume()
    {
        // Rigidbody�ɕۑ����Ă��������x��߂��AWakeUp
        for (int i = 0; i < pauseRigidbodys.Length; i++)
        {
            pauseRigidbodys[i].WakeUp();
            pauseRigidbodys[i].velocity = pauseRigidbodyVelocitys[i].velocity;
            pauseRigidbodys[i].angularVelocity = pauseRigidbodyVelocitys[i].angularVelocity;
        }

        // MonoBehaviour���ĊJ
        foreach (var monoBehaviour in pauseMonoBehaviours)
        {
            monoBehaviour.enabled = true;
        }
    }
}
