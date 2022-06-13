using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudio : AudioPlayer
{
    [SerializeField]
    private AudioClip _shootBulletClip = null, _outOfBulletClip = null;

    public void PlayShootSound()
    {
        PlayClip(_shootBulletClip);
    }

    public void PlayNoBulletsSound()
    {
        PlayClip(_outOfBulletClip);
    }
}
