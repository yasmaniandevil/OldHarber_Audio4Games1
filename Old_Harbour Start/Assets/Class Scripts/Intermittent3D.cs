using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Intermittent3D : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject Bird;
    GameObject temp;

    public AudioClip emitter;
    AudioSource speaker;

    public AudioClip[] Seagulls;

    double life;
    [SerializeField] [Range(0f, 90f)] float minTime, maxTime;

    public bool inCoroutine;


    void Awake() {

    }

    void Start()
    {
        StartCoroutine(Generate());
    }



    void PlaySound()
    {
       temp = (GameObject)Instantiate(Bird, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10)), Quaternion.identity);
        speaker = temp.GetComponent<AudioSource>();
        speaker.clip = Seagulls[Random.Range(0, Seagulls.Length)];
        speaker.Play();
        life = Time.time + 5.0;
    }

    // Antipattern



    void Update()
    {
        if (life <= Time.time)
        {
            {
               Destroy(temp);
                GoAgain();
            }
        }
    }

        void GoAgain()
        {
            if (!inCoroutine)
            {
              StartCoroutine(Generate());
            }
        }


        IEnumerator Generate()
        {
            inCoroutine = true;
            float waitTime = Random.Range(minTime, maxTime);
            Debug.Log(waitTime);

            yield return new WaitForSeconds(waitTime);
            PlaySound();
            inCoroutine = false;
        }


    }



