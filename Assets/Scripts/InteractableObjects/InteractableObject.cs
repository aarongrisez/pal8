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
    // Bonus modifier of this base
    public int bonus;

}

public class PotionReagent : InteractableObject
{
    // Two possible effects of each reagent
    public string[] effects;
    public int[] strength;

}

public class PotionEffect : InteractableObject 
{
    public string type;
}

public class Flask : InteractableObject
{
    public int GetBonus(){
        return this.noun == "BlessedVial" ? 1 : 0;
    }
    public bool EmptiesOnUse(){
        return this.noun == "CantripVial";
    }
    public int GetMaxStrength(){
        switch(this.noun){
            case "CantripVial": return 2;
            case "TrickVial": return 5;
            case "BlessedVial": return 7;
            default: return 0;
        }
    }
}

public class Potion : InteractableObject
{
    public string effect;
    public int strength;
    public Flask flask;

    private Potion(string effect, int strength, Flask flask){
        this.effect = effect;
        this.strength = strength;
        this.flask = flask;
    }

    public static Potion MakePotion(PotionBase potionBase, PotionReagent reagent1, PotionReagent reagent2, Flask flask, out string result)
    {
        // First, get the common effect and individual strengths
        string commonEffect = null;
        int str1 = 0, str2 = 0;
        int matches = 0;
        if(reagent1.effects[0] == reagent2.effects[0]){
            commonEffect = reagent1.effects[0];
            str1 = reagent1.strength[0];
            str2 = reagent2.strength[0];
            matches++;
        }
        if(reagent1.effects[0] == reagent2.effects[1]){
            commonEffect = reagent1.effects[0];
            str1 = reagent1.strength[0];
            str2 = reagent2.strength[1];
            matches++;
        }
        if(reagent1.effects[1] == reagent2.effects[0]){
            commonEffect = reagent1.effects[1];
            str1 = reagent1.strength[1];
            str2 = reagent2.strength[0];
            matches++;
        }
        if(reagent1.effects[1] == reagent2.effects[1]){
            commonEffect = reagent1.effects[1];
            str1 = reagent1.strength[1];
            str2 = reagent2.strength[1];
            matches++;
        }
        switch(matches){
            case 0:
                commonEffect = "Explosion";
                str1 = 1;
                str2 = 1;
                break;
            case 1:
                break;
            default:
                commonEffect = "Inert";
                str1 = 0;
                str2 = 0;
                break;
        }
        result = "You made a " + commonEffect + " potion";
        int totalStr = str1 + str2 + flask.GetBonus();
        Potion p = new Potion(commonEffect, totalStr, flask);
        p.noun = commonEffect + totalStr + flask.noun;
        p.description = "A " + commonEffect + "(" + totalStr + ") potion in a " + flask.noun;
        return p;
    }
}
