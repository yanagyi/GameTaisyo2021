using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Ashiba : MonoBehaviour
{
   GameObject player;
    PlayerControl playerScript;
    circle parentsScript;
    private GameObject pauseManagerObject;
    private bool firstHit;
    // Start is called before the first frame update
    void Start()
    {
        firstHit = false;
        player = null;
        playerScript = null;
        parentsScript = gameObject.transform.parent.gameObject.GetComponent<circle>();
        pauseManagerObject = GameObject.Find("PauseManager");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        //当たった時に親子関係を決定する
        if (collision.gameObject.tag != "Player")
            return;

        if(!firstHit)
        {
            player = collision.gameObject;
            player.transform.parent = gameObject.transform;
            playerScript = player.GetComponent<PlayerControl>();

        }
        firstHit = true;
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
