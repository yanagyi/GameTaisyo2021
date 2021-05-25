using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : SwitchObjectsScript
{
    public GameObject Switch;
    FloorButton ButtonScript;
    public float MaxRot;
    public float RotSpeed;
    public bool isActivate;
    public bool dummy;
    // Start is called before the first frame update
    void Start()
    {
        ButtonScript = Switch.GetComponent<FloorButton>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void CallActionOn()
    {
        StartCoroutine("OnAction");
    }
    public override void CallActionOff()
    {
        StartCoroutine("OffAction");
    }
    public override IEnumerator OnAction()
    {
        isActivate = true;
for(float count=0.0f;count<90.0f;count+=Mathf.Abs(RotSpeed)) {
            transform.Rotate(new Vector3(RotSpeed, 0, 0),Space.World);
            yield return null;
        } 
        isActivate = false;
        yield break;
    }
    public override IEnumerator OffAction()
    {
        isActivate = true;
        for(float count=0.0f;count<90.0f;count+= Mathf.Abs(RotSpeed)) {
            transform.Rotate(new Vector3(-RotSpeed, 0, 0),Space.World) ;
            yield return null;
        } 
        isActivate = false;
        yield break;
    }
}
