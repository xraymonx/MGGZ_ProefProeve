using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UITextToBook : MonoBehaviour {

   [SerializeField] private InputField inputField;

    [SerializeField]
    private Text bookText;

    public void OnValueChange() {
        bookText.text = inputField.text;


    }
}
