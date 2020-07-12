using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Entrypoint component on a Player object    
[RequireComponent(typeof(EtteTextManager))]
public class EtteTextController : MonoBehaviour
{
    [HideInInspector] public EtteTextManager etteTextManager;
    public Text etteTextObject;

    void Awake()
    {
        etteTextManager = GetComponent<EtteTextManager>();
        Debug.Log("EtteTextController mounted");
    }

    public void DisplayText(string textToDisplay)
    {
        Debug.Log("Displaying Ette Text: " + textToDisplay);
        etteTextObject.text = textToDisplay;
    }

    public void AddText()
    {
        etteTextManager.AddText();
    }

    public void HandlePlayerCommand()
    {
        etteTextManager.HandlePlayerCommand();
    }

    public void DecreasePatience()
    {
        // On invalid inputs, reduce the time between Ette statements
        etteTextManager.DecreasePatience();
    }

}