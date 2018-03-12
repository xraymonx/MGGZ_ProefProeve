using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{

    [SerializeField]private GameObject light;
    [SerializeField] private AudioSource audio;
    public void StartLightning(float waitTime)
    {
        StartCoroutine(LightningCycle(waitTime));
    }
    public void PlaySound()
    {
        audio.Play();
    }
    private IEnumerator LightningCycle(float waitTime)
    {
        light.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        light.SetActive(false);

    }

}
