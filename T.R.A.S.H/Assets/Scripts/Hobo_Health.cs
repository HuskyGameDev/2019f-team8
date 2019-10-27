using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hobo_Health : MonoBehaviour
{
    public double currentHealth;        // Current accessible health of Hobo      
    private double totalHealth;         // Hobo Max Health
    private double healthPercentage;    // Percentage of health 

    // Start is called before the first frame update
    void Start()
    {
        totalHealth = 100.00;           // Set the hobo health to 100
        currentHealth = totalHealth;    // start the current health to the total health
        healthPercentage = (currentHealth / totalHealth) * 100; // set healthPercentage
    }
    // Update function that adjusts the health percentage
    void UpdatePercentage()
    {
        healthPercentage = (currentHealth / totalHealth) * 100;
    }
    // function to reduce the health by a standard amount
    void ReduceHealth()
    {
        if (totalHealth <= 0 || currentHealth <= 0)
        {
            return;
        }
        currentHealth = currentHealth - 0.1;
        UpdatePercentage();
    }

    // function to reduce the health by a specific amount of damage
    void ReduceHealth(double damageCoefficient)
    {
        if (totalHealth <= 0 || currentHealth <= 0)
        {
            return;
        }
        currentHealth = currentHealth - (damageCoefficient * 0.1);
        UpdatePercentage();
    }

    // function to heal by a standard amount
    void increaseHealth()
    {
        if(currentHealth >= totalHealth)
        {
            return;
        }
        currentHealth = currentHealth + 0.1;
        UpdatePercentage();
    }

    // function to heal by a specific amount
    void increaseHealth(double healCoefficient)
    {
        if(currentHealth >= totalHealth)
        {
            return;
        }
        currentHealth = currentHealth + (healCoefficient * 0.1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
