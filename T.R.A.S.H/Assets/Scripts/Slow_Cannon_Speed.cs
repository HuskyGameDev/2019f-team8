using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Slow_Cannon_Speed : Powerup 
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Crane_Projectile craneScript = other.gameObject.GetComponent<Crane_Projectile>(); // not sure about the syntax here...
            if (craneScript)
            {
                // We speed up the player and then tell to stop after a few seconds
                // craneScript.fireRate = 0.5f;
                // craneScript.StopSlowDown();
            }
            Destroy(gameObject);
        }
    }
}
