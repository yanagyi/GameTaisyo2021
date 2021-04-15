using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasingTest : MonoBehaviour
{
    private float time;

    void Start()
    {
        time = 0.0f;
    }

    void Update()
    {
        // イージング関数使用例
        time += 0.5f;

        if(time > 100.0f)
        {
            time = 100.0f;
        }

        Vector3 pos = this.gameObject.transform.position;
        this.gameObject.transform.position = new Vector3(pos.x, pos.y, Easing.CircleInOut(time, 100.0f, 0.0f, 10.0f));
    }
}
