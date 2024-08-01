using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalData : MonoBehaviour
{

    public string AnimalName;
    public string AnimalDesc;
    public AudioClip Animal_AC;
    public AudioSource Animal_AS;

    [SerializeField] Camera AnimCamera;
    [SerializeField] Camera MainCamera;

    bool bAudioStarted;

    TriggerInteraction TI;

    // Start is called before the first frame update
    void Start()
    {
        TI = GameObject.FindWithTag("Player").GetComponent<TriggerInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bAudioStarted && !Animal_AS.isPlaying)
        {
            bAudioStarted = false;
            EndAnim(true);
        }
    }

    public void StartAnim()
    {
        MainCamera.enabled = false;
        AnimCamera.enabled = true;
        AnimCamera.gameObject.GetComponent<Animator>().enabled = true;

        Animal_AS.PlayOneShot(Animal_AC,1);
        
    }

    public void EndAnim(bool bTrigggerTI)
    {
        MainCamera.enabled = true;
        AnimCamera.enabled = false;

        Animal_AS.Stop();

        if (bTrigggerTI) 
            TI.EndInteraction(false);
    }
}
