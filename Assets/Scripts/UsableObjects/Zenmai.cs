using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zenmai : MonoBehaviour
{
    public string LTrigger;
    public string RTrigger;
    float rotateSpeed=1;
    public GameObject oldParent;
    public GameObject nowParent;
    int state;
    private enum statePattern
    {
        Idle=0,
        Controlled,
        ParentCheck,
    }

    // Start is called before the first frame update
    void Start()
    {
        if ((nowParent = gameObject.transform.parent.gameObject) != null) {
            nowParent.GetComponent<UsableObject>().isZenmai = true;
            oldParent = nowParent;
        } else {
            nowParent = null;
        }
        
        state = (int)statePattern.Idle;

    }

    // Update is called once per frame
    void Update()
    {
        switch (state) {
            case (int)statePattern.Controlled:
                Controlled();
                break;
            case (int)statePattern.ParentCheck:
                ParentCheck();
                break;
            case (int)statePattern.Idle:
            default:
                Idle();
                break;
        }
     //Debug.Log("now state:" + state + "@zenmai.cs.update");
    }
    //state==========================================================
    private void Idle()
    {
        if (Input.GetKey(LTrigger)) {
            nowParent.GetComponent<UsableObject>().isZenmai = false;
            state = (int)statePattern.Controlled;
            nowParent = null;
            gameObject.transform.parent = null;
            return;
        }
        if (nowParent == null) {
            nowParent = oldParent;
        }
      
        transform.Rotate(new Vector3(0, rotateSpeed, 0));
    }

   private void Controlled() {
        if (!Input.GetKey(LTrigger)) {
            state = (int)statePattern.ParentCheck;
            return;
        }
        //最寄りのゼンマイオブジェクト捜索
        gameObject.transform.position+=new Vector3(0, Input.GetAxis("Vertical")/4, Input.GetAxis("Horizontal")/4);
    }
    private void ParentCheck() {

        state = (int)statePattern.Idle;
    }

    public void Setparent(GameObject obj)
    {
        nowParent = obj;
        nowParent.GetComponent<UsableObject>().isZenmai = true;
        oldParent = nowParent;
        gameObject.transform.parent = nowParent.transform;
        gameObject.transform.localPosition = new Vector3(0, 1.3f, 0);

    }
    private void OnTriggerStay(Collider other)
    {
        if (state != (int)statePattern.ParentCheck)
            return;
        //入力してんのに当たり判定なかったら戻る
        
        if (other.gameObject.tag == "zenmaiObj"|| other.gameObject.tag == "Player") {
         //   Debug.Log("hit!at" + other.gameObject.name + "@zenmai.cs.OnCollisionEnter");
            Setparent(other.gameObject);
        } else {
        //    Debug.Log("Don't hit any ZenmaiObj" + "@zenmai.cs.OnCollisionEnter");
            Setparent(oldParent);
        }
    }
    public int GetState() { return state; }//0がIdle,1がコントロール、2がチェック
}
