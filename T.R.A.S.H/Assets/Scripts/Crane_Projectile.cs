using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane_Projectile : MonoBehaviour
{
    /* Variable declarations */
    public static GameObject Projectile;
    public static AudioSource projectileAudio;
    public static AudioClip audioClip1; 
    public static AudioClip audioClip2;
    public static AudioClip audioClip3;
    public float fireRate;
    public int projectileCode;
    float angleOfRotation;
    float nextFire;
    float projectileSpeed;
    int numberOfProjectile = 2; // Update to current count of projectiles if changed

    // Start is called before the first frame update
    void Start()
    {
        projectileAudio = GetComponent<AudioSource>();
        audioClip1 = Resources.Load<AudioClip>("cannonNoise");
        audioClip2 = Resources.Load<AudioClip>("trashbagNoise");
        audioClip3 = Resources.Load<AudioClip>("cardoorNoise");
        Projectile = Resources.Load("trashbag") as GameObject; // Update according to prefab projectile location
        projectileCode = 1;

        projectileSpeed = 3.5f; // Speed of projectile (increase for faster projectiles)
        fireRate = .5F; // Length of cooldown timer (increase for more delay between shots)
        nextFire = 0F; // Container for cooldown timer
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 50 * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            projectileCode++;
            if(projectileCode > numberOfProjectile)
            {
                projectileCode = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            projectileCode--;
            if (projectileCode < 1)
            {
                projectileCode = numberOfProjectile;
            }
        }

        /* if mouse is clicked and cooldown timer is up */
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            projectileAudio.PlayOneShot(audioClip1);
            SetProjectile(projectileCode);

            /* Reset cooldown timer */
            nextFire = Time.time + fireRate;

            /* Fire projectile */
            Vector3 positionOfMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);
            Vector2 projectileDirection = positionOfMouse - transform.position;
            projectileDirection.Normalize();
            GameObject projectile = (GameObject)Instantiate(Projectile, transform.position, Quaternion.identity);

            /* Rotate projectile orientation to match orientation of cannon */
            angleOfRotation = (AngleBetweenCraneAndMouse(transform.position, positionOfMouse)) + 90;
            projectile.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angleOfRotation));
            projectile.GetComponent<Rigidbody2D>().velocity = projectileDirection * projectileSpeed;
         
            /* Destroy projectile (increase for faster deletion of projectile) */
            Destroy(projectile, 5f);
        }      
    }

    /*
    public IEnumerator StopSlowDown()
    {
        yield return new WaitForSeconds(5.0f);
        fireRate = 1.0f;
    }
    */

    float AngleBetweenCraneAndMouse(Vector2 input1, Vector2 input2)
    {
        return Mathf.Rad2Deg * Mathf.Atan2(input1.y - input2.y, input1.x - input2.x);
    }

    void randomProjectileSprite()
    {
        /* Get random value between 0 and 1 */
        Random.Range(0, 1);

        /* 50% chance to set sprite to either option */
        if(Random.value < 0.5)
        {
            Projectile = Resources.Load("trashbag") as GameObject; ;
        }
        else
        {
            Projectile = Resources.Load("cardoor") as GameObject; ;
        }
    }

    // 
    void SetProjectile(int projectileCode)
    {
        if(projectileCode == 1)
        {
            randomProjectileSprite();
        }
        else if(projectileCode == 2)
        {
            randomProjectileSprite(); // remove when the below line is complete

            // Projectile = Resources.Load("// Full Car Object Name (Not Yet Added)") as GameObject;
        }
    }

    public static void playAudio(string name)
    {
        if (name == "trashbag(Clone)")
        {
            projectileAudio.PlayOneShot(audioClip2);
        }
        else if (name == "cardoor(Clone)")
        {
            projectileAudio.PlayOneShot(audioClip3);
        }
    }
}
