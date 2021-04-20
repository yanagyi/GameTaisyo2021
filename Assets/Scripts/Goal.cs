using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ClearCanvasObj;

    ClearCanvas ClearCanvasScript;
    void Start()
    {
    //    stageMng = GameObject.Find("StageManager");
//       stageMng = GameObject.Find("ClearCanvas");
        ClearCanvasScript = ClearCanvasObj.GetComponent<ClearCanvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            return;
        ClearCanvasScript.ClearConfilm();

    }
}
