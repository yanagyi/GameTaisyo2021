using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiDoor : SwitchObjectsScript
{
    public GameObject Switch;
    FloorButton ButtonScript;
    public float startAngle;
    public float maxAngle;
    public float RotSpeed;
    public bool isActivate;
    public bool dummy;
    // Start is called before the first frame update
    void Start()
    {
        ButtonScript = Switch.GetComponent<FloorButton>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void CallActionOn()
    {
        Debug.Log("CalledActOn");
        StartCoroutine("OnAction");
    }
    public override void CallActionOff()
    {
        Debug.Log("CalledActOff");
        StartCoroutine("OffAction");
    }
    public override IEnumerator OnAction()
    {
       

        Vector3 position = this.transform.localPosition;
        Quaternion rotation = this.transform.localRotation;
        Vector3 scale = this.transform.localScale;

        // クォータニオン → オイラー角への変換
        Vector3 rotationAngles = rotation.eulerAngles;

        // X軸の90度回転
        for (int i = 0; i < (maxAngle - startAngle) / RotSpeed; i++) {
            rotationAngles.x += RotSpeed;
            rotation = Quaternion.Euler(rotationAngles);
            transform.localRotation = rotation;
            yield return null;
        }
        yield break;
    }
    public override IEnumerator OffAction()
    {

        // Transform値を取得する
        Vector3 position = this.transform.localPosition;
        Quaternion rotation = this.transform.localRotation;
        Vector3 scale = this.transform.localScale;

        // クォータニオン → オイラー角への変換
        Vector3 rotationAngles = rotation.eulerAngles;

        // X軸の90度回転
        for (int i = 0; i < (startAngle) / RotSpeed; i++) {
            rotationAngles.x -= RotSpeed;
            rotation = Quaternion.Euler(rotationAngles);
            transform.localRotation = rotation;
            yield return null;
        }
        yield break;
    }
}
