using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    //オーディオソース設定
    [SerializeField] private AudioSource BGMAudioSource;
    [SerializeField] private AudioSource SEAudioSource;

    //音源を入れる変数
    [SerializeField] private AudioClip[] BGM;


    [SerializeField] private AudioClip[] SE;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            BGMAudioSource.PlayOneShot(BGM[1]);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SEAudioSource.PlayOneShot(SE[1]);
        }
        */
    }

    //他のシーンでも消えない
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
