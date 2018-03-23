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


    private void OnTriggerStay(Collider collision) {
        

        if(collision.gameObject.tag == "Tracker") {
            trackedObj = collision.GetComponent<SteamVR_TrackedObject>();
            Debug.Log("Tracker");
            if (IsPressed()) {
                Debug.Log("IsPressed");
                //Trigger Pressed
                parentObj = collision.gameObject;
                isGrabbed = true;
            }
        }
    }

    private void Update() {

        if(trackedObj != null)
            if(isGrabbed && !IsNotPressed()) {
             
                this.gameObject.transform.parent = parentObj.transform;
                Debug.Log("Grabbed");
            } else {
                isGrabbed = false;
                trackedObj = null;
                Debug.Log("Let Go");
                this.gameObject.transform.parent = null;
            }
    }

    
}
