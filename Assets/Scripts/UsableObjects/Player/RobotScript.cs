using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript : MonoBehaviour
{
    public bool isZenmai;//プレイヤーによってオンオフされる
    Rigidbody rb;
    public Vector3 moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

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
