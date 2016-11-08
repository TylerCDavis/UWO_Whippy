using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class Patrol : MonoBehaviour {

    float accel = 0.25f;
    float decel = 0.09f;
    float maxSpeed = 8.0f;
    float currentSpeed = 0.0f;
    float minSpeed = 2.0f;

    int stopOrGo= 1;
    int WPIndex = 0;
    float slowRotate = 1;

    public Transform[] waypoints;
    Transform currentWaypoint;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (stopOrGo == 1)
        {
            GO();
        }
        else if (stopOrGo == 0)
        {
            STOP();
            
        }
        currentWaypoint = waypoints[WPIndex];
	}//END Update

    void GO()
    {
        if(WPIndex == 2 || WPIndex ==6 || WPIndex ==11 || WPIndex ==15)
        {
            stopOrGo = 0;
        }
        if (currentWaypoint)
        {
            var rotation = Quaternion.LookRotation(currentWaypoint.position - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * slowRotate);
        }

        currentSpeed = currentSpeed + accel * accel;
        transform.Translate(0, 0, Time.deltaTime * currentSpeed);

        if (currentSpeed > maxSpeed)
        {
            currentSpeed = maxSpeed;
        }
    }

   void STOP()
    {
        if (currentWaypoint)
        {
            var rotation = Quaternion.LookRotation(currentWaypoint.position - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * slowRotate);
        }

        currentSpeed = currentSpeed - decel;
        transform.Translate(0, 0, Time.deltaTime * currentSpeed);

        if (currentSpeed < minSpeed)
        {
            currentSpeed = minSpeed;
        }

        if(WPIndex ==0 || WPIndex ==4 || WPIndex ==9 || WPIndex == 13)
        {
            stopOrGo = 1;
        }
    }

    void OnTriggerEnter()
    {
        WPIndex++;

        if(WPIndex > waypoints.Length)
        {
            WPIndex = 0;
            currentWaypoint = waypoints[WPIndex];
        }
    }
}
