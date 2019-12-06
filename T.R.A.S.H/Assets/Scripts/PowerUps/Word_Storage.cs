using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word_Storage : MonoBehaviour
{
    string wordBuffer = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // temporary, to be updated with actual words and effects
        // This is a template for how to check for the word inside of the buffer and to remove it from the buffer after the effect takes place
        if (wordBuffer.Contains("PLACEHOLDER")) {

            // perform some kind of power up effect
            wordBuffer.Replace("PLACEHOLDER", "");
        }
    }
}
