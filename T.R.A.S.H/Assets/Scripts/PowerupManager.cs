using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System;

public class PowerupManager : MonoBehaviour
{
    public static GameObject Invulnerability;
    public static GameObject SlowCannon;
    public static GameObject Spelling;
    public GameObject powerup1;
    public GameObject powerup2;
    private static float minX = -5.027f;
    private static float maxX = 5.0446f;
    private static float minY = -2.2f;
    private static float maxY = 5.0f;
    private float randomX = 0.0f;
    private float randomY = 0.0f;

    System.Random rnd = new System.Random();
    private int randomPowerup;
    public GameObject newPowerup;

    void Start()
    {
        Invulnerability = Resources.Load("Invulnerability") as GameObject;
        SlowCannon = Resources.Load("SlowCannon") as GameObject;
        Spelling = Resources.Load("Spelling") as GameObject;
        StartCoroutine(SpawnPowerups());
    }

    public IEnumerator SpawnPowerups()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            if(powerup1 == null)
            {
                randomPowerup = rnd.Next(0, 3);
                randomX = (float)rnd.NextDouble() * (maxX - minX) + minX;
                randomY = (float)rnd.NextDouble() * (maxY - minY) + minY;
                switch (randomPowerup)
                {
                    case 0:
                        powerup1 = (GameObject)Instantiate(Invulnerability, new Vector2(randomX, randomY), Quaternion.identity);
                        break;
                    case 1:
                        powerup1 = (GameObject)Instantiate(SlowCannon, new Vector2(randomX, randomY), Quaternion.identity);
                        break;
                    case 2:
                        powerup1 = (GameObject)Instantiate(Spelling, new Vector2(randomX, randomY), Quaternion.identity);
                        break;
                    default:
                        break;

                }
            }
            else if(powerup2 == null)
            {
                randomPowerup = rnd.Next(0, 3);
                randomX = (float)rnd.NextDouble() * (maxX - minX) + minX;
                randomY = (float)rnd.NextDouble() * (maxY - minY) + minY;
                switch (randomPowerup)
                {
                    case 0:
                        powerup2 = (GameObject)Instantiate(Invulnerability, new Vector2(randomX, randomY), Quaternion.identity);
                        break;
                    case 1:
                        powerup2 = (GameObject)Instantiate(SlowCannon, new Vector2(randomX, randomY), Quaternion.identity);
                        break;
                    case 2:
                        powerup2 = (GameObject)Instantiate(Spelling, new Vector2(randomX, randomY), Quaternion.identity);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}