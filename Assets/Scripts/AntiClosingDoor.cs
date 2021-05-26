using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiClosingDoor : SwitchObjectsScript
{
    public GameObject Switch;
    FloorButton ButtonScript;
    public float RotSpeed;
    public bool isActivate;
    public bool dummy;
    bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        ButtonScript = Switch.GetComponent<FloorButton>();
        isOpen = false;
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
        return;
    }
    public override IEnumerator OnAction()
    {
        isActivate = true;
        float count = 0;
        switch (isOpen) {
            case true:
                do {
                    transform.Rotate(new Vector3(RotSpeed, 0, 0), Space.World);
                    count += RotSpeed;
                    yield return null;
                } while (count < 90.0f);
                isOpen = false;
                break;
            case false:
                do {
                    transform.Rotate(new Vector3(-RotSpeed, 0, 0), Space.World);
                    yield return null;
                    count += RotSpeed;
                } while (count < 90.0f);
                isOpen = true;
                break;
        }

        isActivate = false;
        yield break;
    }
    public override IEnumerator OffAction()
    {
        isActivate = true;
        float count = 0;
        do {
            transform.Rotate(new Vector3(RotSpeed, 0, 0), Space.World);
            count += RotSpeed;
            yield return null;
        } while (count < 90.0f);
        isActivate = false;
        yield break;
    }
}
