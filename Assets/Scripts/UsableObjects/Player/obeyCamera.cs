using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obeyCamera : MonoBehaviour
{
    public GameObject player;
    public Vector3 cameraPos;
    public Quaternion cameraRot;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = cameraRot;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPos + player.transform.position;
    }
}
