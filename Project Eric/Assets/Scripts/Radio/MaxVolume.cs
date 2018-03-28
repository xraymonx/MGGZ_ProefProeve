using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class MaxVolume : MonoBehaviour {

    [SerializeField]
    private SliderValues volumeSlider;

    [SerializeField]
    private AudioMixer masterGroup;

    private void FixedUpdate() {
        masterGroup.SetFloat("MasterVolume", (-80 + volumeSlider.SliderValue()*80));

    }
}
