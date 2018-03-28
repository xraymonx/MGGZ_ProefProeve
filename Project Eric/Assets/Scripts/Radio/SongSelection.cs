using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSelection : MonoBehaviour
{

    [HideInInspector]
    public List<AudioSource> audioSources = new List<AudioSource>();
    [SerializeField]
    private SliderValues songSelection;

    private float songArea = 0f;
    private float volumeMultiplier = 0f;
    private void Start() {


    }
    private void Update() {
        if(audioSources.Count != 0) {

            if(songArea == 0) {
                songArea = 1f / audioSources.Count;
                volumeMultiplier = 1 / (songArea - ((songArea / 2))); 
                Debug.Log(volumeMultiplier);
            }
            Selection();
        }
    }
    /// Audiosources highest volume level is listPosition * songArea. Example: 1 /5 = ,2. Position 3 is .6 main volume. 
    /// Thing is that the songs must ignore the slider unless its near the mainVolume area. 
    /// their must be a marging. Like half the song area. 
    /// 
    /// 

    private void Selection() {
        for(int i = 0; i < audioSources.Count; i++) {

            float highestVolumePos = i * songArea + (songArea / 2);
            float sliderValue = songSelection.SliderValue();
            // value >= 0.6 - .1 
            if(sliderValue >= highestVolumePos - (songArea / 2) && sliderValue <= highestVolumePos) {

                float songVolume = sliderValue - (highestVolumePos - (songArea / 2));
                audioSources[i].volume = songVolume * volumeMultiplier;

            } else if(sliderValue <= highestVolumePos + (songArea / 2) && sliderValue >= highestVolumePos) {

                float songVolume = (highestVolumePos + (songArea / 2)) - sliderValue;
                audioSources[i].volume = songVolume * volumeMultiplier;

            } else {
                audioSources[i].volume = 0f;
            }
        }

    }
}
