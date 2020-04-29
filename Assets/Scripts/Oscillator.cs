using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Oscillator : MonoBehaviour
{
    readonly double limitX = 11.48;
    [Tooltip("Movement speed in meters per second")] [SerializeField] float speed = 1;
    private Vector3 pos;
    private double stepsFix;
    double steps;
    double tempsteps;
    int i = 0;
    int stop = 0;
    string dir = "right";
    float tempSpeed;

    int slow = 0;
    int run = 0;
    // Start is called before the first frame update
    void Start()
    {
        //לקבל את הנקודה שבה נמצא האובייקט
        pos = transform.position;

        //you can find the object position by the name of the object.
        //pos=GameObject.Find("Your_Name_Here").transform.position;

        //לבדוק את המרחק הקצר= מינימום של גבול ימין וגבול שמאל
        stepsFix = steps = limitX - Math.Abs(pos.x);
        tempsteps = steps;
        tempSpeed = speed;
        speed = speed / 1000;
        //לנוע ימינה את המרחק הזה ואז שמאלה את המרחק כפול 2 וחוזר חלילה
    }

    // Update is called once per frame
    void Update()
    {
        if (stop == 0)
        {
            if (dir == "right" && steps > 0)
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                //steps -= tempSpeed * Time.deltaTime;
                steps -= speed * Time.deltaTime;

                //האטה
                if (steps <= 2 && steps > 1 && slow < 5)
                {
                    slow++;
                    speed = speed - (speed / 10);
                }
                if (steps <= 1 && slow < 10)
                {
                    slow++;
                    speed = speed - (speed / 10);
                }

                //האצה
                if (tempsteps - steps < 1 && run < 1)
                {
                    run++;
                    speed += (tempSpeed / 10);
                }
                else if (tempsteps - steps < 2 && tempsteps - steps >1 && run < 3)
                {
                    run++;
                    speed += (tempSpeed / 10);
                }
                else if (tempsteps - steps < 3 && tempsteps - steps > 2 && run < 4)
                {
                    run++;
                    speed += (tempSpeed / 10);
                }
                else if(tempsteps - steps > 3 && run < 5)
                {
                    run++;
                    speed = tempSpeed;
                }

                //עצירה
                if (steps <= 0)
                {
                    dir = "left";
                    steps = stepsFix * 2;
                    tempsteps = steps;
                    //speed = tempSpeed;
                    stop = 300;
                    slow = 0;
                    run = 0;
                    speed = tempSpeed / 100;

                }
            }
            else if (dir == "left" && steps > 0)
            {
                transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                steps -= speed * Time.deltaTime;
                //האטה
                if (steps <= 2 && steps > 1 && slow < 5)
                {
                    slow++;
                    speed = speed - (speed / 10);
                }
                if (steps <= 1 && slow<10)
                {
                    slow++;
                    speed = speed - (speed / 10);
                }

                //האצה
                if (tempsteps - steps < 1 && run < 1)
                {
                    run++;
                    speed += (tempSpeed / 10);
                }
                else if (tempsteps - steps < 2 && tempsteps - steps > 1 && run < 3)
                {
                    run++;
                    speed += (tempSpeed / 10);
                }
                else if (tempsteps - steps < 3 && tempsteps - steps > 2 && run < 4)
                {
                    run++;
                    speed += (tempSpeed / 10);
                }
                else if (tempsteps - steps > 3 && run < 5)
                {
                    run++;
                    speed = tempSpeed;
                }

                //עצירה
                if (steps <= 0)
                {
                    dir = "right";
                    steps = stepsFix * 2;
                    tempsteps = steps;
                    //speed = tempSpeed;
                    stop = 300;
                    slow = 0;
                    run = 0;
                    speed = tempSpeed / 100;

                }
            }
            Debug.Log("i->" + i);
            i++;
        }
        else
        {
            stop--;
        }
    }
}
