using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane_Projectile : MonoBehaviour
{
    /* Variable declarations */
    public GameObject Projectile;
    float projectileSpeed;
    public float fireRate;
    float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        Projectile = Resources.Load("trashbag") as GameObject; // Update according to prefab projectile location
        projectileSpeed = 3.5f; // Speed of projectile (increase for faster projectiles)
        fireRate = 0.25F; // Length of cooldown timer (increase for more delay between shots)
        nextFire = 0F; // Container for cooldown timer
    }

    // Update is called once per frame
    void Update()
    {
        /* if mouse is clicked and cooldown timer is up */
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            /* Reset cooldown timer */
            nextFire = Time.time + fireRate;

            /* Fire projectile */
            Vector3 positionOfMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);
            Vector2 projectileDirection = positionOfMouse - transform.position;
            projectileDirection.Normalize();
            GameObject projectile = (GameObject)Instantiate(Projectile, transform.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = projectileDirection * projectileSpeed;
         
            /* Destroy projectile (increase for faster deletion of projectile) */
            Destroy(projectile, 5f);
        }      
    }

    public IEnumerator StopSlowDown()
    {
        yield return new WaitForSeconds(5.0f);
        fireRate = 1.0f;
    }

}
