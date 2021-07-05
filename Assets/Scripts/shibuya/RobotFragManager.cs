using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFragManager : UsableObject
{

    public GameObject Robot;
    RobotControl robotScript;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       robotScript. GetControllFlg(isZenmai);
        //if (!isZenmai)
        //    return;


        //if (Input.GetKeyDown(KeyCode.Space)) {
        //    if (robotScript.controlFlag) {
        //        robotScript.RobotFlagOn();
        //    } else {
        //        robotScript.RobotFlagOff();
        //    }
        //}
    }

    //“–‚½‚è”»’è
    //private void OnCollisionStay(Collision other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Debug.Log("hit");

    //        if (Input.GetKeyDown(KeyCode.Space))
    //        {
    //            if (robotScript.controlFlag)
    //            {
    //                robotScript.RobotFlagOn();
    //            }
    //            else
    //            {
    //                robotScript.RobotFlagOff();
    //            }
    //        }
    //    }
    //}

}
