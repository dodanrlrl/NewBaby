using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("BGM")]
    public AudioClip[] bgmClips;
    public float bgmVolume;
    AudioSource bgmPlayer;

    public enum BGM
    {
        Start,
        InGame,
        Boss
    }

    [Header("Effect")]
    public AudioClip[] effectClips;
    public float effectVolume;
    public int channels;
    AudioSource[] effectPlayers;
    int channelIndex;

    public enum Effect
    {
        Dead,
        Hit,
        Melee,
        Range,
        Lose,
        Select,
        Win,
        Pickup
    }

    private static SoundManager _instance;
    public static SoundManager Instance
    {
        get
        {
            if (null == _instance)
            {
                return null;
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (null == _instance)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        Init();
    }
    private void Start()
    {
        SoundManager.Instance.PlayBGM(BGM.Start);
    }
    private void Init()
    {
        //배경음 플레이어 초기화
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;


        //효과음 플레이어 초기화
        GameObject effectObject = new GameObject("EffectPlayer");
        effectObject.transform.parent = transform;
        effectPlayers = new AudioSource[channels];

        for(int i = 0; i < effectPlayers.Length; i++)
        {
            effectPlayers[i] = effectObject.AddComponent<AudioSource>();
            effectPlayers[i].playOnAwake = false;
            effectPlayers[i].volume = effectVolume;
        }

    }
    public void PlayEffect(Effect effect)
    {
        for(int index = 0; index < effectPlayers.Length; index++)
        {
            int loopIndex = (channelIndex + index) % effectPlayers.Length;

            if (effectPlayers[loopIndex].isPlaying)
            {
                continue;
            }

            channelIndex = loopIndex;
            effectPlayers[loopIndex].clip = effectClips[(int)effect];
            effectPlayers[loopIndex].Play();
            break;
        }
    }
    public void PlayBGM(BGM bgm)
    {
        bgmPlayer.Stop();
        bgmPlayer.clip = bgmClips[(int)bgm];
        bgmPlayer.Play();
    }
}
