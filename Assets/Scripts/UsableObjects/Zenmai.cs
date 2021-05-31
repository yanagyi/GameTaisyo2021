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

    private int triggerObjectType;
    private GameObject triggerObject;

    private enum triggerObjectPattern
    {
        None = 0,
        Player = 1,
        ZenmaiObject = 2,
    }

    private enum statePattern
    {
        Idle=0,
        Controlled,
        ParentCheck,
    }

    // Start is called before the first frame update
    void Start()
    {
        triggerObjectType = (int)triggerObjectPattern.None;

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

            return;
        }
        if (nowParent == null) {
            Setparent(GameObject.Find(oldParent.name));
            if (oldParent == null) {
                Setparent(GameObject.Find("Player"));
                playerScript.SetKinematic(false);
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

        //playerScript.playerGrasp();

        //最寄りのゼンマイオブジェクト捜索
        gameObject.transform.position+=new Vector3(0, Input.GetAxis("Vertical")*SpeedMag, Input.GetAxis("Horizontal") * SpeedMag);
    }

    private void ParentCheck()
    {
        if (triggerObjectType == (int)triggerObjectPattern.None)
        {
            Setparent(oldParent);
            state = (int)statePattern.Idle;
        }
        if (triggerObjectType == (int)triggerObjectPattern.Player)
        {
            Setparent(triggerObject);
            state = (int)statePattern.Idle;
        }
        if (triggerObjectType == (int)triggerObjectPattern.ZenmaiObject)
        {
            Setparent(triggerObject);
            state = (int)statePattern.Idle;
        }
    }

    public void Setparent(GameObject obj)
    {
        nowParent = obj;
        nowParent.GetComponent<UsableObject>().isZenmai = true;
        oldParent = nowParent;
        gameObject.transform.parent = nowParent.transform;
        if (obj.tag == "Player") {
            gameObject.transform.localPosition = SetByPlayerPos;
            playerScript.SetKinematic(false);
        } else {
            gameObject.transform.localPosition = SetByObjPos;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ZenmaiTriggerEnter.ObjName:" + other.gameObject.name);
        Debug.Log(other.gameObject.tag);

        if (other.gameObject.tag == "Player")
        {
            triggerObjectType = (int)triggerObjectPattern.Player;
            triggerObject = other.gameObject;
        }
        else if (other.gameObject.tag == "zenmaiObj")
        {
            triggerObjectType = (int)triggerObjectPattern.ZenmaiObject;
            triggerObject = other.gameObject;
        }
        else
        {
            triggerObjectType = (int)triggerObjectPattern.None;
            triggerObject = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("ZenmaiTriggerEnter.ObjName:" + other.gameObject.name);
        Debug.Log(other.gameObject.tag);

        if (other.gameObject.tag == "Player")
        {
            triggerObjectType = (int)triggerObjectPattern.Player;
            triggerObject = other.gameObject;
        }
        else if (other.gameObject.tag == "zenmaiObj")
        {
            triggerObjectType = (int)triggerObjectPattern.ZenmaiObject;
            triggerObject = other.gameObject;
        }
        else
        {
            triggerObjectType = (int)triggerObjectPattern.None;
            triggerObject = null;
        }
    }

    public int GetState() { return state; }//0がIdle,1がコントロール、2がチェック
    
}
