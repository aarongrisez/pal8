using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextEngine/Interactable Object")]
public class InteractableObject : ScriptableObject
{
    public string noun = "Name";
    [TextArea]
    public string description = "Description in Room";
    public Command[] commands;
}
