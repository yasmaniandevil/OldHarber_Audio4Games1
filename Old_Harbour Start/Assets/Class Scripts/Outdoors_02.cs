using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Outdoors_02 : MonoBehaviour
{

    public AudioMixerSnapshot highWind;
    public AudioMixerSnapshot lowWind;
    public AudioMixer Mixxy;

    public float transTime;


    void Start() {

        Mixxy.SetFloat("OceanSend", -80f);
    }





    private void OnTriggerEnter(Collider other)
    {
        highWind.TransitionTo(transTime);
        Mixxy.SetFloat("OceanSend", 0f);
    }


    private void OnTriggerExit(Collider other)
    {
        lowWind.TransitionTo(transTime);
        Mixxy.SetFloat("OceanSend", -50f);
    }   

  }