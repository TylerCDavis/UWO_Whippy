using UnityEngine;
using System.Collections;

public class CP2_Position : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float carPositionX = GameObject.Find("crash_Car_P2_Collider").transform.position.x;
        float carPositionZ = GameObject.Find("crash_Car_P2_Collider").transform.position.z;

        Vector3 carFinalPosition = new Vector3(carPositionX, 1, carPositionZ);

        Quaternion carRotation = GameObject.Find("crash_Car_P2_Collider").transform.rotation;

        this.transform.position = carFinalPosition;
        this.transform.rotation = carRotation;
    }
}
