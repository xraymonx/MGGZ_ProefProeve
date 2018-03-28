using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SliderInteraction : MonoBehaviour
{

    private EVRButtonId triggerButton = EVRButtonId.k_EButton_SteamVR_Trigger;
    private SteamVR_TrackedObject trackedObj;
    private bool isGrabbed = false;
    private VRInput vrInput;

    // Use this for initialization

    private void OnTriggerStay(Collider collision) {

        if(collision.gameObject.tag == "Tracker") {
            trackedObj = collision.GetComponent<SteamVR_TrackedObject>();

            if(vrInput == null)
                vrInput = collision.GetComponentInParent<VRInput>();


            if(vrInput.IsPressed(triggerButton, trackedObj)) {
                //Trigger Pressed
                isGrabbed = true;
            }
        }
    }

    private void Update() {

        if(trackedObj != null)
            if(isGrabbed && !vrInput.IsNotPressed(triggerButton, trackedObj)) {
                transform.position = Vector3.MoveTowards(transform.position, trackedObj.transform.position, 1f);


            } else {
                isGrabbed = false;
                trackedObj = null;
                return;
            }

    }
}

