using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hobo_Movement : MonoBehaviour
{
    public bool playerDirectionRight = true;
    public float moveXAxis;
    public float moveYAxis;
    public int playerMovementSpeed = 10;
    Vector2 playerSize;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Holds movement controls, animations, character physics
    void PlayerMove()
    {
        int movespeed = playerMovementSpeed;
        moveXAxis = Input.GetAxis("Horizontal");
        moveYAxis = Input.GetAxis("Vertical");
        if (moveXAxis > 0.0f && playerDirectionRight == false)
        {
            FlipSprite();
        }
        if (moveXAxis < 0.0f && playerDirectionRight == true)
        {
            FlipSprite();
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveXAxis * movespeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    //Flips player sprite when changing directions, left and right.
    void FlipSprite()
    {
        playerDirectionRight = !playerDirectionRight;
        Vector2 direction = gameObject.transform.localScale;
        direction.x *= -1;
        transform.localScale = direction;
    }
}
