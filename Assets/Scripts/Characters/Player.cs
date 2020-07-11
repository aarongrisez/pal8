using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{

    [HideInInspector] private PlayerController playerController;

    void Awake()
    {
        GameObject playerControllerObject = GameObject.FindWithTag("PlayerController");
        playerController = playerControllerObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");
        rigidBody.velocity = new Vector2(movementX * speed, movementY * speed);
    }

    public override void HandleEnterRoom(string roomName)
    {
        Location newRoom = playerController.locationManager.GetAccessibleLocationByName(roomName);
        if (newRoom != null)
        {
            playerController.HandleEnterRoom(newRoom);
            Debug.Log("Player entered " + roomName);
        }
        else
        {
            Debug.Log("ERROR! Something happened and the player tried to enter an inaccessible room, " + roomName);
            Debug.Log("This is sloppy but acceptable if this was the initial spawn point.");
        }
    }
}