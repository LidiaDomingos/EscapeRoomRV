using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class DisableHand : MonoBehaviour
{
    public GameObject leftHandModel;
    public GameObject rightHandModel;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable interactable = GetComponent<XRGrabInteractable>();
        interactable.selectEntered.AddListener(HideGrabbingHand);
        interactable.selectExited.AddListener(ShowGrabbingHand);
        
    }

    public void HideGrabbingHand(SelectEnterEventArgs args)
    {
        if(args.interactableObject.transform.tag == "Left Hand")
        {
            leftHandModel.SetActive(false);
        }
        else if (args.interactableObject.transform.tag == "Right Hand")
        {
            rightHandModel.SetActive(false);    
        }

    }

    public void ShowGrabbingHand(SelectExitEventArgs args)
    {
        if (args.interactableObject.transform.tag == "Left Hand")
        {
            leftHandModel.SetActive(true);
        }
        else if (args.interactableObject.transform.tag == "Right Hand")
        {
            rightHandModel.SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

