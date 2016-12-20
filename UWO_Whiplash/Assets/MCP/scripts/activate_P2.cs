using UnityEngine;
using System.Collections;

public class activate_P2 : MonoBehaviour {
    public GameObject Player_WP_Collider;    
    public GameObject Path02WPs;    
    public GameObject P2CrashCar;
    public GameObject P2ActualCar;
    public GameObject Camera;
    public GameObject Menu;
    public GameObject trafficLights;
   // public GameObject horizontalLook;

    // Use this for initialization
    public void activate_P2_Script()
    {
        
        Player_WP_Collider.GetComponent<Path02>().enabled = true;        
        Path02WPs.SetActive(true);        
        P2CrashCar.SetActive(true);
        P2ActualCar.SetActive(true);
        Camera.GetComponent<VRCamera>().enabled = true;
        
       // horizontalLook.GetComponent<MouseLook>().enabled = true;
        Menu.SetActive(false);
        trafficLights.SetActive(true);
        
    }
	
}
