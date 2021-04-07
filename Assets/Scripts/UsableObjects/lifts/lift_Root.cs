using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift_Root : UsableObject
{
  //  public bool isZenmai;
    public GameObject lift;
    lift liftScript;
    // Start is called before the first frame update
    void Start()
    {
        isZenmai = false;
        liftScript = lift.GetComponent<lift>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isZenmai == false) {
            lift.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            return;
        }
        //いったん全解除
        lift.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        //回転ロック
        lift.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
        lift.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
        lift.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
        //位置ロック
        lift.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
        lift.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
        liftScript.MoveOn();
    }
}
