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
    { // Transform値を取得する
        Vector3 position = this.transform.localPosition;
        Quaternion rotation = this.transform.localRotation;
        Vector3 scale = this.transform.localScale;

        // クォータニオン → オイラー角への変換
        Vector3 rotationAngles = rotation.eulerAngles;
        isActivate = true;
        // X軸の90度回転
        for (int i = 0; i < (maxAngle-startAngle) / rotationSpeed; i++) {
            rotationAngles.x += rotationSpeed;
            rotation = Quaternion.Euler(rotationAngles);
            transform.localRotation = rotation;
            yield return null;
        }
        /*
        rotationAngles.x = rotationAngles.x + 90.0f;
        Vector3の加算は以下のような書き方も可能
       rotationAngles += new Vector3(90.0f, 0.0f, 0.0f);

        オイラー角 → クォータニオンへの変換
       rotation = Quaternion.Euler(rotationAngles);

        Transform値を設定する
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
        // Transform値を取得する
        Vector3 position = this.transform.localPosition;
        Quaternion rotation = this.transform.localRotation;
        Vector3 scale = this.transform.localScale;

        // クォータニオン → オイラー角への変換
        Vector3 rotationAngles = rotation.eulerAngles;
        
        // X軸の90度回転
        for (int i = 0; i < (startAngle) / rotationSpeed; i++) {
            rotationAngles.x -= rotationSpeed;
            rotation = Quaternion.Euler(rotationAngles);
            transform.localRotation = rotation;
            yield return null;
        }
        /*
        rotationAngles.x = rotationAngles.x + 90.0f;
        Vector3の加算は以下のような書き方も可能
       rotationAngles += new Vector3(90.0f, 0.0f, 0.0f);

        オイラー角 → クォータニオンへの変換
       rotation = Quaternion.Euler(rotationAngles);

        Transform値を設定する
        this.transform.localPosition = position;
        this.transform.localRotation = rotation;
        this.transform.localScale = scale;
        */
        isOpened = false;
        isActivate = false;
        yield break;
    }
}
