using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Warden_Health : MonoBehaviour
{

    [SerializeField] public double currentHealth;        // Current accessible health of Warden      
    public bool isInvulnerable = false; // For invulnerability powerup
    private double totalHealth;         // Warden Max Health
    private double healthPercentage;    // Percentage of health 
    private int projectileDamage;

    // variables for health visuals
    [SerializeField] private Text healthText;
    public SpriteRenderer Currenthealthbar;
    public SpriteRenderer Totalhealthbar;

    // Start is called before the first frame update
    void Start()
    {
        totalHealth = 200.00;           // Set the Warden health to 200
        currentHealth = totalHealth;    // start the current health to the total health
        healthPercentage = (currentHealth / totalHealth) * 100; // set healthPercentage
    }
    // Update function that adjusts the health percentage
    void UpdatePercentage()
    {
        healthPercentage = (currentHealth / totalHealth) * 100;
        if (healthPercentage <= 0)
        {
            restart();
        }
    }
    //function to reduce the health by a standard amount
    void ReduceHealth()
    {
        if (isInvulnerable == false)
        {
            if (totalHealth <= 0 || currentHealth <= 0)
            {
                return;
            }
            currentHealth = currentHealth - 10;
            UpdatePercentage();
        }
        return;
    }

    // function to reduce the health by a specific amount of damage
    public void ReduceHealth(double damageCoefficient)
    {
        if (isInvulnerable == false)
        {
            if (totalHealth <= 0 || currentHealth <= 0)
            {
                return;
            }
            currentHealth = currentHealth - damageCoefficient;
            UpdatePercentage();
        }
        return;
    }

    // function to heal by a standard amount
    void increaseHealth()
    {
        if (currentHealth >= totalHealth)
        {
            return;
        }
        currentHealth = currentHealth + 0.1;
        UpdatePercentage();
    }

    // function to heal by a specific amount
    void increaseHealth(double healCoefficient)
    {
        if (currentHealth >= totalHealth)
        {
            return;
        }
        currentHealth = currentHealth + (healCoefficient * 0.1);
    }

    // Destroys projectile when collision is detected
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Bullet"))
        {
            currentHealth = currentHealth - 5.0f;
            UpdatePercentage();
            Destroy(collision.gameObject);
        }
    }

    void restart()
    {
        SceneManager.LoadScene("HoboWin1");
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = currentHealth.ToString(".00");
        Currenthealthbar.size = new Vector2((float)(0.04 * currentHealth), Currenthealthbar.size.y);
        Totalhealthbar.size = new Vector2((float)(0.04 * totalHealth), Totalhealthbar.size.y);

    }

    public void setInvuln(bool invuln)
    {
        isInvulnerable = invuln;
    }

    public void heal()
    {
        currentHealth = totalHealth;
    }
}
