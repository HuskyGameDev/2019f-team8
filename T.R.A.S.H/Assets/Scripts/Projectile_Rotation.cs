using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Rotation : MonoBehaviour
{
    int chance = 0;

    // Start is called before the first frame update
    void Start()
    {
        /* Get random value between 0 and 1 */
        Random.Range(0, 1);

        /* 50% chance to set flag to 1 */
        if (Random.value < 0.5)
        {
            chance = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /* Rotates projectile clockwise or counterclockwise based on flag */
        if(chance == 1)
        {
            transform.Rotate(0, 0, 100 * Time.deltaTime);
        } else
        {
            transform.Rotate(0, 0, -100 * Time.deltaTime);
        }
    }
}
