using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class VRInput : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device controller {
        get {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }

    public bool IsPressed(EVRButtonId button, SteamVR_TrackedObject Obj) {
        trackedObj = Obj;
        return controller.GetPressDown(button);
    }
    public bool IsNotPressed(EVRButtonId button, SteamVR_TrackedObject Obj) {
        trackedObj = Obj;
        return controller.GetPressUp(button);
    }

}
