using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject uiManagerObject;
    UiManager _uiManager;

    GameObject dataManagerObject;
    DataManager dataManager;

    private GameObject player;
    private PlayerControl playerScript;

    void Start()
    {
        uiManagerObject = GameObject.Find("UiManager");
        _uiManager = uiManagerObject.GetComponent<UiManager>();

        dataManagerObject = GameObject.Find("DataManager");
        dataManager = dataManagerObject.GetComponent<DataManager>();

        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        playerScript.playerGrasp();

        dataManager.SetStageClear(StageManager.GetNowLevel() + 1, true);

        if(StageManager.GetNowLevel() + 2 <= 21)
        {
            dataManager.SetStageUnlock(StageManager.GetNowLevel() + 2, true);
        }

        dataManager.Save();

        _uiManager.SetNextState((int)UiManager.State.Result);
    }
}
