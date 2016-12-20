using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Threading;
public class Path02 : MonoBehaviour {

    float accel = 0.20f;
    float decel = 0.045f;
    float maxSpeed;
    float minSpeed = 2.0f;
    private float currentSpeed = 1.0f;
    float rotationDamping = 1f;//Makes rotation during turns slower rather than immediate. 
    Stopwatch redTimer = new Stopwatch();

    private int stopOrGo = 1; //stop is 0, Go is 1;
    private int WPIndexPointer = 0;

    bool smoothRotation = true;


    private Transform currentWaypoint;
    //holds the current waypoint

    public Transform[] waypoints;
    //holds the waypoints assigned in the inspector

    //public GameObject streetLight;
    //traffic light to check for red


    void Start()
    {

        stopOrGo = 1;

    }//END start

    void Update()
    {

        if (stopOrGo == 1)
        {
            //function that will set the speed and rotation speed according to certain waypoints.
            //StartCoroutine(GO());
            GO();

        }
        if (stopOrGo == 0)
        {
            STOP();
        }

        currentWaypoint = waypoints[WPIndexPointer];
    }//END update

    void GO()
    {

        if (WPIndexPointer == 1)
        {
            maxSpeed = 2.0f;
        }
        if (WPIndexPointer == 7)
        {
            maxSpeed = 8.0f;
        }
        if (WPIndexPointer == 9)
        {
            minSpeed = 3.0f;
            stopOrGo = 0;
        }
        if (WPIndexPointer == 10)
        {
            maxSpeed = 4.0f;
        }
        if (WPIndexPointer == 11)
        {
            redTimer.Start();
            System.TimeSpan redCheck = redTimer.Elapsed;

            if(redCheck.Seconds <= 1)
            {
                maxSpeed = 0.0f;
                currentSpeed = 0.0f;
                accel = 0.0f;

            }
            else
            {
                redTimer.Stop();
                maxSpeed = 2.0f;
                
                accel = 0.20f;
            }
        }

        if (WPIndexPointer == 13)
        {
            maxSpeed = 8.0f;
        }
        if (WPIndexPointer == 15)
        {
            stopOrGo = 0;
        }
        if (WPIndexPointer == 16)
        {
            redTimer.Start();
            System.TimeSpan redCheck = redTimer.Elapsed;

            if (redCheck.Seconds <= 1)
            {
                maxSpeed = 0.0f;
                currentSpeed = 0.0f;
                accel = 0.0f;

            }
            else
            {
                redTimer.Stop();
                maxSpeed = 8.0f;

                accel = 0.20f;
            }
        }
        if (WPIndexPointer == 21)
        {

            //var script = GetComponent("Path 02");
            //script.gameObject.SetActive(false);

            maxSpeed = 0.0f;
            accel = 0.0f;
        }
        if (currentWaypoint)
        {

            //Quaternion.LookRotation creates the car's rotation in turns. Function takes Vector3 variables to determine forward movement and upward movement.
            var rotation = Quaternion.LookRotation(currentWaypoint.position - transform.position);

            //This function simulates a car turning by slowing the rotation speed.
            //transform.rotation is the car's current rotation.
            //Quaternion.Slerp measures the rotation between 2 quaternions based on a time parameter.            
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
        }
        //Accelerate towards waypoint
        currentSpeed = currentSpeed + accel * accel;
        transform.Translate(0, 0, Time.deltaTime * currentSpeed);

        if (currentSpeed > maxSpeed)
        {
            currentSpeed = maxSpeed;
        }


    }//END GO

    void OnTriggerEnter()
    {
        redTimer.Reset();

        WPIndexPointer++;
    }


    void STOP()
    {
        if (currentWaypoint)
        {

            //Quaternion.LookRotation creates the car's rotation in turns. Function takes 1 or 2 Vector3 variables to determine forward movement and upward movement.
            var rotation = Quaternion.LookRotation(currentWaypoint.position - transform.position);

            //This function simulates a car turning by slowing the rotation speed.
            //transform.rotation is the car's current rotation.
            //Quaternion.Slerp measures the rotation between 2 quaternions based on a time parameter.            
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
        }

        currentSpeed = currentSpeed - decel;
        transform.Translate(0, 0, Time.deltaTime * currentSpeed);

        if (currentSpeed <= minSpeed)
        {
            currentSpeed = minSpeed;
        }

        if (WPIndexPointer == 10)
        {minSpeed=2.0f;
                stopOrGo = 1;            
        }
        if (WPIndexPointer == 16)
        {
            stopOrGo = 1;
        }


    }//END STOP


}