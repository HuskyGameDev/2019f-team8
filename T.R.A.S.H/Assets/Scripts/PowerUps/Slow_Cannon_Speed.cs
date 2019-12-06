using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Slow_Cannon_Speed : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Crane_Projectile craneScript = other.gameObject.GetComponent<Crane_Projectile>(); 
            if (craneScript)
            {
                
                //craneScript.fireRate = 2.0f;
                //craneScript.StopSlowDown();
            }
            Destroy(gameObject);
        }
    }
}
