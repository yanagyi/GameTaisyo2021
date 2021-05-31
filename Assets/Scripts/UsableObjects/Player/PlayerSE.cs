
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(AudioSource))]
public class PlayerSE : MonoBehaviour
{
    [System.Serializable]
    public class AudioClips
    {
        public string groundTypeTag;
        public AudioClip[] audioClips;
    }

    [SerializeField] List<AudioClips> listAudioClips = new List<AudioClips>();
    [SerializeField] bool randomizePitch = true;
    [SerializeField] float pitchRange = 0.1f;

    private Dictionary<string, int> tagToIndex = new Dictionary<string, int>();
    private int groundIndex = 0;

    protected AudioSource source;

    private void Awake()
    {
        // アタッチしたオーディオソースのうち1番目を使用する
        source = GetComponents<AudioSource>()[0];

        for (int i = 0; i < listAudioClips.Count(); ++i)
            tagToIndex.Add(listAudioClips[i].groundTypeTag, i);
    }

    public void RelayedTrigger(Collider other)
    {
        // あらかじめGameObjectに付けておいた足音判定用のタグを取得する
        if (tagToIndex.ContainsKey(other.gameObject.tag))
            groundIndex = tagToIndex[other.gameObject.tag];
    }

    public void PlaySE_Footstep()
    {
        // groundIndexで呼び出すオーディオクリップを変える
        AudioClip[] clips = listAudioClips[groundIndex].audioClips;

        if (randomizePitch)
            source.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);

        source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }
}