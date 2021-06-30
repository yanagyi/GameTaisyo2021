using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFragManager : MonoBehaviour
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
        
    }

    //“–‚½‚è”»’è
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("hit");

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (robotScript.controlFlag)
                {
                    robotScript.RobotFlagOn();
                }
                else
                {
                    robotScript.RobotFlagOff();
                }
            }
        }
    }

}
