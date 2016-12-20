using UnityEngine;
using System.Collections;

public class VRCamera : MonoBehaviour {
    public float rotationspeed = 15f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Pitch rotates the camera around its local Right axis
        transform.Rotate(Vector3.left * Time.deltaTime * Input.GetAxis("Mouse Y") * rotationspeed);

        //Yaw rotates the camera around its local Up axis
        transform.Rotate(Vector3.up * Time.deltaTime * Input.GetAxis("Mouse X") * rotationspeed);
    }
}
