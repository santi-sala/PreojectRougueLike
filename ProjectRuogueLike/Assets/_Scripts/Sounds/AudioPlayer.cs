using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class AudioPlayer : MonoBehaviour
{    
    private AudioSource _audioSource;
    [SerializeField]
    private float _pitchRandomness = 0.05f;
    private float _basePitch;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _basePitch = _audioSource.pitch;
    }

    protected void PlayClipWithVariablePitch(AudioClip clip)
    {
        var randomPitch = Random.Range(-_pitchRandomness, _pitchRandomness);
        _audioSource.pitch = randomPitch + _basePitch;
        PlayClip(clip);
    }

    protected void PlayClip(AudioClip clip)
    {
        _audioSource.Stop();
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    
}
