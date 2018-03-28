using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FlipPage : MonoBehaviour
{

    private EVRButtonId gripButton = EVRButtonId.k_EButton_Grip;
    private Animator animator;

    [SerializeField]
    private FotoManager fotoManager;

    private VRInput vrInput;
    private bool isGrabbed = false;

    [SerializeField]
    private SteamVR_TrackedObject trackedLeftObj, trackedRightObj; //left and right controller
    private SteamVR_TrackedObject flippingTrackedObj; //controller that will swipe the pages

    [SerializeField]
    private Transform leftSide, rightSide;

    private Transform startSide;
    private bool bookIsOpen = false;

    private SteamVR_TrackedObject trackedObj;
    private void Start() {
        animator = GetComponent<Animator>();

    }

    private void OpenBook(bool check) {
        if(check && !bookIsOpen) {
            bookIsOpen = true;
            animator.SetTrigger(StringValues.OpenBook);

        } else {
            bookIsOpen = false;
            animator.SetTrigger(StringValues.CloseBook);
        }
    }

    private void OnTriggerStay(Collider collision) {

        if(collision.gameObject.tag == "Tracker") {


            if(vrInput == null)
                vrInput = collision.GetComponentInParent<VRInput>();

            //check if both controllers are pressed
            if(!bookIsOpen && vrInput.IsPressed(gripButton, trackedLeftObj)) {
                if(vrInput.IsPressed(gripButton, trackedRightObj)) {
                    //Open book
                    OpenBook(true);
                    return;
                }
            }
            if(bookIsOpen && vrInput.IsNotPressed(gripButton, trackedLeftObj)) {
                if(vrInput.IsNotPressed(gripButton, trackedRightObj)) {
                    //Open book
                    OpenBook(false);
                    return;
                }
            }


            if(bookIsOpen) {
                trackedObj = collision.GetComponent<SteamVR_TrackedObject>();
                if(vrInput.IsPressed(gripButton, trackedObj) && bookIsOpen) {

                    float distanceA = (trackedObj.transform.position - leftSide.position).magnitude;
                    float distanceB = (trackedObj.transform.position - rightSide.position).magnitude;
                    Debug.Log(distanceA + "  " + distanceB);
                    if(distanceA < distanceB) { //Check what side the hand is allocated.
                        startSide = leftSide;
                        animator.SetTrigger(StringValues.FlipPageBack);
                        fotoManager.NextImage(false);
                    } else {
                        startSide = rightSide;
                        animator.SetTrigger(StringValues.FlipPage);
                        fotoManager.NextImage(true);
                    }
                }
            }
            isGrabbed = true;

        }
    }
    private void Update() {
        if(trackedObj != null) {
            if(isGrabbed && !vrInput.IsNotPressed(gripButton, trackedObj)) {
                //do stuff

            } else {
                isGrabbed = false;
                this.gameObject.transform.parent = null;
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)) {


        }

        if(Input.GetKeyDown(KeyCode.RightArrow)) {

        }

    }
}
