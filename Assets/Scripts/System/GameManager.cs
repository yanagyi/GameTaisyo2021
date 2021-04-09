using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�Q�[���}�l�[�W���[�̃������̈�m��
    public static GameManager instance = null;

    private void Awake()
    {
        //�����������
        if (instance == null)
        {
            //������
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        //�����������ɓ����Ă���ꍇ�j��
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
