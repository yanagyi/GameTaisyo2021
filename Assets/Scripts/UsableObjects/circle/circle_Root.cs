using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle_Root : UsableObject
{
    // Start is called before the first frame update
    public GameObject circleObj;
    circle circleScript;
    void Start()
    {
        isZenmai = false;
        circleScript = circleObj.GetComponent<circle>();
    }

    // Update is called once per frame
    void Update()
    {
        circleObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
        circleObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        circleObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
        if (isZenmai == false) {
            circleObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            return;
        }
        //いったん全解除
        circleObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        //回転ロック
        circleObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
        circleObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
        circleObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
        //位置ロック
        circleObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
        circleObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
        circleScript.MoveOn();
    }
}
