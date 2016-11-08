using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Threading;

public class Path01 : MonoBehaviour {

    float accel = 0.25f;
    float decel = 0.09f;
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
       
        if (WPIndexPointer == 1){
            maxSpeed = 2.0f;            
        }
           
        if (WPIndexPointer == 7)
        {     maxSpeed = 2.5f;       
                       
        }
        if(WPIndexPointer == 9)
        {
            maxSpeed = 10.0f;
            
        }
        if (WPIndexPointer == 11)
        {
            stopOrGo = 0;
        }
        if (WPIndexPointer == 12)
        {
            maxSpeed = 3.0f;
        }
        
        if (WPIndexPointer == 14)
        {
            maxSpeed = 8.0f;
        }
        if (WPIndexPointer == 15)
        {
            // MeshRenderer streetLightRenderer = streetLight.GetComponent<MeshRenderer>();

            //  Material streetLightColour = streetLightRenderer.material;
            // Material red = streetLightRenderer.material;

            //  while (streetLightColour == red)
            //  {
            //streetLightRenderer = streetLight.GetComponent<MeshRenderer>();
            //    streetLightColour = streetLightRenderer.material;                
            // }

            //decel to street light
            stopOrGo = 0;
                        
        }
        if (WPIndexPointer == 16)
        {
           // redTimer.Start();


           // System.TimeSpan redCheck = redTimer.Elapsed;
                      
          //  if (redCheck.Seconds <= 3)
           // {
              
               //currentSpeed = 0.0f;
              //  accel = 0f;
           // }
           // else
           // {
            //    redTimer.Stop();
            //    accel = 0.25f;
          //  }

        }
        if (WPIndexPointer == 17)
        {
            //decel to street light
            //decel = 1f;
            stopOrGo = 0;
        }
        if (WPIndexPointer == 18)
        {

            redTimer.Start();
             System.TimeSpan redCheck = redTimer.Elapsed;
       
              if (redCheck.Seconds <= 4)
             {

            currentSpeed = 0.0f;
              accel = 0f;
             }
             else
             {
                redTimer.Stop();
                accel = 0.25f;
              }

            maxSpeed = 3.0f;
        }
        if(WPIndexPointer==20)
        {
            maxSpeed = 7.0f;
  
        }
        if (WPIndexPointer == 24)
        {
            maxSpeed = 0f;
            accel = 0f;
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
       

        //if (WPIndexPointer >= waypoints.Length)
        //{
         //   WPIndexPointer = 0;
         
        //}
      
        
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
        transform.Translate(0,0, Time.deltaTime*currentSpeed);

        if(currentSpeed<= minSpeed)
        {
            currentSpeed = minSpeed;
        }

        
        if (WPIndexPointer == 12 || WPIndexPointer==16 || WPIndexPointer==18)
        {
            stopOrGo = 1;
        }
        
    }//END STOP

    
}
