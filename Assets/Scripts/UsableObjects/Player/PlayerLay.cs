using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLay : MonoBehaviour
{
    Ray upRay;
    Ray downRay;
    RaycastHit hit;
    public float RayLength;
    // Start is called before the first frame update
    void Start()
    {
        upRay = new Ray(transform.position, Vector3.up * RayLength);
        downRay = new Ray(transform.position, Vector3.down * RayLength);

    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(transform.position, Vector3.up* RayLength, Color.blue,2.0f,false);
        Debug.DrawRay(transform.position, Vector3.down * RayLength, Color.blue, 2.0f, false);
    }
    void UpRayCollision()
    {
        if (Physics.Raycast(upRay, out hit, RayLength)) {
            Debug.Log("Hit:UpRay");
        }
    }
    void DownRayCollision()
    {
        if (Physics.Raycast(downRay, out hit, RayLength)) {
            Debug.Log("Hit:downRay");
        }
    }
    void GraspObject(GameObject GraspObj)
    {

    }
}
