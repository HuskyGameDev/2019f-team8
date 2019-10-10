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
    void UpdatePercentage()
    {
        healthPercentage = (currentHealth / totalHealth) * 100;
    }
    void ReduceHealth()
    {
        if (totalHealth <= 0)
        {
            return;
        }
        // how much the health changes is placeholder atm
        currentHealth = currentHealth - 0.01;
        UpdatePercentage();
    }

    void ReduceHealth(double damageCoefficient)
    {
        if (totalHealth <= 0)
        {
            return;
        }
        // how much the health changes here is also placeholder atm
        currentHealth = currentHealth - (damageCoefficient * 0.01);
        UpdatePercentage();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
