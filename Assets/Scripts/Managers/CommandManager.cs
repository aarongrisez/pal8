using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : BaseManager
{
    private List<Command> validCommands = new List<Command>();

    public void AddFromObjects(List<InteractableObject> objects)
    {
        /*
        Called when new room is entered. All interactable objects and accessible locations
        are catalogued for valid commands.
        */

        for (int i = 0; i < objects.Count; i++)
        {
            for (int j = 0; j < objects[i].commands.Length; j++)
            {
                validCommands.Add(objects[i].commands[j]);
            }
        }
    }

    public void AddFromLocations(List<Location> locations)
    {
        for (int i = 0; i < locations.Count; i++)
        {
            //
        }
        
    }

    public override void ClearAllCollections()
    {
        validCommands.Clear();
    }

}
