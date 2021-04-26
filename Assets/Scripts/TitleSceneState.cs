using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneState : MonoBehaviour
{
    public string nextSceneName;
    public string DecideButton;
    bool isCalledNext;
    // Use this for initialization
    void Start()
    {
        isCalledNext = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCalledNext==false&&Input.GetKey(DecideButton)) {
            Invoke("ChangeScene", 2.0f);
            isCalledNext = true;
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}