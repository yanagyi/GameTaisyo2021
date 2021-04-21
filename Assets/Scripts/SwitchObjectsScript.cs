using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObjectsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void CallActionOn() {
        StartCoroutine("OnAction");
    }
    public virtual void CallActionOff()
    {
        StartCoroutine("OffAction");
    }
   public virtual IEnumerator OnAction()
    {
        yield break;
    }
    public virtual IEnumerator OffAction()
    {
        yield break;
    }
}
