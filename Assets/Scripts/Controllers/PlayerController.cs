using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

// Entrypoint component on a Player object    
[RequireComponent(typeof(LocationManager))]
[RequireComponent(typeof(InventoryManager))]
[RequireComponent(typeof(CommandManager))]
public class PlayerController : MonoBehaviour
{
    public Player player;

    [HideInInspector] public LocationManager locationManager;
    [HideInInspector] public InventoryManager inventoryManager;
    [HideInInspector] public CommandManager commandManager;

    [HideInInspector] private DisplayTextController displayTextController;
    private bool canMoveDownAndLeft = true;


    void Awake()
    {
        Application.targetFrameRate = 30;
        locationManager = GetComponent<LocationManager>();
        inventoryManager = GetComponent<InventoryManager>();
        commandManager = GetComponent<CommandManager>();

        GameObject displayTextControllerObject = GameObject.FindWithTag("DisplayTextController");
        displayTextController = displayTextControllerObject.GetComponent<DisplayTextController>();

        Debug.Log("PlayerController mounted with ref to SceneController");

    }

    public void HandleEnterRoom(Location room)
    {
        locationManager.SetCurrentLocation(room);
        displayTextController.AddText("You entered " + room.name);
        commandManager.AddFromObjects(room.objectsInRoom);
        commandManager.AddFromLocations(room.accessibleLocations);
    }

    void HandleExitRoom()
    {
        commandManager.ClearAllCollections();
    }

    void HandleTakeItem(InteractableObject item)
    {
        inventoryManager.AddItem(item);
    }

    void HandleUseItem(InteractableObject item)
    {
        inventoryManager.RemoveItem(item);
    }

    public int HandleMove(Direction dir)
    {
        switch(dir)
        {
            case Direction.Right:
            {
                Debug.Log("Moving Right");
                return player.SetMovementPosX();
            }
            case Direction.Left:
            {
                if (canMoveDownAndLeft)
                {
                    Debug.Log("Moving Left");
                    return player.SetMovementNegX();
                }
                return 0;
            }
            case Direction.Up:
            {
                Debug.Log("Moving Up");
                return player.SetMovementPosY();
            }
            case Direction.Down:
            {
                if (canMoveDownAndLeft)
                {
                    Debug.Log("Moving Down");
                    return player.SetMovementNegY();
                }
                return 0;
            }
            default:
            {
                // TODO: Have Ette call the player out for being a hacker
                return 0;
            }
        }
    }

    public void Die()
    {
        Debug.Log("Player Died");
        displayTextController.inputField.enabled = false;
        SceneManager.LoadScene("GameOver", LoadSceneMode.Additive); 
    }

    public void RemoveDownAndLeftMovement()
    {
        canMoveDownAndLeft = false;
    }

}