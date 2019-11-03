using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hobo_Movement : MonoBehaviour
{
    public bool playerDirectionRight = true;
    public float moveXAxis;
    public float moveYAxis;
    public int playerMovementSpeed = 6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3 (0.0f, playerMovementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(playerMovementSpeed * Time.deltaTime, 0.0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0.0f, playerMovementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(playerMovementSpeed * Time.deltaTime, 0.0f);
        }
    }

    // Flips player sprite when changing directions, left and right.
    void FlipSprite()
    {
        playerDirectionRight = !playerDirectionRight;
        Vector2 direction = gameObject.transform.localScale;
        direction.x *= -1;
        transform.localScale = direction;
    }

    // Destroys projectile when collision is detected
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
