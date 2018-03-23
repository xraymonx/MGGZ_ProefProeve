using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmotionButtons : MonoBehaviour {

    [SerializeField]
    private InputField inputField;

    [SerializeField]
    private string stringToAdd;

    public void ButtonPressed() {
        inputField.text += '\n' + stringToAdd;
    }
}
