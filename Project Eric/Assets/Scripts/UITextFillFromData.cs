using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UITextFillFromData : MonoBehaviour {

    [SerializeField]
    private InputField canvasTextField;

    private SaveAndLoadImage saveAndLoad;

    private void Start() {
        saveAndLoad = GetComponentInParent<SaveAndLoadImage>();
    }

    public void FillText(int ID) {

       canvasTextField.text = saveAndLoad.LoadFile(ID);
    }
    public void SaveCurrentText(int ID) {
        saveAndLoad.SaveFile(canvasTextField.text, ID);
    }
}
