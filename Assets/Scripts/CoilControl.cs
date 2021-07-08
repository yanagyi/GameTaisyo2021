using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilControl : UsableObject
{
    public GameObject[] ElectricCurrent;    // �d�C
    public float max_count;                 // �d�C�����ɓ_���܂ł̎���
    float count;                            // ��Ɨp

    // Start is called before the first frame update
    void Start()
    {
        isZenmai = false;
    }

    // Update is called once per frame
    void Update()
    {
        // �h�����Ă�ԁA�d�C������
        // ���ꂽ���Ɨp�̕ϐ�(count)�����炷
        if (isZenmai)
        {
            ElectricCurrent[0].SetActive(false);
            ElectricCurrent[1].SetActive(false);

            // ��Ɨp�ɑ��
            count = max_count;
        }
        else
        {
            count--;
        }

        // count��0�ɂȂ�����d�C������
        if (count <= 0)
        {
            ElectricCurrent[0].SetActive(true);
            ElectricCurrent[1].SetActive(true);
        }
    }
}