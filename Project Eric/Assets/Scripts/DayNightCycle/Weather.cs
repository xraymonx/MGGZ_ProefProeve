using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class Weather : MonoBehaviour {

    private bool isRunning = false;
    [SerializeField]private Animator animator;
    [SerializeField] private string triggerValue;

    [SerializeField] private AudioSource source;


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag=="Tracker")
        {
            source.Play();
            Debug.Log("Hallo collision");
            animator.SetTrigger(triggerValue);
        }
    }
   
}
