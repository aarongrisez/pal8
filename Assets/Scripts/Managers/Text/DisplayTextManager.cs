using System;
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
                case "move":
                    switch(separatedInputWords.Length){
                        case 2:
                            Direction dir;
                            if(Enum.TryParse<Direction>(separatedInputWords[1], true, out dir)){
                                playerController.HandleMove(dir);
                            } else {
                                RejectInput("Bad Direction " + separatedInputWords[1]);
                            }
                            break;
                        default:
                            RejectInput(userInput + " (Move takes exactly one parameter)");
                            break;
                    }
                    break;
                case "look":
                    switch(separatedInputWords.Length){
                        case 1: 
                            log.Add(playerController.locationManager.currentLocation.description);
                            log.Add("You can see the following items");
                            log.Add(playerController.locationManager.ReportObjectsInRoom());
                            log.Add("You can go to these locations");
                            log.Add(playerController.locationManager.ReportAccessibleLocations());
                            break;
                        case 2:
                            var item = separatedInputWords[1];
                            var itemMatch = playerController.inventoryManager.GetObjectInInventoryByName(item) ??
                                            playerController.locationManager.GetObjectInRoomByName(item);
                            log.Add("You look at the " + itemMatch.noun);
                            log.Add(itemMatch.description);
                            break;
                    }
                    break;
                case "use":
                    var thing = playerController.inventoryManager.GetObjectInInventoryByName(separatedInputWords[0]);
                    if(thing == null){
                        RejectInput("You do not have a " + separatedInputWords[0] + " to use");
                        break;
                    }
                    switch(separatedInputWords.Length){
                        case 2:
                        // Use on self
                        case 3:
                        // Use on something
                        default: break;
                    }
                    break;
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
