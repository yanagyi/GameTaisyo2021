using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : UsableObject
{
 //   public bool isZenmai;
   public Rigidbody rb;
    public float moveSpeed;//= 0.25f;
    public string button;
    bool onTheWall;
    // Start is called before the first frame update
    void Start()
    {
      
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (isZenmai == false)
        //    return;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0) {
            StartCoroutine("Move", new Vector3(0, 0, -moveSpeed));
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0) {
            StartCoroutine("Move", new Vector3(0, 0, moveSpeed));
        }
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(button)) {
            Gravity_Effect();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Object")
            return;

    }
    IEnumerator  Move(Vector3 MoveWay)
    {
        rb.AddForce(MoveWay, ForceMode.Acceleration);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        yield return null;
    }
    IEnumerator ChangeGravity()
    {

        yield return null;
    }
}