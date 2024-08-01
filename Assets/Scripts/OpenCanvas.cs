using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;

public class OpenCanvas : MonoBehaviour
{
    [SerializeField] GameObject intPromptText; 
    FrameData selFrameData;

    bool bFrameInteractable;
    bool bInteractable;
    bool bInteractacted;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (bInteractable && Input.GetKey(KeyCode.E))
        {
            selFrameData.StartInteraction();
        }

        if (bInteractable && Input.GetKey(KeyCode.Escape))
        {
            bInteractable = false;
            Debug.Log("esc");
            selFrameData.EndInteraction();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            bInteractable = true;
            selFrameData = other.GetComponent<FrameData>();
            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            bInteractable = false;
           // selFrameData = null;
            selFrameData.EndInteraction();
        }


    }


}


