using UnityEngine;
using System.Collections;

public class activate_P1 : MonoBehaviour {

    public GameObject Player_WP_Collider;
    public GameObject Path01Wps;
    public GameObject P1CrashCar;
    public GameObject Camera;
    public GameObject Menu;
    public GameObject trafficLights;
   // public GameObject horizontalLook;
    // Use this for initialization
    void Start () {
        
    }
	public void activate_P1_Script()
    {
        

        Player_WP_Collider.GetComponent<Path01>().enabled = true;
        
        Path01Wps.SetActive(true);        
        P1CrashCar.SetActive(true);        
        Camera.GetComponent<VRCamera>().enabled = true;
        
        Menu.SetActive(false);
        trafficLights.SetActive(true);
        //horizontalLook.GetComponent<MouseLook>().enabled = true;
    }
}
