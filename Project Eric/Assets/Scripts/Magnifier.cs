using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Magnifier : MonoBehaviour
{

    private EVRButtonId touchPad = EVRButtonId.k_EButton_SteamVR_Touchpad;
    [SerializeField]
    private GameObject magnifier;
    [SerializeField]
    private GameObject headOfViveController;
   
    private VRInput vrInput;

    private SteamVR_TrackedObject trackedObj; //left and right controller

    private void Start() {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        vrInput = GetComponentInParent<VRInput>();
    }
    private void Update() {

        if(!magnifier.activeInHierarchy && vrInput.IsPressed(touchPad,trackedObj)) {
            magnifier.SetActive(true);
            headOfViveController.SetActive(false);
        }

        if(magnifier.activeInHierarchy && vrInput.IsNotPressed(touchPad, trackedObj)) {
            magnifier.SetActive(false);
            headOfViveController.SetActive(true);
        }
    }
}

