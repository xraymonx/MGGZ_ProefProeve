using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPage : MonoBehaviour {

    private Animator animator;
    [SerializeField]
    private FotoManager fotoManager;

    private void Start() {
        animator = GetComponent<Animator>();
        animator.SetTrigger(StringValues.OpenBook);
    }

    private void Update() {

        if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            animator.SetTrigger(StringValues.FlipPageBack);
            fotoManager.NextImage(false);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)) {

            animator.SetTrigger(StringValues.FlipPage);
            fotoManager.NextImage(true);
        }
    }
}
