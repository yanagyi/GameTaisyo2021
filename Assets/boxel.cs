using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxel : MonoBehaviour
{
    string targetTag;
    bool canDestroy;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        targetTag = transform.root.gameObject.GetComponent<boxel_Root>().TargetsTag;
        canDestroy = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canDestroy)
            return;
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != targetTag)
            return;
        transform.parent = null;
        rb.isKinematic = false;
        //GetComponent<BoxCollider>().isTrigger = true;
        StartCoroutine("Destruct");
    }
   IEnumerator  Destruct()
    {
        int Count = 5;
        for(int i = 0; i < Count; i++) {
            yield return new WaitForSeconds(1.0f);
        }
        canDestroy = true;

        yield break;
    }
}
