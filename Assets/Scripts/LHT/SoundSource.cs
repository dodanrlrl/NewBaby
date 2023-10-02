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
    private AudioSource _audioSource;
    [SerializeField] private soundType _soundType;
    [SerializeField] private AudioClip _audioClip;

    public void Play(AudioClip clip, float soundEffectVolume, float soundEffectPitchVariance)
    {
        if (_audioSource == null)
            _audioSource = GetComponent<AudioSource>();

        CancelInvoke();
        _audioSource.clip = clip;
        _audioSource.volume = soundEffectVolume;
        _audioSource.Play();
        _audioSource.pitch = 1f + Random.Range(-soundEffectPitchVariance, soundEffectPitchVariance);

        Invoke("Disable", clip.length + 2);
    }

    public void Disable()
    {
        _audioSource.Stop();
        gameObject.SetActive(false);
    }
}
