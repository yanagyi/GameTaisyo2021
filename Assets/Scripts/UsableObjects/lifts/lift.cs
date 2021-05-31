using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift : MonoBehaviour
{
    public float posMaximum;
    public float posMinimum;
    Rigidbody rb;
    const float moveSpeed = 0.125f;
    GameObject player;
   PlayerControl playerScript;
    public GameObject Root;
    lift_Root parentsScript;
    private bool firstHit;

    private GameObject pauseManagerObject;
    // Start is called before the first frame update
    void Start()
    {
        firstHit = false;
        player = null;
        playerScript = null;
        rb = gameObject.GetComponent<Rigidbody>();
        parentsScript = Root.GetComponent<lift_Root>();
        pauseManagerObject = GameObject.Find("PauseManager");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MoveOn()
    {

        if ((transform.localPosition.y < posMaximum) && (Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("Vertical") > 0)) {
            rb.MovePosition(gameObject.transform.position + new Vector3(0, moveSpeed, 0));
        }
        else if ((transform.localPosition.y > posMinimum) && (Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("Vertical") < 0)) {
            rb.MovePosition(gameObject.transform.position + new Vector3(0, -moveSpeed, 0));
        }
        else
        {
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //当たった時に親子関係を決定する
        if (collision.gameObject.tag != "Player")
            return;
        if (!firstHit)
        {
            player = collision.gameObject;
            player.transform.parent = gameObject.transform;
            playerScript = player.GetComponent<PlayerControl>();

            firstHit = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            return;
        player.transform.parent = pauseManagerObject.transform;
        player = null;
        firstHit = false;
    }
}


