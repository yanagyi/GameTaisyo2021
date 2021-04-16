using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    Vector2 senterPosition;
    Vector2 rotationPosition;
    float startTime;

    // Start is called before the first frame update
    void Start()
    {
        senterPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        startTime = Time.time + 0.5f;
        
        float T = 1.0f;
        float f = 1.0f / T;
        rotationPosition = senterPosition;
        rotationPosition.y += Mathf.Cos(2 * Mathf.PI * f * startTime);
        transform.position = rotationPosition;
    }
}