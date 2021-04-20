using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject stageMng;
    StageManager StageManagerScript;
    void Start()
    {
        stageMng = GameObject.Find("StageManager");
        StageManagerScript = stageMng.GetComponent<StageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            return;
        StageManagerScript.AdvanceGame();
    }
}
