using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class VRInput : MonoBehaviour {




    private SteamVR_Controller.Device controller {
        get {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }
    private SteamVR_TrackedObject trackedObj;

    private bool IsPressed(EVRButtonId button) {
        return controller.GetPressDown(button);
    }
    private bool IsNotPressed() {
        return controller.GetPressUp(button);
    }

}
