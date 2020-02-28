using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane_Projectile : MonoBehaviour
{
    /* Variable declarations */
    public static GameObject Projectile;
    public static GameObject projectile;
    public static AudioSource projectileAudio;
    public static AudioClip audioClip1; 
    public static AudioClip audioClip2;
    public static AudioClip audioClip3;
    public static AudioClip audioClip4;
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
        audioClip4 = Resources.Load<AudioClip>("wholecarNoise");
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

            if (projectileCode == 1)
            {
                fireRate = .5F;
            }
            else if (projectileCode == 2)
            {
                fireRate = 3F;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            projectileCode--;
            if (projectileCode < 1)
            {
                projectileCode = numberOfProjectile;
            }

            if (projectileCode == 1)
            {
                fireRate = .5F;
            }
            else if (projectileCode == 2)
            {
                fireRate = 3F;
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
            Vector2 endOfCannon = new Vector2(projectileDirection.x, projectileDirection.y - 4.59f);
            projectile = (GameObject)Instantiate(Projectile, endOfCannon, Quaternion.identity);

            /* Rotate projectile orientation to match orientation of cannon */
            angleOfRotation = (AngleBetweenCraneAndMouse(transform.position, positionOfMouse)) + 90;
            projectile.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angleOfRotation));
            projectile.GetComponent<Rigidbody2D>().velocity = projectileDirection * projectileSpeed;
         
            /* Destroy projectile (increase for faster deletion of projectile) */
            Destroy(projectile, 5f);
        }

        /* if wholecar object exists in the scene */
        if (GameObject.Find("wholecar(Clone)") != null)
        {
            /* when down arrow key is pressed */
            if (projectile.name == "wholecar(Clone)" && Input.GetKeyDown(KeyCode.DownArrow))
            {
                /* store position of car splitting, destroy car, produce car fragments */
                Vector3 positionOfWholeCar = projectile.transform.position;
                Destroy(projectile);
                SplitCar(positionOfWholeCar);
            }
        }
    }

    float AngleBetweenCraneAndMouse(Vector2 input1, Vector2 input2)
    {
        return Mathf.Rad2Deg * Mathf.Atan2(input1.y - input2.y, input1.x - input2.x);
    }

    /* create the 8 fragments of car and send them in random directions */
    void SplitCar(Vector3 positionOfWholeCar)
    {
        float x;
        float y;

        /* Fire projectiles */
        x = randomNumber();
        y = randomNumber();
        Vector2 projectileDirection1 = new Vector2(x, y);
        projectileDirection1.Normalize();
        projectile = (GameObject)Instantiate(Resources.Load("cardoor"), positionOfWholeCar, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = projectileDirection1 * projectileSpeed * 2;
        Destroy(projectile, 5f);
        x = randomNumber();
        y = randomNumber();
        Vector2 projectileDirection2 = new Vector2(x, y);
        projectileDirection1.Normalize();
        projectile = (GameObject)Instantiate(Resources.Load("carpiece"), positionOfWholeCar, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = projectileDirection2 * projectileSpeed * 2;
        Destroy(projectile, 5f);
        x = randomNumber();
        y = randomNumber();
        Vector2 projectileDirection3 = new Vector2(x, y);
        projectileDirection1.Normalize();
        projectile = (GameObject)Instantiate(Resources.Load("carwheel"), positionOfWholeCar, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = projectileDirection3 * projectileSpeed * 2;
        Destroy(projectile, 5f);
        x = randomNumber();
        y = randomNumber();
        Vector2 projectileDirection4 = new Vector2(x, y);
        projectileDirection1.Normalize();
        projectile = (GameObject)Instantiate(Resources.Load("carchair"), positionOfWholeCar, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = projectileDirection4 * projectileSpeed * 2;
        Destroy(projectile, 5f);
        x = randomNumber();
        y = randomNumber();
        Vector2 projectileDirection5 = new Vector2(x, y);
        projectileDirection5.Normalize();
        projectile = (GameObject)Instantiate(Resources.Load("cardoor"), positionOfWholeCar, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = projectileDirection5 * projectileSpeed * 2;
        Destroy(projectile, 5f);
        x = randomNumber();
        y = randomNumber();
        Vector2 projectileDirection6 = new Vector2(x, y);
        projectileDirection6.Normalize();
        projectile = (GameObject)Instantiate(Resources.Load("carpiece"), positionOfWholeCar, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = projectileDirection6 * projectileSpeed * 2;
        Destroy(projectile, 5f);
        x = randomNumber();
        y = randomNumber();
        Vector2 projectileDirection7 = new Vector2(x, y);
        projectileDirection7.Normalize();
        projectile = (GameObject)Instantiate(Resources.Load("carwheel"), positionOfWholeCar, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = projectileDirection7 * projectileSpeed * 2;
        Destroy(projectile, 5f);
        x = randomNumber();
        y = randomNumber();
        Vector2 projectileDirection8 = new Vector2(x, y);
        projectileDirection8.Normalize();
        projectile = (GameObject)Instantiate(Resources.Load("carchair"), positionOfWholeCar, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = projectileDirection8 * projectileSpeed * 2;
        Destroy(projectile, 5f);
    }

    /* produce random coordinate piece that is not too small */
    float randomNumber()
    {
        float z = 0;
        while(Mathf.Abs(z) < 0.1)
        {
            z = Random.Range(-0.75f, 0.75f);
        }
        return z;
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
    
    void SetProjectile(int projectileCode)
    {
        if(projectileCode == 1)
        {
            randomProjectileSprite();
        }
        else if(projectileCode == 2)
        {
            Projectile = Resources.Load("wholecar") as GameObject;
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
        else if (name == "wholecar(Clone)")
        {
            projectileAudio.PlayOneShot(audioClip4);
        }
        else // remaining car parts
        {
            projectileAudio.PlayOneShot(audioClip3);
        }
    }
}
