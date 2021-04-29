using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Ashiba : MonoBehaviour
{
   GameObject player;
    PlayerControl playerScript;
    circle parentsScript;
    // Start is called before the first frame update
    void Start()
    {
        player = null;
        playerScript = null;
        parentsScript = gameObject.transform.parent.gameObject.GetComponent<circle>();
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
        player = collision.gameObject;
        player.transform.parent = gameObject.transform;

        playerScript = player.GetComponent<PlayerControl>();
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            return;
       player.gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
        //Rootにねじがついてないときはプレイヤーと親子でない。
        //Rootにねじがついているときのみプレイヤーと親子。
        switch (parentsScript.isZenmai()) {
            case true:
                player = collision.gameObject;
                player.transform.parent = gameObject.transform;

                playerScript = player.GetComponent<PlayerControl>();
                playerGrasp();
                break;
            case false:
                playerGraspOff();
                break;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            return;
        player = null;
        
    }
    public void playerGrasp()
    {
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
        player.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        player.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;

    }
    public void playerGraspOff()
    {
        player.GetComponent<Rigidbody>().isKinematic = false;
        //いったん全解除
        player.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        //回転ロック
        player.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
        player.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
        player.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
        //位置ロック
        player.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;

        player.transform.parent = null;
    }
}
