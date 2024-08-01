    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;

    public class TriggerInteraction : MonoBehaviour
    {

        [SerializeField] GameObject animalNameText;
        [SerializeField] GameObject descText;
        [SerializeField] GameObject intPromptText;

        AnimalData selAnimData;

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
            if(bInteractable && Input.GetKey(KeyCode.E))
            {
                StartInteraction();
            }

            if(bInteractacted && Input.GetKey(KeyCode.Escape)) 
            {
                EndInteraction(true);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Animal"))
            {
                bInteractable = true;
                selAnimData = other.GetComponent<AnimalData>();
                intPromptText.transform.GetChild(0).GetComponent<TMP_Text>().text = "Press \"E\" to Interact.";
                intPromptText.SetActive(true);
            }

            if (other.gameObject.CompareTag("PhotoFrame"))
            {
                other.gameObject.GetComponent<FrameData>().StartInteraction();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Animal"))
            {
                bInteractable = false;
                selAnimData = null;
                intPromptText.SetActive(false);
            }

        
        }

        public void StartInteraction()
        {
            selAnimData.StartAnim();
            animalNameText.gameObject.transform.parent.gameObject.SetActive(true);

            animalNameText.GetComponent<TMP_Text>().text = selAnimData.AnimalName;
            descText.GetComponent<TMP_Text>().text = selAnimData.AnimalDesc;
            intPromptText.transform.GetChild(0).GetComponent<TMP_Text>().text = "Press \"Escape\" to Close.";
        
            bInteractacted = true;

            PlayerController.pc_Instance.bCanMove = false;
        }

        public void EndInteraction(bool bTriggerAD)
        {
            if(bTriggerAD)
                selAnimData.EndAnim(false);
        
            animalNameText.gameObject.transform.parent.gameObject.SetActive(false);
            animalNameText.GetComponent<TMP_Text>().text = selAnimData.AnimalName;
            descText.GetComponent<TMP_Text>().text = selAnimData.AnimalDesc;
            intPromptText.transform.GetChild(0).GetComponent<TMP_Text>().text = "Press \"E\" to Interact.";

            PlayerController.pc_Instance.bCanMove = true;


        }
    }
