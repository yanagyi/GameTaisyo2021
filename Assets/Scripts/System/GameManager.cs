using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //ゲームマネージャーのメモリ領域確保
    public static GameManager instance = null;

    private void Awake()
    {
        //メモリ入れる
        if (instance == null)
        {
            //メモリ
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        //メモリが既に入っている場合破棄
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
