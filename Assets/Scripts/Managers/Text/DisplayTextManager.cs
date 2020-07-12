using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTextManager : MonoBehaviour
{

    [HideInInspector] private DisplayTextController displayTextController;
    [HideInInspector] private PlayerController playerController;
    [HideInInspector] private EtteTextController etteTextController;

    private List<string> log = new List<string>();

    void Awake()
    {
        GameObject displayTextControllerObject = GameObject.FindWithTag("DisplayTextController");
        GameObject playerControllerObject = GameObject.FindWithTag("PlayerController");
        GameObject etteTextControllerObject = GameObject.FindWithTag("EtteTextController");
        displayTextController = displayTextControllerObject.GetComponent<DisplayTextController>();
        playerController = playerControllerObject.GetComponent<PlayerController>();
        etteTextController = etteTextControllerObject.GetComponent<EtteTextController>();
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
                            if (item == "inventory")
                            {
                                log.Add("The devs didn't have time to implement an inventory.");
                            }
                            var itemMatch = playerController.locationManager.GetObjectInRoomByName(item);
                            if (itemMatch != null)
                            {
                                log.Add("You look at the " + itemMatch.noun);
                                log.Add(itemMatch.description);
                            }
                            else 
                            {
                                log.Add(item + " isn't in the room or in your inventory");
                            }
                            break;
                    }
                    break;
                case "smell":
                    {
                        if (playerController.locationManager.currentLocation.name == "the Office")
                        {
                            if (separatedInputWords[1] == "pouch")
                            {
                                log.Add("Against your better judgement, you smell the pouch. It smells like leather.");
                                break;
                            }
                            else if (separatedInputWords[1] == "powder")
                            {
                                log.Add("Against your better judgement, you smell the powder. It makes you sneeze.");
                                break;
                            }
                        }
                        RejectInput(userInput); break;
                    }
                case "taste":
                    {
                        if (playerController.locationManager.currentLocation.name == "the Office")
                        {
                            if (separatedInputWords[1] == "pouch")
                            {
                                log.Add("Why did you even think of licking a leather pouch? What were you trying to gain? Sorry, I'm just trying to make sense of what, to me, seems like an exceptionally odd thing to do.");
                                break;
                            }
                            else if (separatedInputWords[1] == "powder")
                            {
                                log.Add("So apparently it was poisonous. You died.");
                                playerController.Die();
                                break;
                            }
                        }
                        RejectInput(userInput); break;
                    }
                case "use": RejectInput("Use not implemented"); break;
                case "inventory": RejectInput("The devs didn't have time to implement an inventory"); break;
                default: RejectInput(userInput); break;
            }

            etteTextController.HandlePlayerCommand();
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
        return string.Join("\n\n", log.ToArray());
    }

}
