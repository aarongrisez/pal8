using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    public bool isPlayer;
    public float speed = 20;
    public double changeDirectionProbability = 0.99;
    public Rigidbody2D rigidBody;

    protected float movementX;
    protected float movementY;
    protected bool changeDirection = false;
    protected System.Random rand = new System.Random();

    private void OnTriggerEnter2D(Collider2D other) {
        if (isPlayer)
        {
            HandleEnterRoom(other.gameObject.name);
        }
    }

    public abstract void HandleEnterRoom(string roomName);
}
