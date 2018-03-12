using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSwitchChair : MonoBehaviour {

    [SerializeField] private GameObject chair;
    [SerializeField] private GameObject controller_1;
    [SerializeField] private GameObject controller_2;

    private bool controller1Active = true;
    void Update () {
        if(Input.GetKeyDown(KeyCode.R)) {
            if(controller1Active) {
                chair.transform.parent = controller_2.transform;
                chair.transform.position = controller_2.transform.position;
                chair.transform.rotation = controller_2.transform.rotation;
                controller1Active = false;
            } else {
                chair.transform.parent = controller_1.transform;
                chair.transform.position = controller_1.transform.position;
                chair.transform.rotation = controller_1.transform.rotation;
                controller1Active = true;
            }
        }
	}
}
