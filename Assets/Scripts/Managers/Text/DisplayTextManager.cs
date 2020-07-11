using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTextManager : MonoBehaviour
{

    [HideInInspector] private DisplayTextController displayTextController;
    [HideInInspector] private SceneController sceneController;
    [HideInInspector] private PlayerController playerController;

    private List<string> log = new List<string>();

    void Awake()
    {
        GameObject sceneControllerObject = GameObject.FindWithTag("SceneController");
        GameObject displayTextControllerObject = GameObject.FindWithTag("DisplayTextController");
        GameObject playerControllerObject = GameObject.FindWithTag("PlayerController");
        sceneController = sceneControllerObject.GetComponent<SceneController>();
        displayTextController = displayTextControllerObject.GetComponent<DisplayTextController>();
        playerController = playerControllerObject.GetComponent<PlayerController>();
    }

    public void AcceptStringInput(string userInput)
    {
        if (userInput != "")
        {
            log.Add(userInput);
            userInput = userInput.ToLower();

            char[] delimiterCharacters = { ' ' };
            string[] separatedInputWords = userInput.Split(delimiterCharacters);

            displayTextController.InputComplete();
        }
    }

    public void InputComplete()
    {
        displayTextController.DisplayText(FormatLog());
    }

    public string FormatLog()
    {
        return string.Join("\n", log.ToArray());
    }

}
