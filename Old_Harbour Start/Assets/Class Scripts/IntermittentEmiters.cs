using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermittentEmiters : MonoBehaviour
{

    AudioSource intermittent;
    [SerializeField]
    AudioClip[] audioFiles;

    [Range(0f, 1f)]
    public float sourceVol, minRandom, maxRandom;

    [Range(0f, 30f)]
    public float minTime, maxTime;

    [Range(0f, 1f)]
    public float spatialSetting;

    // cache audio source, and if none is present, add one in code.
    void Awake() {

        intermittent = GetComponent<AudioSource>();

        if (intermittent == null)
        {
            intermittent = gameObject.AddComponent<AudioSource>();
        }
    }



    void Start()
    {
        intermittent.loop = false;
        StartCoroutine("WaitForIt");

    }

    // Assign values from the UI to the audio source prior to playing it.
    void SetProperties(AudioClip PCM, float volume, float minVol, float maxVol, float spatialSound) {

        intermittent.clip = PCM;
        intermittent.spatialBlend = spatialSound;
        intermittent.volume = volume + Random.Range(minVol, maxVol);
    }


    // Select a clip at random, call set properties, play the audiosource and the coroutine for waiting.
    void PlaySound() {

        int index = Random.Range(0, audioFiles.Length);
        SetProperties(audioFiles[index], sourceVol, minRandom, maxRandom, spatialSetting);
        intermittent.Play();
        StartCoroutine("WaitForIt");
    }


    //This coroutine is going to wait by a random amout of time between min/max specified by the player.
    IEnumerator WaitForIt(){



        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        PlaySound();


    }

    void Update()
    {
        
    }
}
