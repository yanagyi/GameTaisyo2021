using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoButton : MonoBehaviour
{

    public GameObject stageMng;

    StageManager StageManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        StageManagerScript = stageMng.GetComponent<RetryGame>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
