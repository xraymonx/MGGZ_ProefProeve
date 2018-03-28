using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    private List<AudioClip> audioSongs = new List<AudioClip>();
    private SongSelection songSelection;

    private string songFolderPath = "";

    [SerializeField] private AudioMixerGroup audioMixerGroup;
    private void Start() {
        GetAllSongs();
        songSelection = GetComponent<SongSelection>();
    }

    private void GetAllSongs() {
        songFolderPath = Path.GetFullPath(StringValues.FolderPath + "/" + "music");
        StartCoroutine("LoadAll", Directory.GetFiles(songFolderPath, "*.*", SearchOption.AllDirectories));
    }

    IEnumerator LoadAll(string[] filePaths) {

        foreach(string filePath in filePaths) {

            WWW load = new WWW("file:///" + filePath);

            yield return load;

            if(!string.IsNullOrEmpty(load.error)) {
                Debug.LogWarning(filePath + " error");
            } else {
                audioSongs.Add(load.GetAudioClip());
            }
            
        }
        CreateAudioSources();
        Debug.Log("Amount of songs found is = " + audioSongs.Count);
    }

    private void CreateAudioSources() {

        for(int i = 0; i < audioSongs.Count; i++) {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
    
            audioSource.loop = true;
            audioSource.volume = 0f;
            audioSource.clip = audioSongs[i];
            audioSource.Play();
            audioSource.outputAudioMixerGroup = audioMixerGroup;

            songSelection.audioSources.Add(audioSource);
        }
    }
}

