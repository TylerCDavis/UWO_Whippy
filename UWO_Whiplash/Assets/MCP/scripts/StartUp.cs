using UnityEngine;
using System.Collections;

public class StartUp : MonoBehaviour {

    public GameObject Player_WP_Collider;
    public GameObject Path01Wps;
    public GameObject Path02WPs;
    public GameObject P1CrashCar;
    public GameObject P2CrashCar;
    public GameObject P2ActualCar;
    public GameObject Camera;
    public GameObject trafficLights;
   // public GameObject horizontalLook;

	// Use this for initialization
	void Start () {
        //Disable all scripts or objects that use timers then reactivate them when the player selects a path       
       
        Player_WP_Collider.GetComponent<Path01>().enabled = false;
        Player_WP_Collider.GetComponent<Path02>().enabled = false;
        Path01Wps.SetActive(false);
        Path02WPs.SetActive(false);
        P1CrashCar.SetActive(false);
        P2CrashCar.SetActive(false);
        P2ActualCar.SetActive(false);
        trafficLights.SetActive(false);
        Camera.GetComponent<VRCamera>().enabled = false;
        //horizontalLook.GetComponent<MouseLook>().enabled = false;
        
        
        
     
    }
	
}
