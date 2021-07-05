using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiClosingDoor : SwitchObjectsScript
{
    public GameObject Switch;
    FloorButton ButtonScript;
    public float startAngle;
    public float maxAngle;
    public float RotSpeed;
    public bool isActivate;
    public bool dummy;
    bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        ButtonScript = Switch.GetComponent<FloorButton>();
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void CallActionOn()
    {
        StartCoroutine(OnAction());
    }
    public override void CallActionOff()
    {
        StartCoroutine(OffAction());
        return;
    }
    public override IEnumerator OnAction()
    {
        Vector3 position = this.transform.localPosition;
        Quaternion rotation = this.transform.localRotation;
        Vector3 scale = this.transform.localScale;
        // �N�H�[�^�j�I�� �� �I�C���[�p�ւ̕ϊ�
        Vector3 rotationAngles = rotation.eulerAngles;

        isActivate = true;
        switch (isOpen) {
            case true:

                // X����90�x��]
                for (int i = 0; i < (maxAngle - startAngle) / RotSpeed; i++) {
                    rotationAngles.x += RotSpeed;
                    rotation = Quaternion.Euler(rotationAngles);
                    transform.localRotation = rotation;
                    yield return null;
                }
                isOpen = false;
                break;
            case false:
                // X����90�x��]
                for (int i = 0; i < (startAngle) / RotSpeed; i++) {
                    rotationAngles.x -= RotSpeed;
                    rotation = Quaternion.Euler(rotationAngles);
                    transform.localRotation = rotation;
                    yield return null;
                }
                isOpen = true;
                break;
        }

        isActivate = false;
        yield break;
    }
    public override IEnumerator OffAction()
    {
        Vector3 position = this.transform.localPosition;
        Quaternion rotation = this.transform.localRotation;
        Vector3 scale = this.transform.localScale;
        // �N�H�[�^�j�I�� �� �I�C���[�p�ւ̕ϊ�
        Vector3 rotationAngles = rotation.eulerAngles;
        isActivate = true;
        switch (isOpen) {
            case false:

                // X����90�x��]
                for (int i = 0; i < (maxAngle - startAngle) / RotSpeed; i++) {
                    rotationAngles.x += RotSpeed;
                    rotation = Quaternion.Euler(rotationAngles);
                    transform.localRotation = rotation;
                    yield return null;
                }
                isOpen = false;
                break;
            case true:
                // X����90�x��]
                for (int i = 0; i < (startAngle) / RotSpeed; i++) {
                    rotationAngles.x -= RotSpeed;
                    rotation = Quaternion.Euler(rotationAngles);
                    transform.localRotation = rotation;
                    yield return null;
                }
                isOpen = true;
                break;
        }
        isActivate = false;
        yield break;
    }
}
