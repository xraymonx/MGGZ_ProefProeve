using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Valve.VR;

public class Grabbable : MonoBehaviour
{
    private EVRButtonId triggerButton = EVRButtonId.k_EButton_SteamVR_Trigger;
    private bool isGrabbed = false;
    private bool triggerButtonDown = false;
    private SteamVR_TrackedObject trackedObj;
    private GameObject parentObj;

    private VRInput vrInput;

    private void OnTriggerStay(Collider collision) {        

        if(collision.gameObject.tag == "Tracker") {
            trackedObj = collision.GetComponent<SteamVR_TrackedObject>();

            if(vrInput == null)
              vrInput = collision.GetComponentInParent<VRInput>();


            if (vrInput.IsPressed(triggerButton,trackedObj)) {
             
                //Trigger Pressed
                parentObj = collision.gameObject;
                isGrabbed = true;
            }
        }
    }

    private void Update() {

        if(trackedObj != null)
            if(isGrabbed && !vrInput.IsNotPressed(triggerButton, trackedObj)) {
             
                this.gameObject.transform.parent = parentObj.transform;
               
            } else {
                isGrabbed = false;
                trackedObj = null;

                this.gameObject.transform.parent = null;
            }
    }

    
}
