using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spelling : Powerup
{
    System.Random rnd = new System.Random();
    char letter;
    private void Start()
    {
        letter = (char)rnd.Next(97, 122);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {

            Debug.Log("SpellingPowerup");
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Renderer>().enabled = false;
            GameObject.FindGameObjectWithTag("PowerupManager").GetComponent<Word_Storage>().addLetter(letter);
            Destroy(gameObject);

        }
    }
}
