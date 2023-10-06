﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerSnap : MonoBehaviour
{

    public AudioMixerSnapshot indoorSnap;
    public AudioMixerSnapshot outdoorSnap;
    public float ChangeSecs;

    private void OnTriggerEnter(Collider other)
    {
        indoorSnap.TransitionTo(ChangeSecs);
        Debug.Log("Trigger Enter" + indoorSnap);
    }


    private void OnTriggerExit(Collider other)
    {
        outdoorSnap.TransitionTo(ChangeSecs);
        Debug.Log("Trigger Enter" + outdoorSnap);
    }

}


