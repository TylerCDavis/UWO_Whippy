﻿using UnityEngine;
using System.Collections;
using System.Diagnostics;


public class Instigator_Script : MonoBehaviour
{

    float accel = 0.25f;
    float decel = 0.09f;
    float maxSpeed = 6.0f;
    float currentSpeed = 0.0f;
    float minSpeed = 2.0f;

    int stopOrGo = 1;
    int WPIndex = 0;
    int SecondsForCrash = 0;
    float slowRotate = 1;

    public Transform[] waypoints;
    Transform currentWaypoint;

    Stopwatch wait = new Stopwatch();
    // Use this for initialization
    void Start()
    {
        wait.Start();
    }

    // Update is called once per frame
    void Update()
    {

        if (stopOrGo == 1)
        {
            GO();
        }
        else if (stopOrGo == 0)
        {
            STOP();
        }

        currentWaypoint = waypoints[WPIndex];
    }

    void GO()
    {





        System.TimeSpan ts = wait.Elapsed;

        if (WPIndex == 1)
        {
            if (ts.Minutes > 0 && ts.Seconds > 44 )
            {
                wait.Stop();
                accel = 0.25f;
            }
            else
            {
                currentSpeed = 0.0f;
                accel = 0f;
            }

        }

        if (WPIndex == 2)
        {
            maxSpeed = 3.5f;
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
    }

    void OnTriggerEnter()
    {
        WPIndex++;

        if (WPIndex > waypoints.Length)
        {
            currentSpeed = 0.0f;
            accel = 0.0f;
        }
    }
}