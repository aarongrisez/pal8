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

public class PotionBase : InteractableObject
{
    public String[] bonuses;
    public String type; 

}

public class PotionReagent : InteractableObject
{
    public String[] effects;
    public String type; 
    public int strength;

}

public class PotionEffect : InteractableObject 
{
    public String type;
}

public class Flask : InteractableObject
{
    private bool is_empty = true;

    public void fillFlask() { this.is_empty = false; }
    public void emptyFlask() { this.is_empty = true; }
}
