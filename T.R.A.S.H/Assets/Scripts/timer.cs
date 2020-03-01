using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timer : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] private float primaryTimer;

    public GameObject backgroundPrelim;
    public GameObject background01;
    public GameObject background02;

    private float duration;
    // Booleans to allow counting and start counting
    private bool counting = true;
    private bool doOnce = false;
    private bool doTwice = false;
    private bool doThrice = false;

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
            //counting = false;
            doOnce = true;
            uiText.text = "60";
            duration = 60.0f;
            backgroundPrelim.SetActive(false);

        }
        else if (duration <= 0.0f && !doTwice)
        {
            //counting = false;
            doTwice = true;
            uiText.text = "60";
            duration = 60.0f;
            background01.active = false;

        }
        else if (duration <= 0.0f && !doThrice)
        {
            //counting = false;
            doThrice = true;
            uiText.text = "60";
            duration = 60.0f;
            background02.active = false;

        }
    }
}
