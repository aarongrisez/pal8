using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour 
{
    public string noun = "Name";
    [TextArea]
    public string description = "Description in Room";
    public Command[] commands;
}

public class PotionBase : InteractableObject
{
    public string[] bonuses;
    public string type; 

}

public class PotionReagent : InteractableObject
{
    public string[] effects;
    public string type; 
    public int strength;

}

public class PotionEffect : InteractableObject 
{
    public string type;
}

public class Flask : InteractableObject
{
    private PotionEffect effect;

    public void Fill(PotionEffect effect) { this.effect = effect; }
    public void Empty() { this.effect = null; }

    public bool IsEmpty() { return this.effect == null; }
}
