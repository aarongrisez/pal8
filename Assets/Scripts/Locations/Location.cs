using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextEngine/Room")]
public class Location : ScriptableObject 
{
    [TextArea]
    public string description;
    public string keyString;
}