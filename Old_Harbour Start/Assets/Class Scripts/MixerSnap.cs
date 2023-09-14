using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerSnap : MonoBehaviour
{

    public AudioMixerSnapshot indoorSnap;
    public AudioMixerSnapshot outdoorSnap;


    private void OnTriggerEnter(Collider other)
    {
        indoorSnap.TransitionTo(0.5f);
    }


    private void OnTriggerExit(Collider other)
    {
        outdoorSnap.TransitionTo(0.5f);
    }
}


