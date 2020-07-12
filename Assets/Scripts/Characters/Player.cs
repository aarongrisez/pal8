using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    public int randMotionMax = 14;
    public int randMotionMin = 8;

    private int xStepsRemaining = 0;
    private int yStepsRemaining = 0;
    private float dirX = (float)1.0;
    private float dirY = (float)1.0;
    [HideInInspector] private PlayerController playerController;

    void Awake()
    {
        GameObject playerControllerObject = GameObject.FindWithTag("PlayerController");
        playerController = playerControllerObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float vX = (float)0.0;
        float vY = (float)0.0;
        if (xStepsRemaining > 0)
        {
            xStepsRemaining -= 1;
            vX = speed * dirX;
        }
        if (yStepsRemaining > 0)
        {
            yStepsRemaining -= 1;
            vY = speed * dirY;
        }
        rigidBody.velocity = new Vector2(vX, vY);
    }

    public void SetMovementPosX()
    {
        dirX = (float)1.0;
        xStepsRemaining += rand.Next(randMotionMin, randMotionMax);
    }

    public void SetMovementNegX()
    {
        dirX = (float)(-1.0);
        xStepsRemaining += rand.Next(randMotionMin, randMotionMax);
    }

    public void SetMovementPosY()
    {
        dirY = (float)1.0;
        yStepsRemaining += rand.Next(randMotionMin, randMotionMax);
    }

    public void SetMovementNegY()
    {
        dirY = (float)(-1.0);
        yStepsRemaining += rand.Next(randMotionMin, randMotionMax);
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