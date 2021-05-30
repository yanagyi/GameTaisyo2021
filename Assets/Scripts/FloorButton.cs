using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour
{
    public bool isTrigger;
    public GameObject ControlObject;
     SwitchObjectsScript CtrlObjScript;
    public GameObject SoundObject;
    // Start is called before the first frame update
    void Start()
    {
        CtrlObjScript = ControlObject.GetComponent<SwitchObjectsScript>();
        SoundObject = GameObject.Find("SoundManager");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
        if (collision.gameObject.tag == "Player") {
            isTrigger = true;
            CtrlObjScript.CallActionOn();
            SoundObject.GetComponent<SoundManager>().Play_SE_Object_Active();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        isTrigger = false;
        CtrlObjScript.CallActionOff();
    }
}
