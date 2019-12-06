using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float timeBetweenSpawns = 10f;
    public float maxPowerups = 4f;

    private int powerupsOnMap;

    void Start()
    {
        startPowerupSpawning();
    }

    void startPowerupSpawning()
    {
        powerupsOnMap = 0;

        StartCoroutine(spawnPowerups);
    }

    IEnumerator spawnPowerups()
    {
        while (powerupsOnMap < maxPowerups)
        {
            //TODO: Make spawn conditions for powerups
            yield return new WaitForSeconds(timeBetweenSpawns);
            while (powerupsOnMap == maxPowerups) { }
        }

        yield return null;
    }
}
