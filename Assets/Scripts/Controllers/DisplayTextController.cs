using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Entrypoint component on a Player object    
[RequireComponent(typeof(DisplayTextManager))]
public class DisplayTextController : MonoBehaviour
{
    [HideInInspector] public DisplayTextManager displayTextManager;
    public Text displayTextObject;
    public InputField inputField;


    void Awake()
    {
        displayTextManager = GetComponent<DisplayTextManager>();
        Debug.Log("DisplayTextController mounted");
        inputField.onEndEdit.AddListener(displayTextManager.AcceptStringInput);
    }

    public void DisplayText(string textToDisplay)
    {
        Debug.Log("Displaying Text: " + textToDisplay);
        displayTextObject.text = textToDisplay;
    }

    public void InputComplete()
    {
        displayTextManager.InputComplete();
        inputField.ActivateInputField();
        inputField.text = null;
    }

}