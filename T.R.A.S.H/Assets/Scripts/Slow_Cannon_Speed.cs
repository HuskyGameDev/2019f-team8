using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Slow_Cannon_Speed : Powerup 
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {

            StartCoroutine(SlowDownTimer());

        }
    }

    public IEnumerator SlowDownTimer()
    {
        Debug.Log("SlowTimerCannonSpeed");
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Renderer>().enabled = false;
        GameObject.FindGameObjectWithTag("Cannon").GetComponent<Crane_Projectile>().changeSpeed(1f);
        yield return new WaitForSeconds(5);
        GameObject.FindGameObjectWithTag("Cannon").GetComponent<Crane_Projectile>().changeSpeed(.25f);
        Destroy(gameObject);
    }
}
