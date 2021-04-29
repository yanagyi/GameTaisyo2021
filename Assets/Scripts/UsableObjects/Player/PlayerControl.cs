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
    bool nowFall;
    // Start is called before the first frame update
    void Start()
    {
      
        rb = gameObject.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isZenmai == false&&nowFall==false)
            return;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0) {
            rb.MovePosition(gameObject.transform.position + new Vector3(0, 0, -moveSpeed));
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0) {
            rb.MovePosition(gameObject.transform.position + new Vector3(0, 0, moveSpeed));
        }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(button)) {
            Gravity_Effect();
        }
    }
    public void Gravity_Effect()
    {
        Physics.gravity *= -1.0f;
    }

    IEnumerator GravityEffect()
    {
        Gravity_Effect();
        do {
            
            yield return null;
        } while (nowFall == true);
        yield break;
    }
    private void OnCollisionEnter(Collision collision)
    {

    }
}