using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Grabbable : MonoBehaviour
{

    private bool isGrabbed = false;

    private bool triggerButtonDown = false;

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private SteamVR_TrackedObject trackedObj;

    private GameObject parentObj;

    private SteamVR_Controller.Device controller {
        get {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }
    private void OnTriggerStay(Collider collision) {
        

        if(collision.gameObject.tag == "Tracker") {
            trackedObj = collision.GetComponent<SteamVR_TrackedObject>();
            if (IsPressed()) {
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
    private bool IsPressed() {    
        return controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);
    }
    private bool IsNotPressed() {
        return controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);
    }
    
}
