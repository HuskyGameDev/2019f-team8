using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hobo_Projectile : MonoBehaviour
{
    /* Variable declarations */
    private float count;
    public static GameObject Projectile;
    public static GameObject projectile;
    public float fireRate;
    float angleOfRotation;
    float nextFire;
    float projectileSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Projectile = Resources.Load("trashbag") as GameObject; // Update according to prefab projectile location
        count = 0;
        projectileSpeed = 7f; // Speed of projectile (increase for faster projectiles)
        fireRate = .25F; // Length of cooldown timer (increase for more delay between shots)
        nextFire = 0F; // Container for cooldown timer
    }

    // Update is called once per frame
    void Update()
    {
        /* keeps track of total time that has passed */
        count += Time.deltaTime;

        /* if left shift is clicked and cooldown timer is up and 2 minutes have passed */
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > nextFire && count >= 120)
        {
            /* Fire projectile */
            Vector2 projectileDirection = new Vector2(0, -1);
            projectileDirection.Normalize();
            Vector2 endOfCannon = new Vector2(transform.position.x, transform.position.y - (float) 0.5);
            projectile = (GameObject)Instantiate(Projectile, endOfCannon, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = projectileDirection * projectileSpeed;
            /* Reset cooldown timer */
            nextFire = Time.time + fireRate;

            /* Destroy projectile (increase for faster deletion of projectile) */
            Destroy(projectile, 5f);
        }
        }
    
}
