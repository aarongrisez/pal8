using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour 
{
    [TextArea]
    public string description = "room description";
    public List<InteractableObject> objectsInRoom = new List<InteractableObject>();
    public List<Location> accessibleLocations = new List<Location>();
}