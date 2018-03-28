using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class SliderValues : MonoBehaviour {

    private EVRButtonId triggerButton = EVRButtonId.k_EButton_SteamVR_Trigger;
    private VRInput vrInput;

    private SteamVR_TrackedObject trackedObj;

    [SerializeField]private float minZPos;
    [SerializeField]private float maxZPos;

    private float maximumValue;

    public float SliderValue() {
        if(maximumValue == 0)
            maximumValue = minZPos + (maxZPos * -1f);

        float value = minZPos - transform.localPosition.z;
        float sliderValue = value / maximumValue;       
        if(sliderValue >= 0)
            return sliderValue;
        else
            return 0;
   
    }
}
