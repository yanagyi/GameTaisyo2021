using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Gravity_Effect() {
        Physics.gravity *= -1.0f;
    }
}
