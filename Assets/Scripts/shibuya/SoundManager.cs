using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    //オーディオソース設定
    [SerializeField]
    private AudioSource BGMAudioSource;
    [SerializeField]
    private AudioSource SEAudioSource;

    //音源を入れる変数
    [SerializeField]
    private AudioClip[] BGM;


    [SerializeField]
    private AudioClip[] SE;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //他のシーンでも消えない
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    //====BGM====
    public void Play_BGM_CLEAR()
    {
        BGMAudioSource.Stop();
        BGMAudioSource.PlayOneShot(BGM[0]);
    }

    public void Play_BGM_GAME()
    {
        BGMAudioSource.Stop();
        BGMAudioSource.PlayOneShot(BGM[1]);
    }

    public void Play_BGM_SELECT()
    {
        BGMAudioSource.Stop();
        BGMAudioSource.PlayOneShot(BGM[2]);
    }

    public void Play_BGM_TITLE()
    {
        BGMAudioSource.Stop();
        BGMAudioSource.PlayOneShot(BGM[3]);
    }

    public void Play_BGM_TUTORIAL()
    {
        BGMAudioSource.Stop();
        BGMAudioSource.PlayOneShot(BGM[4]);
    }

    public void Play_BGM_GAMEOVER()
    {
        BGMAudioSource.Stop();
        BGMAudioSource.PlayOneShot(BGM[5]);
    }


    //====SE====
    public void Play_SE_Cancel()
    {
        SEAudioSource.PlayOneShot(SE[0]);
    }

    public void Play_SE_Deside()
    {
        SEAudioSource.PlayOneShot(SE[1]);
    }

    public void Play_SE_Ground_Collision()
    {
        SEAudioSource.PlayOneShot(SE[2]);
    }

    public void Play_SE_Item_Active()
    {
        SEAudioSource.PlayOneShot(SE[3]);
    }

    public void Play_SE_Item_Passive()
    {
        SEAudioSource.PlayOneShot(SE[4]);
    }

    public void Play_SE_Object_Active()
    {
        SEAudioSource.PlayOneShot(SE[5]);
    }

    public void Play_SE_Object_Passive()
    {
        SEAudioSource.PlayOneShot(SE[6]);
    }

    public void Play_SE_Object_Unusable_Collision()
    {
        SEAudioSource.PlayOneShot(SE[7]);
    }

    public void Play_SE_Object_Usable_Collision()
    {
        SEAudioSource.PlayOneShot(SE[8]);
    }

    public void Play_SE_Remove_Item()
    {
        SEAudioSource.PlayOneShot(SE[9]);
    }

    public void Play_SE_Result()
    {
        SEAudioSource.PlayOneShot(SE[10]);
    }

    public void Play_SE_Retry()
    {
        SEAudioSource.PlayOneShot(SE[11]);
    }

    public void Play_SE_Start()
    {
        SEAudioSource.PlayOneShot(SE[12]);
    }

    public void Play_SE_Use_Item()
    {
        SEAudioSource.PlayOneShot(SE[13]);
    }

    public void Play_SE_Landing()
    {
        SEAudioSource.PlayOneShot(SE[14]);
    }

}
