using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coil : MonoBehaviour
{
    public bool OnOff;                      // true(�_���Ă�->������) false(�����Ă�->�_��)
    public GameObject[] ElectricCurrent;    // �d�C
    public float max_count;                 // �d�C�����ɓ_���܂ł̎���
    float count;                            // ��Ɨp

    public GameObject[] root;
    public UsableObject[] rootScript;
   
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < root.Length; i++) {

            rootScript[i] = root[i].GetComponent<UsableObject>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OnOff) {
            // �h�����Ă�ԁA�d�C������
            // ���ꂽ���Ɨp�̕ϐ�(count)�����炷
            for (int i = 0; i < root.Length; i++) {
                if (rootScript[i].isZenmai) {
                    ElectricCurrent[0].SetActive(false);
                    ElectricCurrent[1].SetActive(false);

                    // ��Ɨp�ɑ��
                    count = max_count;
                } else {
                    count--;
                }

                // count��0�ɂȂ�����d�C��_����
                if (count <= 0) {
                    ElectricCurrent[0].SetActive(true);
                    ElectricCurrent[1].SetActive(true);
                }
            }

        }
        else {
            // �h�����Ă�ԁA�d�C��_����
            // ���ꂽ���Ɨp�̕ϐ�(count)�����炷
            for (int i = 0; i < root.Length; i++) {
                if (rootScript[i].isZenmai) {
                    ElectricCurrent[0].SetActive(true);
                    ElectricCurrent[1].SetActive(true);

                    // ��Ɨp�ɑ��
                    count = max_count;
                } else {
                    count--;
                }

                // count��0�ɂȂ�����d�C������
                if (count <= 0) {
                    ElectricCurrent[0].SetActive(false);
                    ElectricCurrent[1].SetActive(false);
                }
            }

        }
    }
}
