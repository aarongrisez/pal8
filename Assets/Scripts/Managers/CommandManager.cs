using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : BaseManager
{
    private List<Command> validCommands = new List<Command>();

    public void PrimeValidCommands(InteractableObject[] objects, Location[] locations)
    {
        /*
        Called when new room is entered. All interactable objects and accessible locations
        are catalogued for valid commands.
        */

        for (int i = 0; i < objects.Length; i++)
        {
            for (int j = 0; j < objects[i].commands.Length; j++)
            {
                validCommands.Add(objects[i].commands[j]);
            }
        }

        for (int i = 0; i < locations.Length; i++)
        {
            //
        }
        
    }

    public override void ClearAllCollections()
    {
        validCommands.Clear();
    }

}
