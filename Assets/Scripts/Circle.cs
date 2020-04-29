using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
 
    float timeCounter = 0;
    bool Direction = false;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Direction = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Direction = true;
        }
        if (Direction)
            timeCounter += Time.deltaTime;
        else
            timeCounter -= Time.deltaTime;
        float x = Mathf.Cos(timeCounter);
        float y = Mathf.Sin(timeCounter);
        float z = 0;
        transform.position = new Vector3(x, y, z);
    }
}
