using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameData : MonoBehaviour
{

    


   [SerializeField] GameObject canvasPrefab;
   [SerializeField] GameObject canvasInstance;

    // Start is called before the first frame update
    void Start()
    {
        canvasInstance.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartInteraction()
    {
        Debug.Log("Triggered");
        canvasInstance.SetActive(true);
    }

    public void EndInteraction()
    {
        Debug.Log("End Triggered");
        canvasInstance.SetActive(false);
    }
}