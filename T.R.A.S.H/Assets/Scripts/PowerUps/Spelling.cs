using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spelling : MonoBehaviour
{
    System.Random rnd = new System.Random();
    private void Start()
    {
        char letter = (char)rnd.Next(97, 122);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Word_Storage wordScript = other.gameObject.getComponent<Word_Storage>();
            temp = wordScript.wordBuffer + letter;
            wordScript.wordBuffer = temp;
            Destroy(gameObject);
        }
    }

}
