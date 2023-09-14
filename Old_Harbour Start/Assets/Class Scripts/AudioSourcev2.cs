using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourcev2 : MonoBehaviour
{

    private AudioSource _AudioSpeaker;
    private AudioLowPassFilter _lpFilter;
    public AudioClip sampleClip;

    public bool loop = false;
    [Range(0f, 1f)]
    public float volume = 0.2f;
    [Range(-3f, 3f)]
    public float pitch = 0.9f;
    [Range(0f, 1f)]
    public float spatialBlend = 0f;
    [Range(-2f, 2f)]
    public float minPitchRange = 1f;
    [Range(-1f, 2f)]
    public float maxPitchRange = 0.5f;
    [Range(0f, 1f)]
    public float minAmpRange = 0.5f;
    [Range(0f, 1f)]
    public float maxAmpRange = 0.5f;
    [Range(0f, 500)]
    public int minDistance = 5;
    [Range(0f, 500)]
    public int maxDistance = 25;
    [SerializeField]
    [Range(0f, 20000f)]
    float lpfFreak = 1000f;

    private RaycastHit occluderRayHit;
    GameObject listener;

    public List<AudioClip> clips = new List<AudioClip>();
    int index;



        void Awake()
        {
           
            _AudioSpeaker = GetComponent<AudioSource>();

                if (_AudioSpeaker == null)
                {
                    _AudioSpeaker = gameObject.AddComponent<AudioSource>();
                   
                }

                _lpFilter = GetComponent<AudioLowPassFilter>();
                if (_lpFilter == null)
                {
                    _lpFilter = gameObject.AddComponent<AudioLowPassFilter>();
                }

        }

    // Use this for initialization
        void Start()
        {
            if (listener = GameObject.Find("Player"))
                Debug.Log("GotiT!!");
            
           
            if (clips.Count != 0)
            {
                _AudioSpeaker.clip = clips[Random.Range(0, clips.Count - 1)];

                PlayAudio();
            }

            else
            {
                _AudioSpeaker.clip = sampleClip;
                PlayAudio();
            }

        }

        public void SetSourceProperties(AudioClip sampleClip, float volume, float pitch, bool loop, float minRange, float maxRange, float spatialBlend, float minAmpRange, float maxAmpRange, int minDistance, int maxdistance)
        {


            _AudioSpeaker.pitch = pitch + Random.Range(minPitchRange, maxPitchRange);
            _AudioSpeaker.volume = volume + (Random.Range(minAmpRange, maxAmpRange));
            _AudioSpeaker.loop = loop;
           _AudioSpeaker.spatialBlend = spatialBlend;
            _AudioSpeaker.minDistance = minDistance;
            _AudioSpeaker.maxDistance = maxDistance;


        }

        public void PlayAudio()
        {

            SetSourceProperties(sampleClip, volume, pitch, loop, minPitchRange, maxPitchRange, spatialBlend, minAmpRange, maxAmpRange, minDistance, maxDistance);
            _AudioSpeaker.Play();
        }

      

        float CheckForDistance(GameObject obj, float distance)
        {


        float dist = Vector3.Distance(obj.transform.position, transform.position);
            
        Debug.Log(Vector3.Distance(obj.transform.position, transform.position));


                if (dist > distance)
                    _AudioSpeaker.Stop();

            Vector3 raycastDir = obj.transform.position - transform.position;
            
            
            //Debug.DrawRay(transform.position, raycastDir, Color.black);

            return dist;

        }



        private float GetOcclusionFreq(GameObject obj, float distance)
        {


            Vector3 raycastDir = obj.transform.position - transform.position;

            Debug.DrawRay(transform.position, raycastDir, Color.red);

            if (Physics.Raycast(transform.position, raycastDir, out occluderRayHit, distance)) // raycast to listener object
            {
                if (occluderRayHit.collider.gameObject.tag == "Geometry") // occlude if raycast does not hit listener object
                {

                    return lpfFreak;
                }
            }


            return 20000f; // otherwise no occlusion

        }


        void Update()
        {

            if (_AudioSpeaker.isPlaying)
            {
                print("Source is playing");
                _lpFilter.cutoffFrequency = GetOcclusionFreq(listener, 20);


            }
            else if (_AudioSpeaker.isPlaying == false && CheckForDistance(listener, 20) < maxDistance)
                _AudioSpeaker.Play();
        
                

            CheckForDistance(listener, maxDistance);

        }




        //private float GetRandomVolume(float volume, float randomVol)
        //{
        //    float randomDb = volume + Random.Range(randomVol, 0f);
        //    return AudioUtils.ConvertDbLinear(randomDb);
        //}

        //private float GetRandomPitch(float pitch, float randomPitch)
        //{
        //    float randomSt = pitch + Random.Range(0f - randomPitch, randomPitch);
        //    return AudioUtils.ConvertStLinear(randomSt);
        //}




}














//    //private AudioClip GetRandomClip(List<AudioClip> clips)
//    //{
//    //    int lastClipIndex = -1;
//    //    int index = Random.Range(0, clips.Count); //Get random clip index. 

//    //    if (clips.Count > 1) //If clip count is greater than 1... 
//    //    {
//    //        while (index == lastClipIndex) // loop until index is not equal to the last indexed audio clip.
//    //        {
//    //            index = Random.Range(0, clips.Count);
//    //        }
//    //    }
//    //    else  // if there is only one AudioClip the index is simply 0.
//    //    {
//    //        index = 0;
//    //    }

//    //    lastClipIndex = index; // current index is saved as lastClipIndex.
//    //    return clips[index];
//    //}




//}
