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

    private void RejectInput(string input){
        log.Add("Unrecognized Input: " + input);
    }

    public void AcceptStringInput(string userInput)
    {
        if (userInput != "")
        {
            log.Add(userInput);
            userInput = userInput.ToLower();

            char[] delimiterCharacters = { ' ' };
            string[] separatedInputWords = userInput.Split(delimiterCharacters);

            switch(separatedInputWords[0]){
                case "move": RejectInput("Move not implemented"); break;
                case "look":
                    switch(separatedInputWords.Length){
                        case 1: 
                            log.Add(playerController.locationManager.currentLocation.description);
                            break;
                        case 2:
                            var item = separatedInputWords[1];
                            var itemMatch = playerController.inventoryManager.GetObjectInInventoryByName(item) ??
                                            playerController.locationManager.GetObjectInRoomByName(item);
                            log.Add("You look at the " + item);
                            log.Add(item.description);
                            break;
                    }
                    break;
                case "use": RejectInput("Use not implemented"); break;
                default: RejectInput(userInput); break;
            }

            displayTextController.InputComplete();
            displayTextController.DisplayText(FormatLog());
        }
    }

    public void AddText(string newText)
    {
        log.Add(newText);
        displayTextController.DisplayText(FormatLog());
    }

    public string FormatLog()
    {
        return string.Join("\n", log.ToArray());
    }

}
