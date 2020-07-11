﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Entrypoint component on a Player object    
[RequireComponent(typeof(LocationManager))]
[RequireComponent(typeof(InventoryManager))]
[RequireComponent(typeof(CommandManager))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector] public LocationManager locationManager;
    [HideInInspector] public InventoryManager inventoryManager;
    [HideInInspector] public CommandManager commandManager;
    [HideInInspector] private SceneController sceneController;

    void Awake()
    {
        locationManager = GetComponent<LocationManager>();
        inventoryManager = GetComponent<InventoryManager>();
        commandManager = GetComponent<CommandManager>();

        GameObject sceneControllerObject = GameObject.FindWithTag("SceneController");
        sceneController = sceneControllerObject.GetComponent<SceneController>();

        Debug.Log("PlayerController mounted with ref to SceneController");

    }

    public void HandleEnterRoom(Location room)
    {
        locationManager.SetCurrentLocation(room);
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

}