using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EtteTextManager : MonoBehaviour
{

    [HideInInspector] private EtteTextController etteTextController;
    [HideInInspector] private PlayerController playerController;

    private List<string> log = new List<string>();
    private string[] statements = new string[] {
        "Hi! My Name is Ette, and I'm here to help you through this dungeon.",
        "It looks like you're trying to make a potion. You might want to take a look around for some REAGENTS.",
        "Are you even trying to make progress here?",
        "Clearly you're doing something wrong, because the I'm sure the devs had time to implement an INVENTORY which you are now neglecting.",
        "Ok. Now it's just obvious you're trying to be cheeky. Any reasonable person would have collected AT LEAST 1 REAGENT by now.",
        "I can't believe this. Is it because the controls are too complicated? Text Based + Top Down is just *TOO MUCH TO HANDLE*?",
        "Fine. You think the controls are too complex? I'll make it easier for you. Now you only have to worry about 2 directions instead of 4. How's that for progress?",
        "UGGGGGHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH",
        "You have pushed me to the brink. I just don't know what to do with you anymore. Like, this is just absurd. I can't. I CAN'T. Just go do something else. I'm done with you."
    };
    private int numPlayerCommands = 0;
    private int nextStatementNumberOfCommands = 5;
    private int currentIndex = 0;
    private int indexToLoseMotion = 6;
    protected System.Random rand = new System.Random();

    void Awake()
    {
        GameObject etteTextControllerObject = GameObject.FindWithTag("EtteTextController");
        GameObject playerControllerObject = GameObject.FindWithTag("PlayerController");
        etteTextController = etteTextControllerObject.GetComponent<EtteTextController>();
        playerController = playerControllerObject.GetComponent<PlayerController>();
    }

    public void AddText()
    {
        log.Add(statements[currentIndex]);
        currentIndex += 1;
        etteTextController.DisplayText(FormatLog());
    }

    public void HandlePlayerCommand()
    {
        numPlayerCommands += 1;
        if (numPlayerCommands == nextStatementNumberOfCommands)
        {
            if (currentIndex < statements.Length)
            {
                AddText();
                nextStatementNumberOfCommands += rand.Next(4, 7);
                Debug.Log("Next Ette statement will occur at " + nextStatementNumberOfCommands + " player commands");
            }
            if (currentIndex == indexToLoseMotion)
            {
                playerController.RemoveDownAndLeftMovement();
            }
            if (currentIndex == statements.Length)
            {
                playerController.Die();
            }
        }
    }

    public string FormatLog()
    {
        return string.Join("\n\n", log.ToArray());
    }

}
