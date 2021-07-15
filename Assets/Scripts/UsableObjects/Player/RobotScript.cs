using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript : UsableObject
{
   // public bool isZenmai;//プレイヤーによってオンオフされる
    Rigidbody rb;
    public Vector3 moveSpeed;
    public bool oldZenmai;
    // Start is called before the first frame update
    void Start()
    {
        oldZenmai = isZenmai;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (oldZenmai == isZenmai)
            return;
        switch (isZenmai) {

            case true:
                FreezeOff();
                break;
            case false:
                FreezeOn();
                break;
        }
    }
    private void FixedUpdate()
    {
        if (!isZenmai)

            return;

        if (Input.GetAxis("Horizontal") < 0) {
            rb.MovePosition(transform.position - moveSpeed);
        } else if (Input.GetAxis("Horizontal") > 0) {
            rb.MovePosition(transform.position + moveSpeed);
        }
    }
    public void FreezeOn()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
    public void FreezeOff()
    {
        rb.constraints = RigidbodyConstraints.None;

        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
}
