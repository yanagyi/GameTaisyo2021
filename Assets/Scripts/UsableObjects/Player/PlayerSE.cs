
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
        // �A�^�b�`�����I�[�f�B�I�\�[�X�̂���1�Ԗڂ��g�p����
        source = GetComponents<AudioSource>()[0];

        for (int i = 0; i < listAudioClips.Count(); ++i)
            tagToIndex.Add(listAudioClips[i].groundTypeTag, i);
    }

    public void RelayedTrigger(Collider other)
    {
        // ���炩����GameObject�ɕt���Ă�������������p�̃^�O���擾����
        if (tagToIndex.ContainsKey(other.gameObject.tag))
            groundIndex = tagToIndex[other.gameObject.tag];
    }

    public void PlaySE_Footstep()
    {
        // groundIndex�ŌĂяo���I�[�f�B�I�N���b�v��ς���
        AudioClip[] clips = listAudioClips[groundIndex].audioClips;

        if (randomizePitch)
            source.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);

        source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }
}