using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{

    [SerializeField] AudioClip triggerAudio;
    AudioSource triggerSource;

    void Start()
    {

        triggerSource = GetComponent<AudioSource>();
        triggerSource.clip = triggerAudio;
    }


    private void OnTriggerEnter(Collider other)
    {
        triggerSource.Play(); 
    }



    private void OnTriggerExit(Collider other)
    {
        triggerSource.Stop();
    }
}
