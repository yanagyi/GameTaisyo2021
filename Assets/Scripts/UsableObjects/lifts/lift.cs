using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift : MonoBehaviour
{
    public float posMaximum;
    public float posMinimum;
    public float wP;
    Rigidbody rb;
    const float moveSpeed = 0.125f;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveOn() {

        if ((transform.localPosition.y<posMaximum)&&(Input.GetKey(KeyCode.UpArrow)|| Input.GetAxis("Vertical") > 0)) {
            rb.MovePosition(gameObject.transform.position + new Vector3(0, moveSpeed, 0));
        }
        if ((transform.localPosition.y > posMinimum) && (Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("Vertical") < 0)) {
            rb.MovePosition(gameObject.transform.position + new Vector3(0, -moveSpeed,0));
        }
        wP = transform.localPosition.y;
    }
}
