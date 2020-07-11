# Text Engine Data Model

## BaseClasses

 - InteractableObject
 - Command
 - Location 

## InteractableObject

Subclasses:
 - PotionBase
    All potion recipes require a base. The base can have multiple effects.
 - PotionReagent
    All potion recipes require at least 2 reagents. Each reagent can have multiple effects
 - PotionEffect 
    Potential in-game effect of potions with this effect. Effects are cumulative in a recipe.
 - Flask
    Creating a potion requires an empty Flask in the player's inventory

## Command

Subclasses:
 - Move
    Moves the user
 - Look
    Provides additional detail about the subject. Command semantics require 0 or 1 subject. If no subject is given, the subject "room" is assumed and the user is given a list of the room's contents
 - Use
    Uses an item in the player's inventory. If the item requires object for use, command semantics require 1 subject and 1 or more objects. 

## Location

Subclasses:
 - Room
    Defines a location which can contain interactable objects and exits to other rooms
