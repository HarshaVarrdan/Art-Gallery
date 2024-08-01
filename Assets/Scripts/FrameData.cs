using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameData : MonoBehaviour
{

    [SerializeField] AudioClip animalAudio;

    AudioSource frameAS;

    // Start is called before the first frame update
    void Start()
    {
        frameAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartInteraction()
    {
        frameAS.PlayOneShot(animalAudio);
    }
}
