using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timer : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] private float primaryTimer;

    private float duration;
    // Booleans to allow counting and start counting
    private bool counting = true;
    private bool doOnce = false;

    // Start is called before the first frame update
    void Start()
    {
       // set the duration of the timer to what is in the timerControl text field
        duration = primaryTimer; 
    }

    // Update is called once per frame
    void Update()
    {
        if(duration >= 0.0f && counting)
        {
            // update by delta time and set the UI text to display time to one decimal place
            duration -= Time.deltaTime;
            uiText.text = duration.ToString("0.0");
        }
        // prevents the timer from going negative
        else if(duration <= 0.0f && !doOnce)
        {
            counting = false;
            doOnce = true;
            uiText.text = "0";
            duration = 0.0f;
        }
    }
}
