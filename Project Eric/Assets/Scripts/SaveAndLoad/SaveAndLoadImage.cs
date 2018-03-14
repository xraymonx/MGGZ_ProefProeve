using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class SaveAndLoadImage : MonoBehaviour
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
    public string FolderPath {
        get { return folderPath; }
    }
    private string patientFolder = "PatientFolder";

    //private int imageID = 1;
    private void Awake() {

        //folderPath = Directory.GetCurrentDirectory();
        var stringPath = Application.dataPath + "/../"; // Get directory in unity its the Assets folder, in the build its the _Data folder, add  + "/../" so its goes back a folder.
        folderPath = Path.GetFullPath(stringPath); // set the new directory for search

        StringValues.FolderPath = folderPath + patientFolder;
        SaveFile("homooo", 1);
        Debug.Log(LoadFile(1));
    }


    public void SaveFile(string TextToSave, int imageID) { //save file

        BinaryFormatter bf = new BinaryFormatter();

        if(!File.Exists(StringValues.FolderPath)) { //check if the folder exists ( for error pervention
            Directory.CreateDirectory(StringValues.FolderPath); //create folder if it doesnt exit

        }
        FileStream file = File.Create(StringValues.FolderPath + "/" + imageID + ".dat"); //Create a .dat file for each image. 
        SaveClass data = new SaveClass(); //Create new dataClass

        data.ImageText = TextToSave; //Value to save
        //Save stuff here

        bf.Serialize(file, data); //add value to save to the .dat file
        file.Close();
    }


    public string LoadFile(int imageID) {

        if(File.Exists(StringValues.FolderPath + "/" + imageID + ".dat")) { //check if the .dat file exists ( error pervention)
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(StringValues.FolderPath + "/" + imageID + ".dat", FileMode.Open); // open the file

            SaveClass data = (SaveClass)bf.Deserialize(file); //extract data
            file.Close();

            return data.ImageText; //return the data
            //testDataString = data.imageText;
        } else {
            return "No data found"; // .Dat file doesnt exist. 
        }
    }
}
