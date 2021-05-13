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

    void Start()
    {
        uiManagerObject = GameObject.Find("UiManager");
        _uiManager = uiManagerObject.GetComponent<UiManager>();

        dataManagerObject = GameObject.Find("DataManager");
        dataManager = dataManagerObject.GetComponent<DataManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        dataManager.SetStageClear(StageManager.GetNowLevel(), true);
        dataManager.SetStageUnlock(StageManager.GetNowLevel() + 1, true);

        _uiManager.SetState((int)UiManager.State.Result);
    }
}
