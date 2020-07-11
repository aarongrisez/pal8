using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command : ScriptableObject 
{
    public string keyword;

    public abstract void RespondToInput(GameController controller, string[] separatedInputWords);

}
