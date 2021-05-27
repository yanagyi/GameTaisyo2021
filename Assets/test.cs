using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public bool isActivate;
    public bool isOpened;
    public float rotationSpeed;
    public float startAngle;
    public float maxAngle;
    // Start is called before the first frame update
    void Start()
    {
        isOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivate==false&&Input.GetKey(KeyCode.Return)) {
            isActivate = true;
            switch (isOpened) {
                case true:
                    StartCoroutine("RotationOFF");
                    break;
                case false:
                    StartCoroutine("RotationON");
                    break;
            }

        }
    }
    IEnumerator RotationON()
    { // Transform�l���擾����
        Vector3 position = this.transform.localPosition;
        Quaternion rotation = this.transform.localRotation;
        Vector3 scale = this.transform.localScale;

        // �N�H�[�^�j�I�� �� �I�C���[�p�ւ̕ϊ�
        Vector3 rotationAngles = rotation.eulerAngles;
        isActivate = true;
        // X����90�x��]
        for (int i = 0; i < (maxAngle-startAngle) / rotationSpeed; i++) {
            rotationAngles.x += rotationSpeed;
            rotation = Quaternion.Euler(rotationAngles);
            transform.localRotation = rotation;
            yield return null;
        }
        /*
        rotationAngles.x = rotationAngles.x + 90.0f;
        Vector3�̉��Z�͈ȉ��̂悤�ȏ��������\
       rotationAngles += new Vector3(90.0f, 0.0f, 0.0f);

        �I�C���[�p �� �N�H�[�^�j�I���ւ̕ϊ�
       rotation = Quaternion.Euler(rotationAngles);

        Transform�l��ݒ肷��
        this.transform.localPosition = position;
        this.transform.localRotation = rotation;
        this.transform.localScale = scale;
        */
        isOpened = true;
        isActivate = false;
        yield break;
    }
    IEnumerator RotationOFF()
    {
        // Transform�l���擾����
        Vector3 position = this.transform.localPosition;
        Quaternion rotation = this.transform.localRotation;
        Vector3 scale = this.transform.localScale;

        // �N�H�[�^�j�I�� �� �I�C���[�p�ւ̕ϊ�
        Vector3 rotationAngles = rotation.eulerAngles;
        
        // X����90�x��]
        for (int i = 0; i < (startAngle) / rotationSpeed; i++) {
            rotationAngles.x -= rotationSpeed;
            rotation = Quaternion.Euler(rotationAngles);
            transform.localRotation = rotation;
            yield return null;
        }
        /*
        rotationAngles.x = rotationAngles.x + 90.0f;
        Vector3�̉��Z�͈ȉ��̂悤�ȏ��������\
       rotationAngles += new Vector3(90.0f, 0.0f, 0.0f);

        �I�C���[�p �� �N�H�[�^�j�I���ւ̕ϊ�
       rotation = Quaternion.Euler(rotationAngles);

        Transform�l��ݒ肷��
        this.transform.localPosition = position;
        this.transform.localRotation = rotation;
        this.transform.localScale = scale;
        */
        isOpened = false;
        isActivate = false;
        yield break;
    }
}
