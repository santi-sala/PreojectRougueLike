using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentStepAudioPlayer : AudioPlayer
{
    [SerializeField]
    private AudioClip _stepClip;    

    public void PlayStepSound()
    {
        PlayClipWithVariablePitch(_stepClip);
    }
}
