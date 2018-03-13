using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    /// <summary>
    /// needs a patientNameOrID to save the fileName. 
    /// 
    /// Things to save: 
    /// Text per image, Or do we save each image text seperately?
    /// Save each Text and Image seperataly On the patientsnameFile
    /// </summary>
    ///

    [SerializeField]
    private Text text;
    private string folderPath = "";

    private string patientName = "Ernst";

    private int imageID = 1;
    private void Start() {

        folderPath = Directory.GetCurrentDirectory();

        SaveFile();

        LoadFile();
    }

    public void SaveFile() {

        BinaryFormatter bf = new BinaryFormatter();

        if(!File.Exists(folderPath + "/" + patientName)) {
            Directory.CreateDirectory(folderPath + "/" + patientName);

        }
        FileStream file = File.Create(folderPath + "/" + patientName + "/" + imageID + ".dat");
        SaveClass data = new SaveClass();

        data.imageText = "Hallo hallo test 1 2 3";
        //Save stuff here

        bf.Serialize(file, data);
        file.Close();
    }


    public void LoadFile() {

        if(File.Exists(folderPath + "/" + patientName + "/" + imageID + ".dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(folderPath + "/" + patientName + "/" + imageID + ".dat", FileMode.Open);

            SaveClass data = (SaveClass)bf.Deserialize(file);
            file.Close();
            
            text.text += " " + data.imageText + " " + folderPath;
            //testDataString = data.imageText;

        }

    }
}
