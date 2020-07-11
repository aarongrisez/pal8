# Text Engine Semantics

In the text-only mode, the grammar for commands consists of the following:

```bash
[verb] [subject*] [object*]
```

Verbs define actions that can be performed. Where appropriate, nouns can be used as subjects and objects of that action. For example

```
move up
```

uses the verb "move" and the subject "up"

```
use potion troll
```

uses the verb "use", the subject "potion" and the object "troll"

## Version 1.0 Valid Commands

### Verbs

 - move: Player moves to a new location
 - look: Displays additional information to user
 - use: Triggers the response for an item or set of items

### Subjects

 - Anything that is an InteractableItem in the current room or in the player's inventory
 - Directions (up, down, left, right)
 - "inventory" - special subject for "look" which results in listing of player's inventory

### Objects

 - Anything that is an InteractableItem in the current room which has true as the value for the public attribute "can_be_object"