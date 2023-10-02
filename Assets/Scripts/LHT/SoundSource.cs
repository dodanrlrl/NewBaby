using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum soundType
{
    bgm,
    effect
}
public class SoundSource : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    public soundType soundType;

    public void Play(AudioClip audio)
    {
        _audioSource.Stop();
        _audioSource.clip = audio;
        _audioSource.Play();
    }

    public void Disable()
    {
        _audioSource.Stop();
    }
    
}
