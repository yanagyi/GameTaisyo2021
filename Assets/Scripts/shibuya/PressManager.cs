using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressManager : UsableObject
{
    public GameObject[] press;
    piston[] pistonScript;

    // Start is called before the first frame update
    void Start()
    {
        isZenmai = false;

        //�v���X�@(�v���X���镔��)�A�X�N���v�g���擾�@
        pistonScript = new piston[press.Length];
        for (int i = 0; i < press.Length; i++)
        {
            pistonScript[i] = press[i].GetComponent<piston>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //�[���}�C���h�����Ă���ΑΉ����Ă���v���X�@���ғ�������
        for (int i = 0; i < press.Length; i++)
        {
            pistonScript[i].PressFlag(isZenmai);
        }
    }

    
    
}
