using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermittentTrigger : MonoBehaviour
{
    [SerializeField]
    private int range;

    [SerializeField]
    private AudioSource triggerSource;

    [SerializeField]
    private AudioClip triggerClip;

    // Start is called before the first frame update
    void Start()
    {
        triggerSource = GetComponent<AudioSource>();
        triggerSource.clip = triggerClip;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Random.Range(0, range) <= 1)
            triggerSource.Play();
    }
    private void OnTriggerExit(Collider other)
    {
        triggerSource.Stop();
    }

}
