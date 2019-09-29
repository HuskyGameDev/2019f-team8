using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane_Movement : MonoBehaviour
{
    void Update()
    {
        Vector3 positionOfMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);
        float angleOfRotation = (AngleBetweenCraneAndMouse(transform.position, positionOfMouse)) + 90;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angleOfRotation));
    }

    float AngleBetweenCraneAndMouse(Vector2 input1, Vector2 input2)
    {
        return Mathf.Rad2Deg * Mathf.Atan2(input1.y - input2.y, input1.x - input2.x);
    }
}
