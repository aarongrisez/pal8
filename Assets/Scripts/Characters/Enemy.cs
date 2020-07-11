using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{    
    // Update is called once per frame
    void Update()
    {
        changeDirection = rand.NextDouble() > changeDirectionProbability;
        if (changeDirection)
        {
            movementX = (float)(rand.NextDouble() * 2.0 - 1.0);
            movementY = (float)(rand.NextDouble() * 2.0 - 1.0);
            changeDirection = false;
        }
        else
        {
            changeDirection = rand.NextDouble() > changeDirectionProbability;
        }

        rigidBody.velocity = new Vector2(movementX * speed, movementY * speed);
    }

    public override void HandleEnterRoom(string roomName)
    {
        Debug.Log("Player entered " + roomName);
    }
}