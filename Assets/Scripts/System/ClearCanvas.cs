using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCanvas : MonoBehaviour
{
    public GameObject stageMng;

    StageManager StageManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        StageManagerScript = stageMng.GetComponent<StageManager>();

        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
 
    }
    public void ClearConfilm()
    {

        gameObject.SetActive(true);

    }
}
