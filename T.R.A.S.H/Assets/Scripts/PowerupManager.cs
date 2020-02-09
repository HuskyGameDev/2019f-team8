using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
/*
public class PowerupManager : MonoBehaviour
{
    private static Timer PowerupTimer;
    private List<GameObject> powerups;
    private static int maxPowerups = 4;
    private static float minX;
    private static float maxX;
    private static float minY;
    private static float maxY;
    private static float interval = 10000.0f;

    // Start is called before the first frame update
    void Start()
    {
        PowerupTimer = new Timer(interval);
        PowerupTimer.Elapsed += new ElapsedEventHandler(spawnPowerup);
        PowerupTimer.Start();
        PowerupTimer.AutoReset = true;
    }

    // Update is called once per frame
    void Update()
    {
        newPower = Random.Range(0, 2); //update as more powerups are added
    }

    void spawnPowerup()
    {
        if (powerups.Length !>= maxPowerups)
        {
            Powerup powerup;
            Vector2 spawnPoint = Vector2.zero;

            randomX = Random.Range(minX, maxX);
            randomY = Random.Range(minY, maxY);
            spawnPosition.x = randomX;
            spawnPosition.y = ySpawn;

            // add new powerup to our powerup List
            powerups.Add(powerup.powerup(newPower));
        }
    }
}
*/
