using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{
    public GameObject Root;
    circle_Root RootsScript;
    Rigidbody rb;
    GameObject player;
    PlayerControl playerScript;
    const float moveSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        RootsScript = Root.GetComponent<circle_Root>();

        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MoveOn() {
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("Horizontal") < 0)) {
            rb.angularVelocity = new Vector3(-moveSpeed, 0, 0);
        }
        else if ((Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("Horizontal") > 0)) {
            rb.angularVelocity = new Vector3(moveSpeed, 0, 0);
        }
        else
        {
        }

    }
    public bool isZenmai()
    {
        return RootsScript.isZenmai;
    }
}
