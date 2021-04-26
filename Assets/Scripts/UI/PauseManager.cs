using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Pause(bool flag)
    {
        if(flag == true)
        {
            Time.timeScale = 1.0f;
        }
        if(flag == false)
        {
            Time.timeScale = 0.0f;
        }
    }
}
