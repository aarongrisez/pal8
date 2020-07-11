using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Maintains current state of the player's inventory 
public class InventoryManager : BaseManager 
{
    private List<InteractableObject> objectsInInventory = new List<InteractableObject>();

    public void AddItem(InteractableObject item)
    {
        objectsInInventory.Add(item);
    }

    public void RemoveItem(InteractableObject item)
    {
        objectsInInventory.Remove(item);
    }

    public string ReportContents()
    {
        List<string> output = new List<string>();
        for (int i = 0; i < objectsInInventory.Count; i++)
        {
            output.Add(objectsInInventory[i].name);
        }
        return string.Join("\n", output.ToArray());
    }

    public InteractableObject GetObjectInInventoryByName(string name)
    {
        for (int i = 0; i < objectsInInventory.Count; i++)
        {
            if (name == objectsInInventory[i].name)
            {
                return objectsInInventory[i];
            }
        }
        return null;
    }

}
