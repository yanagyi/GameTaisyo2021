using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obeyCamera : MonoBehaviour
{
    public GameObject player;
    public Vector3 cameraPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPos + player.transform.position;
    }
}
