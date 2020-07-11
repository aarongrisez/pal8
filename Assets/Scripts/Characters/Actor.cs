using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{

    public bool isPlayer;
    public float speed = 20;
    public double changeDirectionProbability = 0.99;
    public Rigidbody2D rigidBody;

    private float movementX;
    private float movementY;
    private bool changeDirection = false;

    private System.Random rand = new System.Random();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer)
        {
            movementX = Input.GetAxisRaw("Horizontal");
            movementY = Input.GetAxisRaw("Vertical");
        }

        else
        {
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
        }

        rigidBody.velocity = new Vector2(movementX * speed, movementY * speed);
    }
}
