using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CanvasNext;
    ClearCanvas ClearCanvas;
    void Start()
    {
        CanvasNext = GameObject.Find("ClearCanvas");
        ClearCanvas = CanvasNext.GetComponent<ClearCanvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            return;
        ClearCanvas.ClearConfilm();
    }
}
