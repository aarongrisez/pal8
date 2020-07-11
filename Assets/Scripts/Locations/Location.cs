using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Directions
{
    Up,
    Down,
    Left,
    Right,
}

[CreateAssetMenu(menuName = "TextEngine/Location")]
public class Location : ScriptableObject 
{
    [TextArea]
    public string description = "room description";
    public string name = "name";
    public List<InteractableObject> objectsInRoom = new List<InteractableObject>();
    public List<Location> accessibleLocations = new List<Location>();
}