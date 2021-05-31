using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zenmai : MonoBehaviour
{
    public string LTrigger;
    public string RTrigger;
    public float rotateSpeed=1;
    public GameObject oldParent;
    public GameObject nowParent;
    int state;
    public float SpeedMag;

    private GameObject player;
    private PlayerControl playerScript;
    public GameObject SoundObject;
    public Vector3 SetByPlayerPos;
    public Vector3 SetByObjPos;
    private enum statePattern
    {
        Idle=0,
        Controlled,
        ParentCheck,
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerControl>();

        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().useGravity = false;


        if ((nowParent = gameObject.transform.parent.gameObject) != null) {
            nowParent.GetComponent<UsableObject>().isZenmai = true;
            oldParent = nowParent;
        } else {
            nowParent = null;
        }
        
        state = (int)statePattern.Idle;
        SoundObject = GameObject.Find("SoundManager");
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

        if (Input.GetKey(LTrigger)||Input.GetKey(KeyCode.LeftShift)) {
            nowParent.GetComponent<UsableObject>().isZenmai = false;
            state = (int)statePattern.Controlled;
            nowParent = null;
            gameObject.transform.parent = null;

            playerScript.playerGrasp();

            return;
        }
        if (nowParent == null) {
            Setparent(GameObject.Find(oldParent.name));
            if (oldParent == null) {
                Setparent(GameObject.Find("Player"));
            }
        }
      
        transform.Rotate(new Vector3(0, rotateSpeed, 0));
    }

   private void Controlled() {
        if (!Input.GetKey(LTrigger) && !Input.GetKey(KeyCode.LeftShift))  {
            state = (int)statePattern.ParentCheck;
            playerScript.playerGraspOff();
            return;
        }

        playerScript.playerGrasp();

        //最寄りのゼンマイオブジェクト捜索
        gameObject.transform.position+=new Vector3(0, Input.GetAxis("Vertical")*SpeedMag, Input.GetAxis("Horizontal") * SpeedMag);
    }
    private void ParentCheck() {
        //当たり判定用に例を作る
        Ray upRay;
        Ray downRay;
        RaycastHit hit;
        float RayLength = 5.0f;
        upRay = new Ray(transform.position, Vector3.up * RayLength);
        downRay = new Ray(transform.position, Vector3.down * RayLength);

        if (Physics.Raycast(upRay, out hit, RayLength) || Physics.Raycast(upRay, out hit, RayLength)) {
            if (hit.collider.gameObject.tag == "Player" || hit.collider.gameObject.tag == "zenmaiObj") {
                
                //   Debug.Log("hit!at" + other.gameObject.name + "@zenmai.cs.OnCollisionEnter");
                Setparent(hit.collider.gameObject);
                SoundObject.GetComponent<SoundManager>().Play_SE_Object_Active();
            } else {
                //    Debug.Log("Don't hit any ZenmaiObj" + "@zenmai.cs.OnCollisionEnter");
                Setparent(oldParent);
                SoundObject.GetComponent<SoundManager>().Play_SE_Object_Passive();
            }
        }

        state = (int)statePattern.Idle;
        state = (int)statePattern.Idle;
    }

    public void Setparent(GameObject obj)
    {
        nowParent = obj;
        nowParent.GetComponent<UsableObject>().isZenmai = true;
        oldParent = nowParent;
        gameObject.transform.parent = nowParent.transform;
        if (obj.tag == "Player") {
            gameObject.transform.localPosition = SetByPlayerPos;
        } else {
            gameObject.transform.localPosition = SetByObjPos;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (state != (int)statePattern.ParentCheck)
            return;
        //入力してんのに当たり判定なかったら戻る

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "zenmaiObj") {
            //   Debug.Log("hit!at" + other.gameObject.name + "@zenmai.cs.OnCollisionEnter");
            Setparent(other.gameObject);
        } else {
            //    Debug.Log("Don't hit any ZenmaiObj" + "@zenmai.cs.OnCollisionEnter");
            Setparent(oldParent);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (state != (int)statePattern.ParentCheck)
            return;
        //入力してんのに当たり判定なかったら戻る

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "zenmaiObj") {
            //   Debug.Log("hit!at" + other.gameObject.name + "@zenmai.cs.OnCollisionEnter");
            Setparent(other.gameObject);
        } else {
            //    Debug.Log("Don't hit any ZenmaiObj" + "@zenmai.cs.OnCollisionEnter");
            Setparent(oldParent);
        }
    }
    public int GetState() { return state; }//0がIdle,1がコントロール、2がチェック
    
}
